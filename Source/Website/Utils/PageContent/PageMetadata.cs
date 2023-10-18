#nullable disable
namespace ImageGlassWeb.Utils;

public class PageMetadata
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string[] Keywords { get; set; }
    public bool Visible { get; set; }
}

