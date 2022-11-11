#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class ExtensionIconModel : BaseModel
{
    [Key]
    public int ExtensionIconId { get; set; }
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


    // show in view details
    public List<ThemeImageModel> ThemeImages { get; set; }
}


public class VExtensionIcon
{
    public int ExtensionIconId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public int Count { get; set; } = 0;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    /// <summary>
    /// Posted within <c>7*24</c> hours.
    /// </summary>
    public bool IsNewPost => (DateTime.Now - CreatedDate).TotalHours <= (7 * 24);

    public VExtensionIcon() { }

    public VExtensionIcon(ExtensionIconModel model)
    {
        ExtensionIconId = model.ExtensionIconId;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        Description = model.Description;
        Link = model.Link;
        Version = model.Version;
        Author = model.Author;
        Email = model.Email;
        Website = model.Website;
        Count = model.Count;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }
}

public class VExtensionIconDetails
{
    public int ExtensionIconId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public int Count { get; set; } = 0;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public VExtensionIconDetails() { }

    public VExtensionIconDetails(ExtensionIconModel model, bool preview = false)
    {
        ExtensionIconId = model.ExtensionIconId;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        Description = model.Description;
        Link = model.Link;
        Version = model.Version;
        Author = model.Author;
        Email = model.Email;
        Website = model.Website;
        Count = model.Count;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }
}
