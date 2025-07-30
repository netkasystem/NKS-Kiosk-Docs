using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NThaiSmartWeb.EFModels;
using NuGet.Common;

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
        var kioskCode = data["kiosk_code"]?.ToString();
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

            data["sso"] = true;

            return Login(data);
        }
        else
            return BadRequest(new { message = "SSO ไม่สำเร็จ" });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] JObject data)
    {
        var username = data["username"]?.ToString();
        var password = data["password"]?.ToString()?.ToUpper();
        var rememberMe = data["rememberMe"]?.ToString() ?? "off";
        bool sso = (bool?)data?["sso"] ?? false;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return BadRequest(new { message = "กรุณาระบุชื่อผู้ใช้และรหัสผ่าน" });

        var findUser = _context.User.Where(u => u.Username == username).FirstOrDefault();
        if (findUser == null) return BadRequest(new { message = "❌ User not found" });

        if (password != findUser.Password)
            return Unauthorized(new { message = "❌ Invalid Credentials" });

        var oKiosk = new Kiosk();
        oKiosk = _context.Kiosk.Where(k => k.Id == findUser.KioskId).FirstOrDefault();

        //มี user แต่ไม่ใช่ kiosk
        if (oKiosk == null) return BadRequest(new { message = "❌ User not found" });

        //kiosk inactive
        if (oKiosk.Inactive == 1) return BadRequest(new { message = "ตู้ Kiosk นี้ไม่เปิดให้ใช้งาน" });

        //มี token = user ถูกใช้แล้ว
        if (!string.IsNullOrEmpty(oKiosk.KioskToken) && !sso) return BadRequest(new { message = "User นี้ถูกใช้งานกับตู้ Kiosk เครื่องอื่นอยู่แล้ว" });

        var KioskHomeDelaySec = _context.Variables.Where(v => v.Name == "kiosk_home_delay_sec").Select(v => v.Value).FirstOrDefault();
        var KioskWaitBrokenCardSec = _context.Variables.Where(v => v.Name == "kiosk_wait_broken_card_sec").Select(v => v.Value).FirstOrDefault();
        var KioskReadStepSec = _context.Variables.Where(v => v.Name == "kiosk_read_step_sec").Select(v => v.Value).FirstOrDefault();
        var KioskReadStepScanSec = _context.Variables.Where(v => v.Name == "kiosk_read_step_scan_sec").Select(v => v.Value).FirstOrDefault();

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

        return Ok(new { 
            message = "✅ Login success", username, 
            oKiosk.KioskCode, 
            KioskHomeDelaySec, 
            KioskWaitBrokenCardSec, 
            KioskReadStepSec, 
            KioskReadStepScanSec, 
            HasToken= !string.IsNullOrEmpty(oKiosk.KioskToken) 
        });
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