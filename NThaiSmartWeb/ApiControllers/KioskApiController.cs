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

    [HttpGet("GetTranslate")]
    public IActionResult GetTranslate()
    {
        var list = _context.Translate.Select(t => new { t.Code, t.Title, t.Icon, t.Words }).ToList();
        return Ok(list);
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
            var encryptedCleaned = Encrypt(cleanedJson);

            var newKioskConsented = new KioskConsented
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

        // ถ้ามี kiosk_ndpp_integrate_id → ดึงจาก table เฉพาะ ID นั้นตัวเดียว
        var integrateId = _context.Variables
            .Where(v => v.Name == "kiosk_ndpp_integrate_id")
            .Select(v => v.Value)
            .FirstOrDefault();

        var ndppUrl = GetNdppBaseUrl();

        if (!string.IsNullOrEmpty(integrateId) && uint.TryParse(integrateId, out uint ndppId))
        {
            var item = _context.KioskIntegrateNdpp.Where(c => c.Id == ndppId && c.Inactive == 0).FirstOrDefault();
            if (item != null)
            {
                item.NdppPreferenceUrl = $"{ndppUrl}/admin/PreferenceConsentFormView?key={item.NdppPreferenceUrlKey}";
                return Ok(new List<KioskIntegrateNdpp> { item });
            }
        }

        var res = _context.KioskIntegrateNdpp.Where(c => c.Inactive == 0).ToList();
        res.ForEach(r => { r.NdppPreferenceUrl = $"{ndppUrl}/admin/PreferenceConsentFormView?key={r.NdppPreferenceUrlKey}"; });

        return Ok(res);
    }

    [HttpPost("GetIntegrateNdppForm")]
    public async Task<IActionResult> GetIntegrateNdppFormAsync([FromBody] EncryptedIntegrateNdppData PrefData)
    {
        string jsonData = Decrypt(PrefData.EncryptedINDPPString);
        var data = JsonConvert.DeserializeObject<IntegrateNdppData>(jsonData);
        var oIntegrateNdpp = _context.KioskIntegrateNdpp.Where(c => c.Id.ToString() == data.IntegrateNdppId).FirstOrDefault();
        Uri uri = new Uri(oIntegrateNdpp.NdppPreferenceUrl);
        string Key = HttpUtility.ParseQueryString(uri.Query).Get("key");

        var ndppUrl = GetNdppBaseUrl();
        var secretKey = _context.Variables.Where(v => v.Name == "SSO_Key").Select(v => v.Value).FirstOrDefault();
        var TokenKey = JWTHelpers.Encode(new JObject { { "Firstname", data.Firstname }, { "Lastname", data.Lastname } }, secretKey);

        using (var client = new HttpClient())
        {
            string requestUrl = $"{ndppUrl}/api/AdminPreferenceConsentForm/PreferenceFormToken?key={Key}&token_key={TokenKey}";
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

    [HttpGet("GetNdppConsented")]
    public async Task<IActionResult> GetNdppConsented([FromQuery] string citizenId, [FromQuery] string kioskCode)
    {
        var kioskId = await _context.Kiosk
            .Where(k => k.KioskCode == kioskCode)
            .Select(k => k.Id).FirstOrDefaultAsync();

        var consented = await _context.KioskIntegrateNdppConsented
            .Where(c => c.CitizenId == citizenId && c.KioskId == kioskId && (c.Inactive == null || c.Inactive == 0))
            .OrderByDescending(c => c.CreatedDate)
            .Select(c => new
            {
                c.KioskIntegrateNdppId,
                c.PurposeOptionDetail,
                c.Email,
                c.CreatedDate
            })
            .FirstOrDefaultAsync();

        return Ok(consented);
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

            var ndppUrl = GetNdppBaseUrl();
            var secretKey = _context.Variables.Where(v => v.Name == "SSO_Key").Select(v => v.Value).FirstOrDefault();
            var TokenKey = JWTHelpers.Encode(new JObject {
                { "Firstname", data.Firstname },
                { "Lastname", data.Lastname },
                { "Email", data.Email }
            }, secretKey);

            string requestUrl = $"{ndppUrl}/api/AdminPreferenceConsentForm/PreferenceFormConsent";

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
                var callbackUrl = _context.Variables
                    .Where(v => v.Name == "kiosk_netka_entelligence_api")
                    .Select(v => v.Value).FirstOrDefault() ?? "";

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
                    photo = data.photo ?? "",
                    face_capture = data.face_capture ?? "",
                    idcard = data.citizenID ?? "",
                    fullNameTH = data.fullNameTH ?? "",
                    fullNameEN = data.fullNameEN ?? "",
                    ActivityNameEn = formJson["ActivityNameEn"]?.ToString() ?? "",
                    ActivityNameTh = formJson["ActivityNameTh"]?.ToString() ?? "",
                    BusinessProcessEn = formJson["BusinessProcessEn"]?.ToString() ?? "",
                    BusinessProcessTh = formJson["BusinessProcessTh"]?.ToString() ?? "",
                    EntityEn = formJson["EntityEn"]?.ToString() ?? "",
                    EntityTh = formJson["EntityTh"]?.ToString() ?? "",
                    OrganizationUnitEn = formJson["OrganizationUnitEn"]?.ToString() ?? "",
                    OrganizationUnitTh = formJson["OrganizationUnitTh"]?.ToString() ?? "",
                    purpose_option = purposeOptions,
                    service_id = formJson["service_id"]?.ToObject<int>() ?? 0,
                    version = formJson["version"]?.ToString() ?? "2"
                };
                await CallExternalHttpAsync(callbackUrl, HttpMethod.Post, callbackPayload);

                // บันทึก consent ลง kiosk_integrate_ndpp_consented
                var kioskId = _context.Kiosk
                    .Where(k => k.KioskCode == data.KioskCode)
                    .Select(k => k.Id).FirstOrDefault();

                var purposeDetailJson = System.Text.Json.JsonSerializer.Serialize(
                    data.PurposeOptionDetail ?? new List<PurposeOptionDetail>(),
                    new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

                _context.KioskIntegrateNdppConsented.Add(new KioskIntegrateNdppConsented
                {
                    KioskId = kioskId,
                    KioskIntegrateNdppId = oIntegrateNdpp.Id,
                    CitizenId = data.citizenID,
                    FullnameTh = data.fullNameTH,
                    FullnameEn = data.fullNameEN,
                    Email = data.Email,
                    PurposeOptionDetail = purposeDetailJson,
                    CreatedDate = DateTime.Now,
                    CreatedBy = data.KioskCode
                });
                await _context.SaveChangesAsync();

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

    /// <summary>
    /// ดึง NDPP base URL จาก variable แล้ว replace {{ndpp_url}} ใน string
    /// </summary>
    private string GetNdppBaseUrl() =>
        _context.Variables.Where(v => v.Name == "kiosk_ndpp_integrate_url").Select(v => v.Value).FirstOrDefault() ?? "";

    private string ResolveNdppUrl(string url) =>
        string.IsNullOrEmpty(url) ? url : url.Replace("{{ndpp_url}}", GetNdppBaseUrl());

    [HttpGet("GetPrivacyNotice")]
    public async Task<IActionResult> GetPrivacyNotice()
    {
        try
        {
            var rawUrl = _context.Variables.Where(v => v.Name == "kiosk_ndpp_privacy_notice").Select(v => v.Value).FirstOrDefault() ?? "";
            var url = ResolveNdppUrl(rawUrl);
            Console.WriteLine($"GetPrivacyNotice url: [{url}]");

            if (string.IsNullOrEmpty(url))
                return Ok(new { content = "", name = "" });

            Uri uri = new Uri(url);
            // DecryptToken ข้างใน NDPP ทำ UrlDecode เอง → ต้องส่ง encoded key
            string key = HttpUtility.ParseQueryString(uri.Query).Get("key");
            if (string.IsNullOrEmpty(key))
                return Ok(new { content = "", name = "" });

            string encodedKey = HttpUtility.UrlEncode(key);
            Console.WriteLine($"GetPrivacyNotice key: [{key}] encodedKey: [{encodedKey}]");

            var ndppUrl = GetNdppBaseUrl();
            string requestUrl = $"{ndppUrl}/api/AdminPrivacyPolicyOu/GetPolicyOuByKey";

            using var client = new HttpClient();
            var body = new StringContent($"\"{encodedKey}\"", Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUrl, body);
            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"GetPrivacyNotice NDPP response: {response.StatusCode} - {result?.Substring(0, Math.Min(result?.Length ?? 0, 200))}");

            if (response.IsSuccessStatusCode)
            {
                var token = JToken.Parse(result);
                JObject json = token is JArray arr && arr.Count > 0 ? arr[0] as JObject : token as JObject;

                if (json != null)
                {
                    var content = json["Content"]?.ToString() ?? "";
                    var name = json["Name"]?.ToString() ?? "";
                    return Ok(new { content, name });
                }
            }

            return Ok(new { content = "", name = "" });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetPrivacyNotice error: {ex.Message}");
            return Ok(new { content = "", name = "" });
        }
    }

    [HttpGet("CheckReturningUser")]
    public async Task<IActionResult> CheckReturningUser([FromQuery] string idcard)
    {
        if (string.IsNullOrEmpty(idcard)) return BadRequest("Missing idcard");

        var consented = await _context.KioskConsented
            .Where(c => c.Idcard == idcard)
            .OrderByDescending(c => c.ConsentedDate)
            .FirstOrDefaultAsync();

        if (consented == null)
            return Ok(new { isReturning = false });

        return Ok(new
        {
            isReturning = true,
            consentedId = consented.Id,
            consentedDate = consented.ConsentedDate
        });
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
}