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
    public DbSet<ExtensionIconModel> ExtensionIcons { get; set; }

    [AllowNull]
    public DbSet<ReleaseModel> Releases { get; set; }

    [AllowNull]
    public DbSet<BinaryFileModel> BinaryFiles { get; set; }

    [AllowNull]
    public DbSet<RequirementModel> Requirements { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }



    public async Task<PaginatedList<NewsModel>> QueryNewsModels(int count = 10, int pageNumber = 1)
    {
        var source = News
            .Where(i => i.IsVisible)
            .OrderByDescending(i => i.UpdatedDate)
            .AsNoTracking();

        var pList = await PaginatedList<NewsModel>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<NewsModel?> GetNewsModel(int id, bool? preview) {
        var isPreview = preview ?? false;
        var model = await News.Where(i => i.Id == id && (isPreview || i.IsVisible))
            .FirstOrDefaultAsync();

        return model;
    }


    public async Task<PaginatedList<ReleaseModel>> QueryReleaseModels(string releaseChannel, int count = 10, int pageNumber = 1)
    {
        var source = Releases
            .Where(i => i.IsVisible && i.ReleaseChannel == releaseChannel)
            .OrderByDescending(i => i.CreatedDate)
            .AsNoTracking();

        var pList = await PaginatedList<ReleaseModel>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<ReleaseDetailModel?> GetReleaseDetailModel(int id, bool? preview) {
        var isPreview = preview ?? false;
        var model = await Releases
            .Where(i => i.Id == id && (isPreview || i.IsVisible))
            .Include(i => i.BinaryFiles)
            .Select(i => new ReleaseDetailModel(i, isPreview))
            .FirstOrDefaultAsync();

        return model;
    }


    public async Task<PaginatedList<ThemeModel>> QueryThemeModels(int count = 10, int pageNumber = 1)
    {
        var source = Themes
            .Where(i => i.IsVisible)
            .OrderByDescending(i => i.UpdatedDate)
            .AsNoTracking();

        var pList = await PaginatedList<ThemeModel>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<ThemeModel?> GetThemeModel(int id, bool? preview) {
        var isPreview = preview ?? false;
        var model = await Themes
            .Where(i => i.Id == id && (isPreview || i.IsVisible))
            .FirstOrDefaultAsync();

        return model;
    }


    public async Task<PaginatedList<ExtensionIconModel>> QueryExtensionIconModels(int count = 10, int pageNumber = 1)
    {
        var source = ExtensionIcons
            .Where(i => i.IsVisible)
            .OrderByDescending(i => i.UpdatedDate)
            .AsNoTracking();

        var pList = await PaginatedList<ExtensionIconModel>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<ExtensionIconModel?> GetExtensionIconModel(int id, bool? preview) {
        var isPreview = preview ?? false;
        var model = await ExtensionIcons
            .Where(i => i.Id == id && (isPreview || i.IsVisible))
            .FirstOrDefaultAsync();

        return model;
    }

}
