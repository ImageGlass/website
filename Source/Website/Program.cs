using Microsoft.EntityFrameworkCore;
using ImageGlassWeb.Data;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ImageGlassContext");


// use MySql DB
builder.Services.AddDbContext<ImageGlassContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Add services to the container
builder.Services.AddResponseCaching();
builder.Services.AddControllersWithViews(options => {
    options.CacheProfiles.Add("Default", new CacheProfile()
    {
        Duration = 3600,
        VaryByHeader = "User-Agent",
    });
});
builder.Services.AddRouting(i => i.LowercaseUrls = true);

var app = builder.Build();


// migrate database on startup
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<ImageGlassContext>();
if (db is not null)
{
    await db.Database.MigrateAsync();
}


// Production configs
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseResponseCaching();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{slugId?}");


app.Run();
