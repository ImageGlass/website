#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlassWeb.Models;

public class NewsModel : ArticleBaseModel
{
    [Column(Order = 4, TypeName = "varchar(300)")]
    public string Description { get; set; } = string.Empty;


    [Column(Order = 5, TypeName = "varchar(255)")]
    public string Image { get; set; } = string.Empty;

}
