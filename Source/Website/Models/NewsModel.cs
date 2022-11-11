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


public class VNews
{
    public int Id { get; set; }
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

    /// <summary>
    /// By default, the content will be fetched from this folder:
    /// https://github.com/ImageGlass/website-content/tree/main/news/.
    /// This field allows to use a custom url markdown content.
    /// </summary>
    public string CustomContentUrl { get; set; } = string.Empty;


    public VNews() { }

    public VNews(NewsModel model)
    {
        Id = model.Id;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        Description = model.Description;
        CustomContentUrl = model.CustomContentUrl;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }
}


public class VNewsDetails
{
    public int Id { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    /// <summary>
    /// By default, the content will be fetched from this folder:
    /// https://github.com/ImageGlass/website-content/tree/main/news/.
    /// This field allows to use a custom url markdown content.
    /// </summary>
    public string CustomContentUrl { get; set; } = string.Empty;

    public VNewsDetails() { }

    public VNewsDetails(NewsModel model)
    {
        Id = model.Id;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        Description = model.Description;
        CustomContentUrl = model.CustomContentUrl;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }
}
