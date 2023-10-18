#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlassWeb.Models;

public class ArticleBaseModel : BaseModel
{
    [Column(TypeName = "text")]
    public string Slug { get; set; } = string.Empty;


    [Column(TypeName = "text")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the string combined with <see cref="Slug"/> and <see cref="Id"/>.
    /// </summary>
    public string SlugAndId => $"{Slug}-{Id}";

}
