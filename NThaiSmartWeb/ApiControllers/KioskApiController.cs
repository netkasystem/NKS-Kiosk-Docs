using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSDX.Common.Security;
using NThaiSmartWeb.EFModels;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;
using static AesEcb;

[ApiController]
[Route("api/[controller]")]
public class KioskApiController : ControllerBase
{
    private readonly KioskContext _context;

    public KioskApiController(KioskContext context)
    {
        _context = context;
    }

    [HttpGet("GetKioskList")]
    public IActionResult GetKioskList()
    {
        var kioskMap = CardReaderHub.GetKioskStatusMap();
        var now = DateTime.Now;

        var list = kioskMap.Select(kvp =>
        {
            var status = kvp.Value;
            var isOnline = (now - status.Timestamp).TotalSeconds < 20;

            return new
            {
                KioskCode = kvp.Key,
                Status = isOnline ? status.StatusCode : "offline",
                StatusText = isOnline ? status.StatusText : "❌ ไม่ตอบสนอง",
                LastSeen = status.Timestamp
            };
        });

        return Ok(list);
    }

    public string GeneratePermanentToken() => Guid.NewGuid().ToString("N");

    [HttpPost("DownloadFile")]
    public IActionResult DownloadFile([FromQuery] string fileCode, string username = null, uint KioskId = 0, string KioskCode = null)
    {
        if (string.IsNullOrEmpty(fileCode)) return BadRequest("Missing fileCode");

        var find_setup = _context.KioskSetup.Where(k => (k.IsActive ?? false) && k.Code == fileCode);
        if (!find_setup.Any())
            find_setup = _context.KioskSetup.Where(k => (k.IsActive ?? false) && k.Code.StartsWith(fileCode));

        var kiosk_setup = find_setup.AsEnumerable().OrderByDescending(k => Version.Parse(k.Version)).FirstOrDefault();

        if (kiosk_setup == null) return NotFound("Script not found.");

        var SignalRHub = _context.Variables?.FirstOrDefault(_v => _v.Name == "kiosk_path_web")?.Value ?? "";
        JObject req = JObject.FromObject(new { URL = SignalRHub });

        if (username == null)
            username = NSDXSession.Get<string>(NSDXSessionKey.CurrentUser);

        if (KioskId == 0)
            KioskId = _context.User.FirstOrDefault(_u => _u.Username == username)?.KioskId ?? 0;

        var oKiosk = _context.Kiosk.Where(_k => _k.Id == KioskId || _k.KioskCode == KioskCode).FirstOrDefault();

        if (oKiosk != null && fileCode.StartsWith("setup-kiosk-config"))
        {
            var KIOSK_TOKEN = GeneratePermanentToken();
            oKiosk.KioskToken = KIOSK_TOKEN;
            _context.SaveChanges();

            var URL = _context.Region.Where(r => r.RegionId == oKiosk.RegionId).Select(r => r.RegionSite).FirstOrDefault() ?? "";
            if (!string.IsNullOrEmpty(URL))
                req["URL"] = URL;
        }

        req["KIOSK_ID"] = oKiosk?.Id ?? 0;
        req["KIOSK_CODE"] = oKiosk?.KioskCode ?? "";
        req["KIOSK_TOKEN"] = oKiosk?.KioskToken ?? "";

        string file_type = "application/octet-stream"; // default binary
        byte[] bytes;

        string result = kiosk_setup.ScriptContent;
        string ext = Path.GetExtension(kiosk_setup.Filename).ToLowerInvariant();

        switch (ext)
        {
            case ".sh":
                result = result.ReplaceByObject(req);
                result = result.Replace("\r\n", "\n"); // 🔧 Convert CRLF to LF
                file_type = "application/x-sh";
                bytes = Encoding.UTF8.GetBytes(result);
                break;

            case ".txt":
                result = result.ReplaceByObject(req);
                file_type = "text/plain";
                bytes = Encoding.UTF8.GetBytes(result);
                break;

            case ".json":
                file_type = "application/json";
                bytes = Encoding.UTF8.GetBytes(result);
                break;

            case ".html":
                file_type = "text/html";
                bytes = Encoding.UTF8.GetBytes(result);
                break;

            case ".pdf":
                // assume base64-encoded binary
                file_type = "application/pdf";
                bytes = Convert.FromBase64String(result);
                break;

            case ".zip":
                file_type = "application/zip";
                bytes = Convert.FromBase64String(result); // ถ้าเก็บใน base64
                break;

            default:
                // fallback: check if it's base64 and try decode
                try
                {
                    bytes = Convert.FromBase64String(result);
                }
                catch
                {
                    // fallback to UTF-8 text if not base64
                    bytes = Encoding.UTF8.GetBytes(result);
                }
                break;
        }

        // ส่งไฟล์ออกไป
        return File(bytes, file_type, kiosk_setup.Filename);
    }

