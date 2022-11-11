#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class NewsModel : BaseModel
{
    [Required]
    [Column(TypeName = "text")]
    public string Slug { get; set; }
    [Column(TypeName = "text")]
    public string Title { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Image { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// By default, the content will be fetched from this folder:
    /// https://github.com/ImageGlass/website-content/tree/main/news/.
    /// This field allows to use a custom url markdown content.
    /// </summary>
    public string CustomContentUrl { get; set; } = string.Empty;
}
