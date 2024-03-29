using ImageGlassWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ImageGlassContext");


// use MySql DB
builder.Services.AddDbContext<ImageGlassContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options =>
    {
        options.EnableRetryOnFailure(3);
    }));


// Add services to the container
builder.Services.AddResponseCaching();
builder.Services.AddControllersWithViews(options =>
{
    options.CacheProfiles.Add("Default", new CacheProfile()
    {
        Duration = 60 * 60 * 24, // 24 hour
        VaryByHeader = "User-Agent",
    });
});
builder.Services.AddRouting();

var app = builder.Build();


// migrate database on startup
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<ImageGlassContext>();
if (db is not null)
{
    await db.Database.MigrateAsync();
}


// DEV configs
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePagesWithReExecute("/error/{0}");
}
// PROD configs
else
{
    app.UseExceptionHandler("/error/handle-exception");
    app.UseStatusCodePagesWithReExecute("/error/{0}");

    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.UseStatusCodePages();
app.UseResponseCaching();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{slugId?}");


app.Run();
