using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NThaiSmartWeb.EFModels;

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
}