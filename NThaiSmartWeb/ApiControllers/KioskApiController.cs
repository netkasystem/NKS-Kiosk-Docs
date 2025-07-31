using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NThaiSmartWeb.EFModels;
using System.Text;
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

    public JObject GetScriptDetail(string username = null)
    {
        var SignalRHub = _context.Variables?.FirstOrDefault(_v => _v.Name == "kiosk_path_web")?.Value ?? "";
        var detail = new { URL = SignalRHub };
        return JObject.FromObject(detail);
    }

    [HttpPost("DownloadFile")]
    public IActionResult DownloadFile([FromQuery] string fileCode, string username = null)
    {
        if (string.IsNullOrEmpty(fileCode)) return BadRequest("Missing fileCode");

        var script = _context.KioskSetup.Where(k => k.Code.StartsWith(fileCode) && (k.IsActive ?? false))
                                        .Where(k => !string.IsNullOrEmpty(k.Version) && k.Version.StartsWith("v"))
                                        .AsEnumerable()
                                        .OrderByDescending(k => Version.Parse(k.Version.TrimStart('v')))
                                        .FirstOrDefault();

        if (script == null) return NotFound("Script not found.");

        JObject req = GetScriptDetail(username);
        if (username == null)
            username = NSDXSession.Get<string>(NSDXSessionKey.CurrentUser);

        uint KioskId = _context.User.FirstOrDefault(_u => _u.Username == username)?.KioskId ?? 0;
        var oKiosk = _context.Kiosk.Where(_k => _k.Id == KioskId).FirstOrDefault();

        if (oKiosk != null && fileCode.StartsWith("setup-kiosk-config"))
        {
            var KIOSK_TOKEN = GeneratePermanentToken();
            req["KIOSK_TOKEN"] = KIOSK_TOKEN;

            req["KIOSK_ID"] = oKiosk.Id;
            req["KIOSK_CODE"] = oKiosk?.KioskCode ?? "";

            oKiosk.KioskToken = KIOSK_TOKEN;
            _context.SaveChanges();
        }

        string file_type = "application/octet-stream"; // default binary
        byte[] bytes;

        string result = script.ScriptContent;
        string ext = Path.GetExtension(script.Filename).ToLowerInvariant();

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
        return File(bytes, file_type, script.Filename);
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
        if (int.TryParse(CustomFormId, out int formId))
        {
            CustomfieldId = Convert.ToUInt32(CustomFormId);
        }
        var JsonForm = _context.CustomForm.Where(c => c.Id == Convert.ToInt32(CustomFormId)).Select(c => c.FormFieldJson).ToList();
        return Ok(JsonForm);
    }
}