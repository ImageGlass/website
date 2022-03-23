#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ImageGlass.Models;

public class ThemeImageModel : BaseModel
{
    [Key]
    public int ThemeImageId { get; set; }
    public string Link { get; set; } = string.Empty;


    public int ThemeId { get; set; }
    public ThemeModel Theme { get; set; }
}
