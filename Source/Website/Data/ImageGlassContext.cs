using ImageGlassWeb.Models;
using ImageGlassWeb.Utils;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ImageGlassWeb.Data;


public class ImageGlassContext : DbContext
{
    public ImageGlassContext(DbContextOptions<ImageGlassContext> options)
        : base(options) { }


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


    protected override void OnModelCreating(ModelBuilder mb)
    {
        // set default values
        mb.Entity<NewsModel>().Property(i => i.IsVisible).HasDefaultValue(true);
        mb.Entity<NewsModel>().Property(i => i.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<NewsModel>().Property(i => i.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

        mb.Entity<ThemeModel>().Property(i => i.IsVisible).HasDefaultValue(true);
        mb.Entity<ThemeModel>().Property(i => i.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<ThemeModel>().Property(i => i.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<ThemeModel>().Property(i => i.Count).HasDefaultValue(0);

        mb.Entity<ExtensionIconModel>().Property(i => i.IsVisible).HasDefaultValue(true);
        mb.Entity<ExtensionIconModel>().Property(i => i.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<ExtensionIconModel>().Property(i => i.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<ExtensionIconModel>().Property(i => i.Count).HasDefaultValue(0);

        mb.Entity<ReleaseModel>().Property(i => i.IsVisible).HasDefaultValue(true);
        mb.Entity<ReleaseModel>().Property(i => i.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<ReleaseModel>().Property(i => i.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

        mb.Entity<BinaryFileModel>().Property(i => i.IsVisible).HasDefaultValue(true);
        mb.Entity<BinaryFileModel>().Property(i => i.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<BinaryFileModel>().Property(i => i.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<BinaryFileModel>().Property(i => i.Count).HasDefaultValue(0);

        mb.Entity<RequirementModel>().Property(i => i.IsVisible).HasDefaultValue(true);
        mb.Entity<RequirementModel>().Property(i => i.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        mb.Entity<RequirementModel>().Property(i => i.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

        base.OnModelCreating(mb);
    }



    public async Task<PaginatedList<NewsModel>> QueryNewsModels(int count = 10, int pageNumber = 1)
    {
        var source = News
            .Where(i => i.IsVisible == true)
            .OrderByDescending(i => i.UpdatedDate)
            .AsNoTracking();

        var pList = await PaginatedList<NewsModel>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<NewsModel?> GetNewsModel(int id, bool? preview)
    {
        var isPreview = preview ?? false;
        var model = await News.Where(i => i.Id == id && (isPreview || (i.IsVisible ?? false)))
            .FirstOrDefaultAsync();

        return model;
    }


    public async Task<PaginatedList<ReleaseModel>> QueryReleaseModels(int count = 10, int pageNumber = 1, string? releaseChannel = "")
    {
        var source = Releases
            .Where(i => i.IsVisible == true
                && (string.IsNullOrEmpty(releaseChannel)
                    || i.ReleaseChannel == releaseChannel))
            .Include(i => i.News)
            .OrderByDescending(i => i.CreatedDate)
            .AsNoTracking();

        var pList = await PaginatedList<ReleaseModel>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<ReleaseDetailModel?> GetReleaseDetailModel(int id, bool? preview)
    {
        var isPreview = preview ?? false;
        var model = await Releases
            .Where(i => i.Id == id && (isPreview || (i.IsVisible ?? false)))
            .Include(i => i.BinaryFiles.Where(f => f.IsVisible == true))
            .Include(i => i.Requirement)
            .Include(i => i.News)
            .Select(i => new ReleaseDetailModel(i, isPreview))
            .FirstOrDefaultAsync();

        return model;
    }


    public async Task<BinaryFileModel?> GetBinaryFileModel(int id, bool? preview)
    {
        var isPreview = preview ?? false;
        var model = await BinaryFiles
            .Where(i => i.Id == id && (isPreview || (i.IsVisible ?? false)))
            .FirstOrDefaultAsync();

        return model;
    }


    public async Task<PaginatedList<ThemeModel>> QueryThemeModels(int count = 10, int pageNumber = 1)
    {
        var source = Themes
            .Where(i => i.IsVisible == true)
            .OrderByDescending(i => i.UpdatedDate)
            .AsNoTracking();

        var pList = await PaginatedList<ThemeModel>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<ThemeModel?> GetThemeModel(int id, bool? preview)
    {
        var isPreview = preview ?? false;
        var model = await Themes
            .Where(i => i.Id == id && (isPreview || (i.IsVisible ?? false)))
            .FirstOrDefaultAsync();

        return model;
    }


    public async Task<PaginatedList<ExtensionIconModel>> QueryExtensionIconModels(int count = 10, int pageNumber = 1)
    {
        var source = ExtensionIcons
            .Where(i => i.IsVisible == true)
            .OrderByDescending(i => i.UpdatedDate)
            .AsNoTracking();

        var pList = await PaginatedList<ExtensionIconModel>
            .CreateAsync(source, pageNumber, count);

        return pList;
    }


    public async Task<ExtensionIconModel?> GetExtensionIconModel(int id, bool? preview)
    {
        var isPreview = preview ?? false;
        var model = await ExtensionIcons
            .Where(i => i.Id == id && (isPreview || (i.IsVisible ?? false)))
            .FirstOrDefaultAsync();

        return model;
    }

}
