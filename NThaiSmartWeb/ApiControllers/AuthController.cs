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

    [HttpPost("sso")]
    public IActionResult SSO([FromBody] JObject data)
    {
        var kioskCode = data["kioskCode"]?.ToString();
        var token = data["token"]?.ToString();
        var oKiosk = _context.Kiosk.Where(k => k.KioskCode == kioskCode && k.Inactive == 0 && k.KioskToken == token).FirstOrDefault();

        if (oKiosk != null)
        {
            var user = _context.User.Where(_u => _u.KioskId == oKiosk.Id).FirstOrDefault();
            if (user != null)
            {
                data["username"] = user.Username;
                data["password"] = user.Password;
            }
            return Login(data);
        }
        else
            return BadRequest(new { message = "SSO ไม่สำเร็จ" });

    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] JObject data)
    {
        var username = data["username"]?.ToString();
        var password = data["password"]?.ToString();
        var rememberMe = data["rememberMe"]?.ToString() ?? "off";
        var kioskCode = data["kioskCode"]?.ToString();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return BadRequest(new { message = "กรุณาระบุชื่อผู้ใช้และรหัสผ่าน" });

        var findUser = _context.User.Where(u => u.Username == username).FirstOrDefault();
        if (findUser == null) return BadRequest(new { message = "❌ User not found" });

        //if (!PasswordHelper.VerifyPassword(password, user.Password))
        //    return Unauthorized(new { message = "❌ Invalid credentials" });

        var oKiosk = new Kiosk();
        if (!string.IsNullOrEmpty(kioskCode))
        {
            oKiosk = _context.Kiosk.Where(k => k.Id == findUser.KioskId && k.KioskCode == kioskCode).FirstOrDefault();
            if (oKiosk == null) return BadRequest(new { message = "ชื่อผู้ใช้ไม่ตรงกับตู้ Kiosk นี้" });
        }

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

        return Ok(new { message = "✅ Login success", username, oKiosk.KioskCode });
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