#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class ThemeImageModel : BaseModel
{
    [Key]
    public int ThemeImageId { get; set; }
    [Column(TypeName = "text")]
    public string Link { get; set; } = string.Empty;


    public int ThemeId { get; set; }
    public ThemeModel Theme { get; set; }
}


public class VThemeImageDetails
{
    public int ThemeImageId { get; set; }
    public string Link { get; set; } = string.Empty;


    public VThemeImageDetails() { }

    public VThemeImageDetails(ThemeImageModel model) {
        ThemeImageId = model.ThemeImageId;
        Link = model.Link;
    }
}
