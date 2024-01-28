using ImageGlassWeb.Data;
using ImageGlassWeb.Models;
using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageGlassWeb.Controllers;

public class UrlController : BaseController
{
    private readonly ImageGlassContext _context;

    public UrlController(ImageGlassContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Gets update information (v8.6+).
    /// </summary>
    [HttpGet("url/update")]
    public async Task<ActionResult> GetUpdateAsync()
    {
        var updateInfoJsonUrl = "https://raw.githubusercontent.com/ImageGlass/releases/main/update.json";

        using var httpClient = new HttpClient();
        var jsonStr = await httpClient.GetStringAsync(updateInfoJsonUrl);

        return Content(jsonStr, "application/json", Encoding.UTF8);
    }


    /// <summary>
    /// Check for update (legacy versions: v8.5 or below)
    /// </summary>
    [HttpGet("checkforupdate")]
    public async Task<ActionResult> GetUpdateLegacyAsync()
    {
        // featured content
        var releaseList = await _context.QueryReleaseModels(1, releaseChannel: ReleaseChannel.Stable);
        var latestStableRelease = releaseList.FirstOrDefault();


        var xml = $"""
<ImageGlass>
    <Update>
        <Info newVersion="{latestStableRelease?.Version}" versionType="stable" level="Recommended"
            link="https://imageglass.org/news/{latestStableRelease?.News?.SlugAndId}" size="30.7 MB"
            pubDate="{latestStableRelease?.UpdatedDate.ToDateTimeString()}"
            decription="https://imageglass.org/release/{latestStableRelease?.SlugAndId}"/>
    </Update>
</ImageGlass>
""";
        return Content(xml, "text/xml", Encoding.UTF8);
    }
}

