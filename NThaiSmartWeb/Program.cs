using NThaiSmartWeb.EFModels;

var builder = WebApplication.CreateBuilder(args);

// ======================
// Add Services
// ======================

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();  // สำหรับ Endpoint API
builder.Services.AddSwaggerGen();           // สำหรับ Swagger UI

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbContext<KioskContext>(options => DbContextConfigHelper.ConfigureFromEnvOrAppSettings(options, builder.Configuration));

// CORS Policy แบบเปิดทุก origin (ระวังใช้ใน Production ควรระบุ origin ให้เจาะจง)
builder.Services.AddCors(options =>
{
    options.AddPolicy("DynamicOriginPolicy", policy =>
    {
        policy
            .SetIsOriginAllowed(origin => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// 🔧 Print build version
Console.WriteLine($"🔧 Build Version: {BuildVersion.Value}");

// ======================
// Build App
// ======================
var app = builder.Build();

// ✅ ตรงนี้คือ log ตอนเริ่มต้น runtime
Console.WriteLine($"🌐 Starting N-ThaiSmartWeb {BuildVersion.Value} @ {DateTime.Now} on {Environment.MachineName}");

// ======================
// Middleware Pipeline
// ======================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
// ✅ ใส่แบบนี้เพื่อเสิร์ฟ .shard1, .bin หรือไฟล์ไม่มีนามสกุล
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true, // สำคัญมาก!
    DefaultContentType = "application/octet-stream"
});

app.UseRouting();
app.UseCors("DynamicOriginPolicy");

app.UseAuthorization();

// ✅ Swagger เฉพาะ Dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "N-ThaiSmart API v1");
        c.RoutePrefix = "swagger";
    });
}

// ======================
// Endpoint Routing
// ======================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<CardReaderHub>("/NThaiSmartHub");

app.Run();