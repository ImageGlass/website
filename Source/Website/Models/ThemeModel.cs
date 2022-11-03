#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGlass.Models;

public class ThemeModel : BaseModel
{
    [Key]
    public int ThemeId { get; set; }
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
    public string Compatibility { get; set; } = string.Empty;
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


public class VTheme
{
    public int ThemeId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Compatibility { get; set; } = string.Empty;
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

    public VTheme() { }

    public VTheme(ThemeModel model)
    {
        ThemeId = model.ThemeId;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        Description = model.Description;
        Link = model.Link;
        Version = model.Version;
        Compatibility = model.Compatibility;
        Author = model.Author;
        Email = model.Email;
        Website = model.Website;
        Count = model.Count;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;
    }
}

public class VThemeDetails
{
    public int ThemeId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Compatibility { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public int Count { get; set; } = 0;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }


    public List<VThemeImageDetails> ThemeImages { get; set; }


    public VThemeDetails() { }

    public VThemeDetails(ThemeModel model, bool preview = false)
    {
        ThemeId = model.ThemeId;
        Slug = model.Slug;
        Title = model.Title;
        Image = model.Image;
        Description = model.Description;
        Link = model.Link;
        Version = model.Version;
        Compatibility = model.Compatibility;
        Author = model.Author;
        Email = model.Email;
        Website = model.Website;
        Count = model.Count;
        CreatedDate = model.CreatedDate;
        UpdatedDate = model.UpdatedDate;

        ThemeImages = model.ThemeImages
            .Where(i => !preview || i.Visible)
            .Select(i => new VThemeImageDetails(i))
            .ToList();
    }
}
