using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthorizationFilter : IAuthorizationFilter
{
    public List<string> AllowApiList = new List<string>{
        "/api/kioskapi/downloadsetupkiosk" ,
        "/api/kioskapi/downloadsetupdocker",
        "/api/auth/login",
        "/api/auth/logout",
    };

    public void OnWebApiRequest(AuthorizationFilterContext context)
    {
        var path = context.HttpContext.Request.Path.Value?.ToLower();
        // ⛔ อนุญาตเฉพาะ API ที่คุณ whitelist ไว้ (หรือสลับเป็น Blacklist ถ้าส่วนใหญ่ปิดหมด)
        if (AllowApiList.Contains(path))
        {
            // ✅ API พวกนี้ต้อง login → ดำเนินต่อไป
        }
        else if (path.StartsWith("/api/"))
        {
            // ❌ ไม่อนุญาตเรียก API อื่นถ้าไม่มี session
            context.Result = new UnauthorizedResult();
            return;
        }
    }

    public void OnWebPageRequest(AuthorizationFilterContext context)
    {
        var path = context.HttpContext.Request.Path.Value?.ToLower();
        // ✅ Allowlist สำหรับ Web UI และ Swagger
        if (path.Contains("/login") || path.Contains("/account/login") || path.Contains("/account/logout") || path.StartsWith("/swagger") || path.StartsWith("/favicon"))
        {
            return;
        }

        // ✅ เช็ค session login
        var user = context.HttpContext.Session.GetString(NSDXSessionKey.LoggedInUser);
        if (string.IsNullOrEmpty(user))
        {
            // 🔁 ถ้าเป็น Web → Redirect
            if (!path.StartsWith("/api"))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "" }
                });
            }
            else
            {
                // 🔒 ถ้าเป็น API → 401 Unauthorized
                context.Result = new UnauthorizedResult();
            }
        }
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.Request.Path.Value.ToLower().StartsWith("/api/"))
        {
            Console.WriteLine(DateTime.Now + " >> api >> " + context.HttpContext.Request.Path.Value);
            // API Here
            OnWebApiRequest(context);
        }
        else
        {
            Console.WriteLine(DateTime.Now + " >> api >> " + context.HttpContext.Request.Path.Value);
            // Page Here
            OnWebPageRequest(context);
        }
    }
}