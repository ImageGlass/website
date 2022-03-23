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
    public string Requirements { get; set; } = string.Empty;


    public List<DownloadModel> Downloads { get; set; }
}
