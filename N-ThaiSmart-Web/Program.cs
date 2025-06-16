using N_ThaiSmart_Web.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5201");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DynamicOriginPolicy", policy =>
    {
        policy
            .SetIsOriginAllowed(origin => true) // <--- ����Ѻ�ء Origin
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // ��Ѻ Cookie/Auth ��
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("DynamicOriginPolicy");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<CardReaderHub>("/NThaiSmartHub");

app.Run();