#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ImageGlass.Models;

public class ReleaseModel : BaseModel
{
    [Column(TypeName = "text")]
    public string Slug { get; set; } = string.Empty;


    [Column(TypeName = "text")]
    public string Title { get; set; } = string.Empty;


    [Column(TypeName = "text")]
    public string Image { get; set; } = string.Empty;


    [Column(TypeName = "text")]
    public string ReleaseChannel { get; set; } = ImageGlass.Models.ReleaseChannel.Stable;


    [Column(TypeName = "text")]
    public string Version { get; set; } = string.Empty;


    [AllowNull]
    public int? NewsId { get; set; }


    // Foreign key to RequirementModel
    public int RequirementId { get; set; }


    /// <summary>
    /// Gets the string combined with <see cref="Slug"/> and <see cref="Id"/>.
    /// </summary>
    public string SlugAndId => $"{Slug}-{Id}";


    /// <summary>
    /// Gets the total download number of all <see cref="BinaryFiles" />.
    /// </summary>
    public int Count => BinaryFiles.Sum(f => f.Count);


    public List<BinaryFileModel> BinaryFiles { get; set; }


    public RequirementModel Requirement { get; set; }

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
        NewsId = model.NewsId;
        IsVisible = model.IsVisible;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;

        Requirement = model.Requirement;
        BinaryFiles = model.BinaryFiles
            .Where(i => !preview || i.IsVisible)
            .ToList();
    }

}

