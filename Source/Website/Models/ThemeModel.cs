#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlassWeb.Models;

public class ThemeModel : ArticleBaseModel
{
    [Column(Order = 4, TypeName = "varchar(300)")]
    public string Description { get; set; } = string.Empty;


    [Column(Order = 5, TypeName = "varchar(255)")]
    public string Image { get; set; } = string.Empty;


    [Column(Order = 6, TypeName = "varchar(255)")]
    public string Link { get; set; } = string.Empty;


    [Column(Order = 7)]
    public bool IsDarkMode { get; set; } = true;


    [Column(Order = 8, TypeName = "varchar(20)")]
    public string Version { get; set; } = string.Empty;


    [Column(Order = 9, TypeName = "varchar(50)")]
    public string Compatibility { get; set; } = string.Empty;


    [Column(Order = 10, TypeName = "varchar(50)")]
    public string Author { get; set; } = string.Empty;


    [Column(Order = 11, TypeName = "varchar(50)")]
    public string Email { get; set; } = string.Empty;


    [Column(Order = 12, TypeName = "varchar(255)")]
    public string Website { get; set; } = string.Empty;


    [Column(Order = 13)]
    public int Count { get; set; } = 0;
}
