using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NThaiSmartWeb.EFModels;

[ApiController]
[Route("api/[controller]")]
public class KioskController : ControllerBase
{
    private readonly KioskContext _context;

    public KioskController(KioskContext context)
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
                KioskId = kvp.Key,
                Status = isOnline ? status.StatusCode : "offline",
                StatusText = isOnline ? status.StatusText : "❌ ไม่ตอบสนอง",
                LastSeen = status.Timestamp
            };
        });

        return Ok(list);
    }

    public JObject GetScriptDetail(uint Id)
    {
        var KiosId = _context.KioskArea.FirstOrDefault(_ka => _ka.Id == Id);
        var SignalRHub = _context.Variables?.FirstOrDefault(_v => _v.Name == "SignalRHubPath")?.Value ?? "";
        var req = new JObject { KiosId, SignalRHub };
        return req;
    }

    [HttpPost("DownloadSetupKiosk")]
    public IActionResult SetupKiosk([FromBody] uint Id)
    {
        var script = _context.KioskSetup.FirstOrDefault(s => s.Filename == "setup-kiosk.sh");
        if (script == null) return NotFound("Script not found.");

        var req = GetScriptDetail(Id);
        string result = script.ScriptContent.ReplaceByObject(req);
        return Ok(result);
    }

    [HttpPost("DownloadSetupDocker")]
    public IActionResult SetupDocker([FromBody] uint Id)
    {
        var script = _context.KioskSetup.FirstOrDefault(s => s.Filename == "setup-docker.sh");
        if (script == null) return NotFound("Script not found.");

        var req = GetScriptDetail(Id);
        string result = script.ScriptContent.ReplaceByObject(req);
        return Ok(result);
    }
}