using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NThaiSmartWeb.EFModels;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly KioskContext _context;

    public AuthController(KioskContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] JObject data)
    {
        var username = data["username"]?.ToString();
        var password = data["password"]?.ToString();
        var rememberMe = data["rememberMe"]?.ToString() ?? "off";
        var kioskCode = data["KioskCode"]?.ToString();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return BadRequest(new { message = "กรุณาระบุชื่อผู้ใช้และรหัสผ่าน" });

        var userQuery = _context.User.AsQueryable();
        userQuery = userQuery.Where(u => u.Username == username);

        if (!string.IsNullOrEmpty(kioskCode))
            userQuery = userQuery.Where(u => _context.Kiosk.Any(k => k.Id == u.KioskId && k.KioskCode == kioskCode));

        var user = userQuery.FirstOrDefault();
        if (user == null) return BadRequest(new { message = "ชื่อผู้ใช้ไม่ตรงกับตู้ Kiosk นี้" });

        //if (!PasswordHelper.VerifyPassword(password, user.Password))
        //    return Unauthorized(new { message = "❌ Invalid credentials" });

        // ✅ Login สำเร็จ
        NSDXSession.Set(NSDXSessionKey.CurrentUser, username);

        if (rememberMe == "on")
        {
            Response.Cookies.Append("CurrentUser", username, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                IsEssential = true,
                HttpOnly = true
            });
        }

        string kioskCodeFromDb = _context.Kiosk.FirstOrDefault(k => k.Id == user.KioskId)?.KioskCode ?? "";
        return Ok(new { message = "✅ Login success", username, KioskCode = kioskCodeFromDb });
    }

    [HttpPost("reset")]
    public IActionResult ResetPassword([FromForm] string token, [FromForm] string newPassword, [FromForm] string confirmPassword)
    {
        var user = _context.User.FirstOrDefault(u => u.PasswordResetToken == token);
        if (user == null) return BadRequest(new { message = "❌ Invalid or expired token" });
        if (newPassword != confirmPassword) return BadRequest(new { message = "❌ Passwords do not match" });

        user.Password = PasswordHelper.CreateMD5(newPassword);
        user.PasswordResetToken = null;
        _context.SaveChanges();

        return Ok(new { message = "✅ Password reset success" });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        NSDXSession.Clear();
        return Ok(new { message = "👋 Logged out" });
    }
}