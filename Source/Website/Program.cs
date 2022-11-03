using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ImageGlass.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ImageGlassContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ImageGlassContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(i => i.LowercaseUrls = true);

var app = builder.Build();


// migrate database on startup
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<ImageGlassContext>();
if (db is not null)
{
    await db.Database.MigrateAsync();
}


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
