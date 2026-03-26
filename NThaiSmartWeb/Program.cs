using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using NThaiSmartWeb.EFModels;
using StackExchange.Redis;
using System.Globalization;

// ======================
// Culture
// ======================
var cultureInfo = new CultureInfo("en-GB");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

// ======================
// Environment Variables
// ======================
string expiration = Environment.GetEnvironmentVariable("SESSION_TIMEOUT") ?? "8";
double timeout    = double.Parse(expiration);
string cookieName = Environment.GetEnvironmentVariable("COOKIE_NAME") ?? "NetkaKiosk";
string? redisConn = Environment.GetEnvironmentVariable("REDIS_CONNECTION");   // เช่น "localhost:6379"

Console.WriteLine($"🔧 Build Version: {BuildVersion.Value}");

// ======================
// Redis (optional – fallback to in-memory ถ้าไม่มี env)
// ======================
ConnectionMultiplexer? redis = null;
bool useRedis = false;

if (!string.IsNullOrEmpty(redisConn))
{
    try
    {
        var cfg = ConfigurationOptions.Parse(redisConn);
        cfg.AbortOnConnectFail = false;
        cfg.ConnectTimeout     = 3000;
        cfg.ReconnectRetryPolicy = new ExponentialRetry(5000);
        redis    = ConnectionMultiplexer.Connect(cfg);
        useRedis = redis.IsConnected;
        Console.WriteLine(useRedis
            ? $"✅ Redis connected: {redisConn}"
            : $"⚠️ Redis unreachable, falling back to in-memory: {redisConn}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"⚠️ Redis connect failed ({ex.Message}), falling back to in-memory");
    }
}
else
{
    Console.WriteLine("ℹ️ REDIS_CONNECTION not set — using in-memory session/cache");
}

// ======================
// MVC / JSON
// ======================
builder.Services
    .AddControllersWithViews(options =>
    {
        options.Filters.Add<AuthorizationFilter>();
        options.Filters.Add<ActionFilter>();
    })
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache(); // ใช้ใน CardReaderHub.HeartBeatInterval()

// ======================
// Distributed Cache (Session backing store)
// ======================
if (useRedis && redis != null)
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = redisConn;
        options.InstanceName  = cookieName + ":Session:";
    });
else
    builder.Services.AddDistributedMemoryCache();

// ======================
// Session
// ======================
builder.Services.AddSession(options =>
{
    options.IdleTimeout        = TimeSpan.FromHours(timeout);
    options.Cookie.Name        = cookieName;
    options.Cookie.HttpOnly    = true;
    options.Cookie.IsEssential = true;
    options.Cookie.MaxAge      = TimeSpan.FromDays(1);
});

// ======================
// Authentication / Cookie
// ======================
builder.Services.AddAuthentication("Cookies").AddCookie(options =>
{
    options.LoginPath         = "/Login";
    options.LogoutPath        = "/Logout";
    options.AccessDeniedPath  = "/AccessDenied";
    options.ExpireTimeSpan    = TimeSpan.FromHours(timeout);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly   = true;
});

// ======================
// DataProtection (keys shared ข้าม instance ผ่าน Redis)
// ======================
var dp = builder.Services
    .AddDataProtection()
    .SetApplicationName(cookieName);

if (useRedis && redis != null)
    dp.PersistKeysToStackExchangeRedis(redis, cookieName + ":DataProtection:Keys");

// ======================
// Database
// ======================
builder.Services.AddDbContext<KioskContext>(options =>
    options.ConfigureFromEnvOrAppSettings(builder.Configuration));

// ======================
// CORS
// ======================
builder.Services.AddCors(options =>
{
    options.AddPolicy("DynamicOriginPolicy", policy =>
        policy
            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

// ======================
// SignalR (+ Redis backplane สำหรับ multi-instance)
// ======================
var signalR = builder.Services.AddSignalR();
if (useRedis)
    signalR.AddStackExchangeRedis(redisConn!, options =>
    {
        options.Configuration.ChannelPrefix =
            new RedisChannel(cookieName + ":SignalR", RedisChannel.PatternMode.Literal);
    });

// ======================
// Forwarded Headers (Docker / nginx reverse proxy)
// ======================
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// ======================
// Build App
// ======================
var app = builder.Build();

Console.WriteLine($"🌐 Starting N-ThaiSmartWeb {BuildVersion.Value} @ {DateTime.Now} on {Environment.MachineName}");

var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
NSDXHttpContextHelpers.HttpContextAccessor = httpContextAccessor;

// ======================
// Middleware Pipeline
// ======================
app.UseForwardedHeaders(); // ต้องอยู่บนสุด

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// เสิร์ฟไฟล์ทุกประเภท (.shard1, .bin, face-api model ฯลฯ)
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType    = "application/octet-stream"
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "N-ThaiSmart API v1");
    c.RoutePrefix = "swagger";
    c.DefaultModelsExpandDepth(-1);
});

app.UseRouting();
app.UseCors("DynamicOriginPolicy");

app.UseSession();
app.UseAuthentication(); // ต้องอยู่ก่อน UseAuthorization เสมอ
app.UseAuthorization();

app.UseStatusCodePages();

// ======================
// Endpoint Routing
// ======================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<CardReaderHub>("/NThaiSmartHub");

app.Run();
