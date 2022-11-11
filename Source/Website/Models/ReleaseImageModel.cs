#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class ReleaseImageModel : BaseModel
{
    [Key]
    public int ReleaseImageId { get; set; }
    [Column(TypeName = "text")]
    public string Link { get; set; } = string.Empty;


    public int Id { get; set; }
    public ReleaseModel Release { get; set; }
}


public class VReleaseImageDetails
{
    public int ReleaseImageId { get; set; }
    public string Link { get; set; } = string.Empty;

    public VReleaseImageDetails() { }

    public VReleaseImageDetails(ReleaseImageModel model)
    {
        ReleaseImageId = model.ReleaseImageId;
        Link = model.Link;
    }
}
