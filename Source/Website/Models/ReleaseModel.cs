#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ImageGlassWeb.Models;

public class ReleaseModel : ArticleBaseModel
{
    [Column(Order = 4, TypeName = "varchar(255)")]
    public string Image { get; set; } = string.Empty;


    [AllowNull]
    [Column(Order = 5)]
    public int? NewsId { get; set; }


    [Column(Order = 6, TypeName = "varchar(20)")]
    public string Version { get; set; } = string.Empty;


    [Column(Order = 7, TypeName = "varchar(50)")]
    public string ReleaseChannel { get; set; } = Models.ReleaseChannel.Stable;


    /// <summary>
    /// Folder name of screenshots.
    /// E.g. <c>v9.0-beta-4</c>
    ///     from <c>v9.0-beta-4</c>
    /// </summary>
    [Column(Order = 8, TypeName = "varchar(50)")]
    public string ScreenshotsDir { get; set; } = string.Empty;


    // Foreign key to RequirementModel
    [Column(Order = 9)]
    public int RequirementId { get; set; }



    /// <summary>
    /// Gets the total download number of all <see cref="BinaryFiles" />.
    /// </summary>
    public int Count => BinaryFiles?.Sum(f => f.Count) ?? 0;


    public List<BinaryFileModel> BinaryFiles { get; set; }


    public RequirementModel Requirement { get; set; }


#nullable enable
    public NewsModel? News { get; set; }
#nullable disable
}


public static class ReleaseChannel
{
    public static string Stable => "stable";
    public static string Beta => "beta";
}


public class ReleaseDetailModel : ReleaseModel
{
    public ReleaseDetailModel() { }

    public ReleaseDetailModel(ReleaseModel model, bool preview = false)
    {
        Id = model.Id;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        ReleaseChannel = model.ReleaseChannel;
        Version = model.Version;
        ScreenshotsDir = model.ScreenshotsDir;
        NewsId = model.NewsId;
        IsVisible = model.IsVisible;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;

        Requirement = model.Requirement;
        News = model.News;
        BinaryFiles = model.BinaryFiles
            .Where(i => !preview || (i.IsVisible ?? false))
            .ToList();
    }

}

