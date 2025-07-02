using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NThaiSmartWeb.EFModels; // แก้ namespace ให้ตรง

[ApiController]
[Route("api/[controller]")]
public class Select2ApiController : ControllerBase
{
    private readonly KioskContext _context;

    public Select2ApiController(KioskContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetKioskArea([FromQuery] string term = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = _context.Kiosk.Where(k => string.IsNullOrEmpty(term) || k.Description.Contains(term)).OrderBy(k => k.Id);
        var totalCount = await query.CountAsync();
        var results = await query.Skip((page - 1) * pageSize).Take(pageSize).Select(k => new { id = k.Id, text = k.Description }).ToListAsync();

        return Ok(new
        {
            results,
            pagination = new
            {
                more = (page * pageSize) < totalCount
            }
        });
    }
}