using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSDX.Common.Security;
using NThaiSmartWeb.EFModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
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

    // ตัวอย่าง: 4f0e3bc2381742e8b8a7dd1703ec2d3d
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

        if (!string.IsNullOrEmpty(kiosk_setup.UrlRegion)) req["URL"] = kiosk_setup.UrlRegion;

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
    public IActionResult SaveNationalCardData([FromBody] EncryptedPayload payload)
    {
        try
        {
            string jsonData = Decrypt(payload.EncrypString);
            string jsonUpdatedData = Decrypt(payload.EncrypUpdatedData);
            string jsonCustomDataData = Decrypt(payload.EncrypCustomDataData);
            var data = JsonConvert.DeserializeObject<NationalCardModel>(jsonData);
            if (data != null)
            {
                data.KioskId = _context.Kiosk.Where(k => k.KioskCode == data.KioskCode).Select(k => k.Id).FirstOrDefault();

                var newKioskConsented = new NThaiSmartWeb.EFModels.KioskConsented
                {
                    KioskId = data.KioskId,
                    Idcard = data.citizenID,
                    JsonData = payload.EncrypString,
                    JsonUpdatedData = payload.EncrypUpdatedData,
                    JsonCustomData = payload.EncrypCustomDataData
                };
                _context.KioskConsented.Add(newKioskConsented);
                _context.SaveChanges();
                return Ok("✅ บันทึกสำเร็จ");
            }
            else
            {
                return BadRequest("❌ บันทึกไม่สำเร็จ");
            }
        }
        catch (Exception ex)
        {
            return BadRequest("❌ บันทึกไม่สำเร็จ");
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
    public IActionResult GetIntegrateNdpp()
    {

        var LsIntegrateNdpp = _context.KioskIntegrateNdpp.Where(c => c.Inactive == 0).ToList();
        return Ok(LsIntegrateNdpp);
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
        var TokenKey = JWTHelpers.Encode(new JObject
            {
                { "Firstname", data.Firstname },
                { "Lastname", data.Lastname }
            }, secretKey);
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

            // เตรียม payload
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
}