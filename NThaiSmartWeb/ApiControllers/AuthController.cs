using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Login([FromForm] string username, [FromForm] string password, [FromForm] string rememberMe = "off")
    {
        var user = _context.User.FirstOrDefault(u => u.Username == username);
        if (user != null || PasswordHelper.VerifyPassword(password, user.Password))
        {
            NSDXSession.Set(NSDXSessionKey.LoggedInUser, username);
            if (rememberMe == "on")
            {
                // กำหนด cookie ให้อยู่นานขึ้น
                Response.Cookies.Append("LoggedInUser", username, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7), // อยู่ได้ 7 วัน
                    IsEssential = true,
                    HttpOnly = true
                });
            }

            string KioskCode = _context.Kiosk.FirstOrDefault(_k => _k.Id == user.KioskId)?.KioskCode ?? "";
            return Ok(new { message = "✅ Login success", username , KioskCode });
        }
        return Unauthorized(new { message = "❌ Invalid credentials" });
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