    [HttpPost("SaveNationalCardData")]
    public async Task<IActionResult> SaveNationalCardData([FromBody] EncryptedPayload payload)
    {
        try
        {
            string jsonData = Decrypt(payload.EncrypString);
            string jsonUpdatedData = Decrypt(payload.EncrypUpdatedData);
            string jsonCustomData = Decrypt(payload.EncrypCustomDataData);

            var data = JsonConvert.DeserializeObject<NationalCardModel>(jsonData);
            if (data == null)
                return BadRequest("❌ บันทึกไม่สำเร็จ");

            data.KioskId = _context.Kiosk
                .Where(k => k.KioskCode == data.KioskCode)
                .Select(k => k.Id)
                .FirstOrDefault();

            // ─── Upload photo จากบัตร ─────────────────────────────────
            if (!string.IsNullOrEmpty(data.photo))
            {
                data.photo_path = FileManagementHelpers.SaveFilePath(
                    new FileViewModel { FileName = "photo.jpg", FileBase64 = data.photo },
                    "kiosk card photo",
                    subPath: "kiosk/photo"
                );
                data.photo = string.Empty;
            }

            // ─── Upload face_capture จากกล้อง ────────────────────────
            if (!string.IsNullOrEmpty(data.face_capture))
            {
                data.face_capture_path = FileManagementHelpers.SaveFilePath(
                    new FileViewModel { FileName = "face.jpg", FileBase64 = data.face_capture },
                    "kiosk face capture",
                    subPath: "kiosk/face"
                );
                data.face_capture = string.Empty;
            }

            // ─── Re-encrypt ข้อมูลที่เคลียร์ base64 แล้ว ─────────────
            var cleanedJson = JsonConvert.SerializeObject(data);
            var encryptedCleaned = AesEcb.Encrypt(cleanedJson);

            var newKioskConsented = new NThaiSmartWeb.EFModels.KioskConsented
            {
                KioskId = data.KioskId,
                Idcard = data.citizenID,
                JsonData = encryptedCleaned,
                JsonUpdatedData = payload.EncrypUpdatedData,
                JsonCustomData = payload.EncrypCustomDataData
            };
            _context.KioskConsented.Add(newKioskConsented);
            await _context.SaveChangesAsync();
            return Ok(new { photo_path = data.photo_path ?? "", face_capture_path = data.face_capture_path ?? "" });
        }
        catch (Exception ex)
        {
            return BadRequest($"❌ บันทึกไม่สำเร็จ: {ex.Message}");
        }
    }

    [HttpGet("GetCustomForm")]
    public IActionResult GetCustomForm()
    {
        var CustomFormId = _context.Variables.Where(v => v.Name == "kiosk_use_custom_form_id").Select(v => v.Value).FirstOrDefault();
        uint CustomfieldId = 0;
        if (!string.IsNullOrEmpty(CustomFormId) && int.TryParse(CustomFormId, out int formId))
        {
            CustomfieldId = Convert.ToUInt32(CustomFormId);
        }
        var JsonForm = _context.CustomForm.Where(c => c.Id == CustomfieldId).Select(c => c.FormFieldJson).ToList();
        return Ok(JsonForm);
    }

