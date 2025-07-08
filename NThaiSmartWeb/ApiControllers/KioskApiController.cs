using Microsoft.AspNetCore.Mvc;
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

    public JObject GetScriptDetail()
    {
        string username = NSDXSession.Get<string>(NSDXSessionKey.CurrentUser);
        uint KioskId = _context.User.FirstOrDefault(_u => _u.Username == username)?.KioskId ?? 0;
        var oKiosk = _context.Kiosk.FirstOrDefault(_k => _k.Id == KioskId);

        var SignalRHub = _context.Variables?.FirstOrDefault(_v => _v.Name == "SignalRHubPath")?.Value ?? "";
        var res = JObject.FromObject(new { KIOSK_CODE = oKiosk?.KioskCode ?? "", URL = SignalRHub });
        return res;
    }

    [HttpPost("DownloadFile")]
    public IActionResult DownloadFile([FromQuery] string fileCode)
    {
        if (string.IsNullOrEmpty(fileCode)) return BadRequest("Missing fileCode");

        var script = _context.KioskSetup.Where(k => k.Code.StartsWith(fileCode) && (k.IsActive ?? false))
                                        .Where(k => !string.IsNullOrEmpty(k.Version) && k.Version.StartsWith("v"))
                                        .AsEnumerable()
                                        .OrderByDescending(k => Version.Parse(k.Version.TrimStart('v')))
                                        .FirstOrDefault();

        if (script == null) return NotFound("Script not found.");

        JObject req = GetScriptDetail();
        string result = script.ScriptContent.ReplaceByObject(req);
        var bytes = Encoding.UTF8.GetBytes(result);
        return File(bytes, "application/x-sh", script.Filename);
    }

    [HttpPost("SaveNationalCardData")]
    public IActionResult SaveNationalCardData([FromBody] EncryptedPayload payload)
    {
        try
        {
            string jsondata = Decrypt(payload.EncrypString);
            var data = JsonConvert.DeserializeObject<NationalCardModel>(jsondata);
            if (data != null)
            {
                data.KioskId = _context.Kiosk.Where(k => k.KioskCode == data.KioskCode).Select(k => k.Id).FirstOrDefault();

                var newKioskConsented = new NThaiSmartWeb.EFModels.KioskConsented
                {
                    KioskId = data.KioskId,
                    Idcard = data.citizenID,
                    JsonData = payload.EncrypString
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


    [HttpPost("GetCustomForm")]
    public IActionResult GetCustomForm()
    {
        var CustomFormId = _context.Variables.Where(v => v.Name == "kiosk_use_custom_form_id").Select(v=>v.Value).FirstOrDefault();
        if(Convert.ToInt32(CustomFormId) > 0)
        {
            var JsonForm = _context.CustomForm.Where(c => c.Id == Convert.ToInt32(CustomFormId)).Select(c=>c.FormFieldJson).FirstOrDefault();
            return Ok(JsonForm);
        }
        else
        {
            return Ok("");
        }
    }
}