#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class NewsModel : BaseModel
{
    [Key]
    public int NewsId { get; set; }
    [Required]
    [Column(TypeName = "text")]
    public string Slug { get; set; }
    [Column(TypeName = "text")]
    public string Title { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Image { get; set; } = string.Empty;
    [Column(TypeName = "text")]
    public string Description { get; set; } = string.Empty;

    // show in view details
    public string Content { get; set; } = string.Empty;
}

public class VNews
{
    public int NewsId { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    /// <summary>
    /// Posted within <c>7*24</c> hours.
    /// </summary>
    public bool IsNewPost => (DateTime.Now - CreatedDate).TotalHours <= (7 * 24);

    public VNews() { }

    public VNews(NewsModel model)
    {
        NewsId = model.NewsId;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        Description = model.Description;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }
}

public class VNewsDetails
{
    public int NewsId { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public VNewsDetails() { }

    public VNewsDetails(NewsModel model)
    {
        NewsId = model.NewsId;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        Description = model.Description;
        Content = model.Content;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }
}
