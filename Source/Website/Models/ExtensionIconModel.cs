#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class ExtensionIconModel : BaseModel
{
    [Column(TypeName = "text")]
    public string Slug { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Title { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Image { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Description { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Link { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Version { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Author { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Email { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Website { get; set; } = string.Empty;
    public int Count { get; set; } = 0;
}
