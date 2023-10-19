#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlassWeb.Models;

public class ArticleBaseModel : BaseModel
{
    [Column(Order = 2, TypeName = "varchar(80)")]
    public string Slug { get; set; } = string.Empty;


    [Column(Order = 3, TypeName = "varchar(150)")]
    public string Title { get; set; } = string.Empty;


    /// <summary>
    /// Gets the string combined with <see cref="Slug"/> and <see cref="Id"/>.
    /// </summary>
    public string SlugAndId => $"{Slug}-{Id}";

}
