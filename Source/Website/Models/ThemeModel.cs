#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ImageGlass.Models;

public class ThemeModel : BaseModel
{
    [Key]
    public int ThemeId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Compatibility { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public int Count { get; set; } = 0;


    public List<ThemeImageModel> ThemeImages { get; set; }
}
