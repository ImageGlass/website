using Microsoft.EntityFrameworkCore;
using ImageGlass.Models;
using ImageGlass.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ImageGlass.Data;


public class ImageGlassContext : DbContext
{
    public ImageGlassContext (DbContextOptions<ImageGlassContext> options)
        : base(options) {}


    [AllowNull]
    public DbSet<NewsModel> News { get; set; }
    [AllowNull]
    public DbSet<ThemeModel> Themes { get; set; }
    [AllowNull]
    public DbSet<ThemeImageModel> ThemeImages { get; set; }

    [AllowNull]
    public DbSet<ReleaseModel> Releases { get; set; }
    [AllowNull]
    public DbSet<ReleaseImageModel> ReleaseImages { get; set; }
    [AllowNull]
    public DbSet<DownloadModel> Downloads { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }



    public async Task<PaginatedList<VNews>> GetVNewsItems(int count = 10, int pageNumber = 1)
    {
        var source = News
            .Where(i => i.Visible)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VNews(i))
            .AsNoTracking();

        var pList = await PaginatedList<VNews>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<VNewsDetails?> GetVNewsDetails(int id, bool? preview) {
        var isPreview = preview ?? false;
        var model = await News.Where(i => i.NewsId == id && (isPreview || i.Visible))
            .Select(i => new VNewsDetails(i))
            .FirstOrDefaultAsync();

        return model;
    }



    public async Task<PaginatedList<VRelease>> GetVReleaseItems(string releaseType, int count = 10, int pageNumber = 1)
    {
        var source = Releases
            .Where(i => i.Visible && i.ReleaseType == releaseType)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VRelease(i))
            .AsNoTracking();

        var pList = await PaginatedList<VRelease>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<VReleaseDetails?> GetVReleaseDetails(int id, bool? preview) {
        var isPreview = preview ?? false;
        var model = await Releases
            .Where(i => i.ReleaseId == id && (isPreview || i.Visible))
            .Include(i => i.ReleaseImages)
            .Include(i => i.Downloads)
            .Select(i => new VReleaseDetails(i, isPreview))
            .FirstOrDefaultAsync();

        return model;
    }


    public async Task<PaginatedList<VTheme>> GetVThemeItems(string themeType, int count = 10, int pageNumber = 1)
    {
        var source = Themes
            .Where(i => i.Visible && i.ThemeType == themeType)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VTheme(i))
            .AsNoTracking();

        var pList = await PaginatedList<VTheme>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<VThemeDetails?> GetVThemeDetails(int id, bool? preview) {
        var isPreview = preview ?? false;
        var model = await Themes
            .Where(i => i.ThemeId == id && (isPreview || i.Visible))
            .Include(i => i.ThemeImages)
            .Select(i => new VThemeDetails(i, isPreview))
            .FirstOrDefaultAsync();

        return model;
    }

}
