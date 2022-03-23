#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ImageGlass.Models;

public class NewsModel : BaseModel
{
    [Key]
    public int NewsId { get; set; }
    [Required]
    public string Slug { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

}
