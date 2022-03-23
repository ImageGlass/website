#nullable disable
using Microsoft.EntityFrameworkCore;
using ImageGlass.Models;

namespace ImageGlass.Data;

public class ImageGlassContext : DbContext
{
    public ImageGlassContext (DbContextOptions<ImageGlassContext> options)
        : base(options)
    {
    }

    public DbSet<NewsModel> News { get; set; }
    public DbSet<ThemeModel> Themes { get; set; }
    public DbSet<ThemeImageModel> ThemeImages { get; set; }

    public DbSet<ReleaseModel> Releases { get; set; }
    public DbSet<ReleaseImageModel> ReleaseImages { get; set; }
    public DbSet<DownloadModel> Downloads { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
