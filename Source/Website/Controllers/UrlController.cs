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

        // get the source version
        _ = Request.Query.TryGetValue("version", out var paramVersions);
        var fromVersion = paramVersions.FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(fromVersion))
        {
            var srcVersion = new Version(fromVersion);

            // only update v8.11- to v8.12
            if (srcVersion < new Version("8.12"))
            {
                jsonStr = """
                {
                    "apiVersion": 1.1,
                    "releases": {
                        "kobe": {
                            "version": "8.12.4.30",
                            "title": "ImageGlass 8.12 Update - The Last ImageGlass 8",
                            "description": "Small & the last update for version 8. It's recommended to switch to ImageGlass 9 to access the latest features and improvements.",
                            "changelogUrl": "https://imageglass.org/news/announcing-imageglass-8-12-the-last-imageglass-8-90",
                            "publishedDate": "2024/04/28 23:12:11"
                        },
                        "moon": {
                            "version": "8.12.4.30",
                            "title": "ImageGlass 8.12 Update - The Last ImageGlass 8",
                            "description": "Small & the last update for version 8. It's recommended to switch to ImageGlass 9 to access the latest features and improvements.",
                            "changelogUrl": "https://imageglass.org/news/announcing-imageglass-8-12-the-last-imageglass-8-90",
                            "publishedDate": "2024/04/28 23:12:11"
                        },
                        "spider": {
                            "version": "8.12.4.30",
                            "title": "ImageGlass 8.12 Update - The Last ImageGlass 8",
                            "description": "Small & the last update for version 8. It's recommended to switch to ImageGlass 9 to access the latest features and improvements.",
                            "changelogUrl": "https://imageglass.org/news/announcing-imageglass-8-12-the-last-imageglass-8-90",
                            "publishedDate": "2024/04/28 23:12:11"
                        }
                    }
                }
                """;
            }
        }

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

