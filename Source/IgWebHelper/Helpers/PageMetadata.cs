
namespace IgWebHelper;

public class PageMetadata
{
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] Keywords { get; set; } = Array.Empty<string>();
    public bool Visible { get; set; }
}

