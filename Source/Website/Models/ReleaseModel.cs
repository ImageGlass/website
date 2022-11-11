#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

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
    public string ReleaseType { get; set; } = ImageGlass.Models.ReleaseType.Kobe;
    [Column(TypeName = "text")]
    public string Version { get; set; } = string.Empty;

    [Column(TypeName = "text")]
    public string Requirements { get; set; } = string.Empty;

    public List<DownloadModel> BinaryFiles { get; set; }

}

public static class ReleaseType
{
    public static string Kobe => "kobe";
    public static string Moon => "moon";
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
        ReleaseType = model.ReleaseType;
        Version = model.Version;
        Requirements = model.Requirements;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;

        BinaryFiles = model.BinaryFiles
            .Where(i => !preview || i.IsVisible)
            .Select(i => new DownloadModel(i))
            .ToList();
    }

}