    [HttpGet("GetIntegrateNdpp")]
    public async Task<IActionResult> GetIntegrateNdpp()
    {
        var _flag = _context.Variables.Where(v => v.Name == "kiosk_ndpp_integrate").Select(v => v.Value).FirstOrDefault();
        if (_flag == "0") return Ok();

        var api = _context.Variables.Where(v => v.Name == "kiosk_ndpp_integrate_api").Select(v => v.Value).FirstOrDefault();
        var res = _context.KioskIntegrateNdpp.Where(c => c.Inactive == 0).ToList();
        res.ForEach(r => { r.NdppPreferenceUrl = $"{api}?key={r.NdppPreferenceUrlKey}"; });

        return Ok(res);
    }

    [HttpGet("GetIntegrateNdppByKiosk")]
    public async Task<IActionResult> GetIntegrateNdppByKiosk([FromQuery] string kioskCode)
    {
        if (string.IsNullOrEmpty(kioskCode)) return BadRequest("Missing kioskCode");

        var _flag = _context.Variables.Where(v => v.Name == "kiosk_ndpp_integrate_by_kiosk").Select(v => v.Value).FirstOrDefault();
        if (_flag == "0") return Ok();

        var kioskId = await _context.Kiosk.Where(_k => _k.KioskCode == kioskCode).Select(_k => _k.Id).FirstOrDefaultAsync();
        var KioskIntegrateNdppId = _context.KioskIntegrateNdppConsentMapping.Where(k => k.KioskId == kioskId).Select(k => k.KioskIntegrateNdppId).ToList();

        var api = _context.Variables.Where(v => v.Name == "kiosk_ndpp_integrate_api").Select(v => v.Value).FirstOrDefault();
        var res = _context.KioskIntegrateNdpp.Where(c => KioskIntegrateNdppId.Contains(c.Id) && c.Inactive == 0).ToList();
        res.ForEach(r => { r.NdppPreferenceUrl = $"{api}?key={r.NdppPreferenceUrlKey}"; });

        return Ok(res);
    }

