using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NThaiSmartWeb.EFModels;
using System;
using System.Security.Cryptography;
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
        string username = NSDXSession.Get<string>(NSDXSessionKey.LoggedInUser);
        uint KioskId = _context.User.FirstOrDefault(_u => _u.Username == username)?.KioskId ?? 0;
        var oKiosk = _context.Kiosk.FirstOrDefault(_k => _k.Id == KioskId);

        var SignalRHub = _context.Variables?.FirstOrDefault(_v => _v.Name == "SignalRHubPath")?.Value ?? "";
        var res = JObject.FromObject(new { oKiosk.KioskCode, SignalRHub });
        return res;
    }

    [HttpPost("DownloadSetupKiosk")]
    public IActionResult SetupKiosk()
    {
        string filename = "setup-kiosk.sh";
        var script = _context.KioskSetup.FirstOrDefault(s => s.Filename == filename);
        if (script == null) return NotFound("Script not found.");

        JObject req = GetScriptDetail();
        string content = script.ScriptContent.ReplaceByObject(req);
        var bytes = System.Text.Encoding.UTF8.GetBytes(content);

        return File(bytes, "application/x-sh", filename);
    }
     

    [HttpPost("DownloadSetupDocker")]
    public IActionResult SetupDocker()
    {
        string filename = "setup-docker.sh";
        var script = _context.KioskSetup.FirstOrDefault(s => s.Filename == filename);
        if (script == null) return NotFound("Script not found.");

        JObject req = GetScriptDetail();
        string result = script.ScriptContent.ReplaceByObject(req);
        var bytes = System.Text.Encoding.UTF8.GetBytes(result);

        return File(bytes, "application/x-sh", filename);
    }

  
    public class NationalCardPayload
    {
        public uint KioskId { get; set; }
        public string KioskCode { get; set; }
        public string citizenID { get; set; }
        public string fullNameTH { get; set; }
        public string fullNameEN { get; set; }
        public string dateOfBirth { get; set; }
        public string issueDate { get; set; }
        public string expireDate { get; set; }
        public string address { get; set; }
        public string issuer { get; set; }
        public string face_capture { get; set; } 
    }

    [HttpPost("SaveNationalCardData")]
    public IActionResult SaveNationalCardData([FromBody] EncryptedPayload payload)
    {
        try
        {
            string jsondata = Decrypt(payload.EncrypString);
            var data = JsonConvert.DeserializeObject<NationalCardPayload>(jsondata);
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
                return Ok(new { message = "✅ บันทึกสำเร็จ" });
            }
            else
            {
                return BadRequest(new { message = "❌ บันทึกไม่สำเร็จ" });
            }

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "❌ บันทึกไม่สำเร็จ" });
        } 

    }
}