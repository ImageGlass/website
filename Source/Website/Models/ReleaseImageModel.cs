#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ImageGlass.Models;

public class ReleaseImageModel : BaseModel
{
    [Key]
    public int ReleaseImageId { get; set; }
    public string Link { get; set; } = string.Empty;


    public int ReleaseId { get; set; }
    public ReleaseModel Release { get; set; }
}