    [HttpPost("GetIntegrateNdppForm")]
    public async Task<IActionResult> GetIntegrateNdppFormAsync([FromBody] EncryptedIntegrateNdppData PrefData)
    {
        string jsonData = Decrypt(PrefData.EncryptedINDPPString);
        var data = JsonConvert.DeserializeObject<IntegrateNdppData>(jsonData);
        var oIntegrateNdpp = _context.KioskIntegrateNdpp.Where(c => c.Id.ToString() == data.IntegrateNdppId).FirstOrDefault();
        Uri uri = new Uri(oIntegrateNdpp.NdppPreferenceUrl);

        // ใช้ HttpUtility.ParseQueryString ดึง query string
        string Key = HttpUtility.ParseQueryString(uri.Query).Get("key");
        var secretKey = _context.Variables.Where(v => v.Name == "SSO_Key").Select(v => v.Value).FirstOrDefault();
        var TokenKey = JWTHelpers.Encode(new JObject { { "Firstname", data.Firstname }, { "Lastname", data.Lastname } }, secretKey);

        using (var client = new HttpClient())
        {
            // ดึงเฉพาะ host
            string baseHost = $"{uri.Scheme}://{uri.Host}{(uri.IsDefaultPort ? "" : ":" + uri.Port)}";

            // ต่อกับ path คงที่
            string requestUrl = $"{baseHost}/api/AdminPreferenceConsentForm/PreferenceFormToken?key={Key}&token_key={TokenKey}";
            // ส่ง request
            HttpResponseMessage response = await client.GetAsync(requestUrl);
            string result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, result);
            }
        }
    }

    [HttpPost("SubmitIntegrateNdpp")]
    public async Task<IActionResult> SubmitIntegrateNdpp([FromBody] EncryptedIntegrateNdppData PrefData)
    {
        try
        {
            string jsonData = Decrypt(PrefData.EncryptedINDPPString);
            var data = JsonConvert.DeserializeObject<IntegrateNdppData>(jsonData);
            var oIntegrateNdpp = _context.KioskIntegrateNdpp.Where(c => c.Id.ToString() == data.IntegrateNdppId).FirstOrDefault();
            if (oIntegrateNdpp == null)
                return BadRequest("IntegrateNdpp not found");

            Uri uri = new Uri(oIntegrateNdpp.NdppPreferenceUrl);
            string Key = HttpUtility.ParseQueryString(uri.Query).Get("key");

            if (string.IsNullOrEmpty(Key))
                return BadRequest("Missing key in NdppPreferenceUrl");

            var secretKey = _context.Variables.Where(v => v.Name == "SSO_Key").Select(v => v.Value).FirstOrDefault();
            var TokenKey = JWTHelpers.Encode(new JObject {
                { "Firstname", data.Firstname },
                { "Lastname", data.Lastname },
                { "Email", data.Email }
            }, secretKey);

            // ดึงเฉพาะ host
            string baseHost = $"{uri.Scheme}://{uri.Host}{(uri.IsDefaultPort ? "" : ":" + uri.Port)}";
            string requestUrl = $"{baseHost}/api/AdminPreferenceConsentForm/PreferenceFormConsent";

            var payload = new
            {
                purpose_option = data.PurposeOption.ConvertAll(id => new { PurposeOption = id }),
                key = Key,
                token_key = TokenKey
            };
            // serialize เป็น JSON
            string json = System.Text.Json.JsonSerializer.Serialize(payload, new JsonSerializerOptions());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PutAsync(requestUrl, content);
            string result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var callbackUrl = $"{baseHost}/api/AdminPreferenceConsentForm/ConsentCallback";

                var formJson = JObject.Parse(data.NdppFormData ?? "{}");
                var purposeDetails = data.PurposeOptionDetail ?? new List<PurposeOptionDetail>();
                var purposeOptions = formJson["purpose_option"]?.ToObject<JArray>() ?? new JArray();
                foreach (JObject p in purposeOptions)
                {
                    var id = p["purpose_id"]?.ToString();
                    var detail = purposeDetails.FirstOrDefault(d => d.PurposeNameId == id);
                    if (detail != null)
                        p["selected"] = detail.PurposeChecked;
                }

                var callbackPayload = new
                {
                    photo               = data.photo_path          ?? "",
                    face_capture        = data.face_capture_path   ?? "",
                    idcard              = data.citizenID           ?? "",
                    fullNameTH          = data.fullNameTH          ?? "",
                    fullNameEN          = data.fullNameEN          ?? "",
                    ActivityNameEn      = formJson["ActivityNameEn"]?.ToString()      ?? "",
                    ActivityNameTh      = formJson["ActivityNameTh"]?.ToString()      ?? "",
                    BusinessProcessEn   = formJson["BusinessProcessEn"]?.ToString()   ?? "",
                    BusinessProcessTh   = formJson["BusinessProcessTh"]?.ToString()   ?? "",
                    EntityEn            = formJson["EntityEn"]?.ToString()            ?? "",
                    EntityTh            = formJson["EntityTh"]?.ToString()            ?? "",
                    OrganizationUnitEn  = formJson["OrganizationUnitEn"]?.ToString()  ?? "",
                    OrganizationUnitTh  = formJson["OrganizationUnitTh"]?.ToString()  ?? "",
                    purpose_option      = purposeOptions,
                    service_id          = formJson["service_id"]?.ToObject<int>()     ?? 0,
                    version             = formJson["version"]?.ToString()             ?? "2"
                };
                await CallExternalHttpAsync(callbackUrl, HttpMethod.Post, callbackPayload);

                return Ok(JsonConvert.DeserializeObject(result));
            }
            else
            {
                return StatusCode((int)response.StatusCode, result);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"SubmitIntegrateNdpp failed: {ex.Message}");
        }
    }

    private async Task<(bool Success, string Body)> CallExternalHttpAsync(string url, HttpMethod method, object payload)
    {
        try
        {
            string json = System.Text.Json.JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var request = new HttpRequestMessage(method, url) { Content = content };
            var response = await client.SendAsync(request);
            string body = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode, body);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CallExternalHttpAsync failed: {url} — {ex.Message}");
            return (false, ex.Message);
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterKiosk([FromBody] Kiosk dto)
    {
        // 1) ตรวจสอบ hardware ขั้นต้น
        if (string.IsNullOrWhiteSpace(dto.SerialNumber) || string.IsNullOrWhiteSpace(dto.MacAddress))
            return BadRequest(new { message = "serial_number and mac_address required" });

        var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";

        // 2) หา kiosk เดิมจาก serial หรือ MAC
        var kiosk = await _context.Kiosk.FirstOrDefaultAsync(k => k.SerialNumber == dto.SerialNumber || k.MacAddress == dto.MacAddress);

        // ถ้ายังไม่มี → สร้างใหม่
        if (kiosk == null)
        {
            kiosk = new Kiosk
            {
                KioskCode = $"KIOSK-{Guid.NewGuid().ToString("N").Substring(0, 4).ToUpper()}",
                SerialNumber = dto.SerialNumber,
                MacAddress = dto.MacAddress,
                HardwareHash = dto.HardwareHash,
                FactoryImageVersion = dto.FactoryImageVersion,
                RegisteredAt = DateTime.UtcNow,
                RegisteredIp = clientIp,
                FirstBoot = false,
                ActivationStatus = false,
                KioskToken = GenerateKioskToken(dto.HardwareHash),
                TokenCreatedAt = DateTime.UtcNow
            };

            _context.Kiosk.Add(kiosk);
            await _context.SaveChangesAsync();

            return Ok(new { status = "created", kiosk });
        }

        // 3) ถ้าเคยมีแล้ว → update hardware + token เดิม
        kiosk.LastSeenAt = DateTime.UtcNow;
        kiosk.RegisteredIp = clientIp;

        // อัปเดต hardware เฉพาะตอน clone แล้วเพิ่ง boot ครั้งแรกจริงๆ
        kiosk.SerialNumber = dto.SerialNumber;
        kiosk.MacAddress = dto.MacAddress;
        kiosk.HardwareHash = dto.HardwareHash;
        kiosk.FactoryImageVersion = dto.FactoryImageVersion;

        if (string.IsNullOrEmpty(kiosk.KioskToken))
        {
            kiosk.KioskToken = GenerateKioskToken(dto.HardwareHash);
            kiosk.TokenCreatedAt = DateTime.UtcNow;
        }

        kiosk.FirstBoot = false;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            status = "updated",
            kiosk_id = kiosk.Id,
            kiosk_code = kiosk.KioskCode,
            token = kiosk.KioskToken,
            first_boot = kiosk.FirstBoot
        });
    }

    [HttpPost("enroll")]
    public async Task<IActionResult> Enroll([FromBody] EnrollRequest req, CancellationToken ct)
    {
        if (req == null || string.IsNullOrWhiteSpace(req.DeviceId))
            return BadRequest("device_id required");

        await Task.Delay(10, ct);
        return Ok(new { ok = true, enrolled_at = DateTime.UtcNow });
    }

    [HttpGet("GetConsentURL")]
    public async Task<IActionResult> GetConsentURL([FromQuery] string kioskCode)
    {
        var kioskId = await _context.Kiosk.Where(_k => _k.KioskCode == kioskCode).Select(_k => _k.Id).FirstOrDefaultAsync();
        var integrateNdppId = await _context.KioskIntegrateNdppConsentMapping.Where(_k => _k.KioskId == kioskId).Select(_k => _k.KioskIntegrateNdppId).FirstOrDefaultAsync();
        var oKioskIntegrateNdpp = await _context.KioskIntegrateNdpp.Where(_ki => _ki.Id == integrateNdppId).FirstOrDefaultAsync();

        var default_api = oKioskIntegrateNdpp?.NdppPreferenceUrl ?? "";
        Console.WriteLine($"GetConsentURL Default API {default_api}");
        return Ok(new { url = default_api, integrateNdppId = integrateNdppId.ToString() });
    }

    private static string RandomToken(int length = 64)
    {
        var bytes = new byte[length / 2];
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToHexString(bytes).ToLower();
    }

    private static string GenerateKioskToken(string hardwareHash)
        => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(hardwareHash + RandomToken(32)))).ToLower();
}