using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

public static class NSDXHttpContextHelpers
{
    public static IHttpContextAccessor HttpContextAccessor { get; set; }

    public static string GetDBName
    {
        get
        {
            string dbName = "";
            string custnamesite = HttpContextAccessor?.HttpContext?.Request?.Headers["Host"] ?? "";
            if (custnamesite.Contains("netka")) dbName = custnamesite.Split('.', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? "";
            return dbName;
        }
    }
}