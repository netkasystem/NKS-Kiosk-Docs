using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthorizationFilter : IAuthorizationFilter
{
    public List<string> AllowApiList = new List<string>{
        "/api/kioskapi/downloadsetupkiosk" ,
        "/api/kioskapi/downloadsetupdocker",
        "/api/auth/login",
        "/api/auth/logout",
        "/api/kioskapi/savenationalcarddata",
        "/api/kioskapi/getcustomform",
        "/api/KioskApi/DownloadFile",
        "/api/KioskApi/GetIntegrateNdppForm",
        "/api/KioskApi/GetPrivacyNotice",
        "/api/KioskApi/CheckReturningUser",
    }.Select(x => x.ToLower()).ToList();

    public List<string> AllowPageList = new List<string>{
        "/login",
        "/account/login",
        "/account/logout",
    }.Select(x => x.ToLower()).ToList();

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.Request.Path.Value.ToLower().StartsWith("/api/"))
        {
            // API Here
            OnWebApiRequest(context);
        }
        else
        {
            // Page Here
            OnWebPageRequest(context);
        }
    }

    public void OnWebApiRequest(AuthorizationFilterContext context)
    {
        var path = context.HttpContext.Request.Path.Value?.Replace("/api", "")?.ToLower();
        // ⛔ อนุญาตเฉพาะ API ที่คุณ whitelist ไว้ (หรือสลับเป็น Blacklist ถ้าส่วนใหญ่ปิดหมด)
        if (AllowApiList.Contains(path))
            return;
        else if (NSDXSession.GetMenuApiPathAnonymous.Contains(path))
            return;

        if (NSDXSession.GetCurrentUser == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }

    public void OnWebPageRequest(AuthorizationFilterContext context)
    {
        var path = context.HttpContext.Request.Path.Value?.ToLower();
        // ✅ Allowlist สำหรับ Web UI และ Swagger
        if (AllowPageList.Contains(path) || path.StartsWith("/swagger") || path.StartsWith("/favicon"))
            return;

        // ✅ เช็ค session login
        var user = context.HttpContext.Session.GetString(NSDXSessionKey.CurrentUser);
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
}