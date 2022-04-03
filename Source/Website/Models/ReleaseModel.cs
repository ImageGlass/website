#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ImageGlass.Models;

public class ReleaseModel : BaseModel
{
    [Key]
    public int ReleaseId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string ReleaseType { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    // show in view details
    public string Requirements { get; set; } = string.Empty;

    // show in view details
    public List<DownloadModel> Downloads { get; set; }

    // show in view details
    public List<ReleaseImageModel> ReleaseImages { get; set; }
}


public class VRelease
{
    public int ReleaseId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string ReleaseType { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    /// <summary>
    /// Posted within <c>7*24</c> hours.
    /// </summary>
    public bool IsNewPost => (DateTime.Now - CreatedDate).TotalHours <= (7 * 24);

    public VRelease() { }

    public VRelease(ReleaseModel model)
    {
        ReleaseId = model.ReleaseId;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        ReleaseType = model.ReleaseType;
        Version = model.Version;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }

}


public class VReleaseDetails
{
    public int ReleaseId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string ReleaseType { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Requirements { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public List<VDownloadDetails> Downloads { get; set; }
    public List<VReleaseImageDetails> ReleaseImages { get; set; }


    public VReleaseDetails() { }

    public VReleaseDetails(ReleaseModel model, bool preview = false)
    {
        ReleaseId = model.ReleaseId;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        ReleaseType = model.ReleaseType;
        Version = model.Version;
        Requirements = model.Requirements;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;

        ReleaseImages = model.ReleaseImages
            .Where(i => !preview || i.Visible)
            .Select(i => new VReleaseImageDetails(i))
            .ToList();

        Downloads = model.Downloads
            .Where(i => !preview || i.Visible)
            .Select(i => new VDownloadDetails(i))
            .ToList();
        
    }

}
