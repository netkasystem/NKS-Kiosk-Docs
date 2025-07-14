using System.Text.Json;

public static class NSDXSessionKey
{
    public static string SessionVariable = "_SessionVariable";
    public static string SessionModuleID = "_SessionModuleID";
    public static string SessionLicense = "_SessionLicense";
    public static string CurrentUser = "CurrentUser";

    public static string ModuleByLicense = "_ModuleByLicense";
    public static string AdHocModuleByLicense = "_AdHocModuleByLicense";
    public static string APIGetIncident = "APIGetIncident";

    public static string KioskCode = "KioskCode";
    public static string MenuApiPathAnonymous = "_MenuApiPathAnonymous";
}

public static class NSDXSession
{
    public static ISession GetSession => NSDXHttpContextHelpers.HttpContextAccessor.HttpContext.Session;

    public static void Clear() => GetSession.Clear();

    public static void Set<T>(string key, T value) => GetSession.SetString(key, JsonSerializer.Serialize(value));

    public static T Get<T>(string key)
    {
        var value = GetSession.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }

    public static void Set<T>(this ISession session, string key, T value) => session.SetString(key, JsonSerializer.Serialize(value));

    public static T Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }

    public static void Set(this ISession session, string key, string value) => session.SetString(key, JsonSerializer.Serialize(value));

    public static string Get(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<string>(value);
    }

    public static T GetDefault<T>(string key, Func<T> defaultValueFactory = null)
    {
        var _default = Get<T>(key);
        if (_default == null)
        {
            _default = defaultValueFactory();
            Set(key, _default);
        }
        return _default;
    }

    public static string GetCurrentUser => Get<string>(NSDXSessionKey.CurrentUser);

    public static List<string> GetMenuApiPathAnonymous => GetDefault(NSDXSessionKey.MenuApiPathAnonymous,
                () => EntitiesHelpers.DatabaseContext.MenuApiPathAnonymous.Where(_m => !string.IsNullOrEmpty(_m.Path)).Select(_m => _m.Path.ToLower()).ToList());
}