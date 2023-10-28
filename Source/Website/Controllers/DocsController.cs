using IgWebHelper;
using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Mvc;
namespace ImageGlassWeb.Controllers;

public class DocsController : BaseController
{
    private readonly IWebHostEnvironment _appEnv;

    public DocsController(IWebHostEnvironment appEnv)
    {
        _appEnv = appEnv;
    }


    [HttpGet("docs")]
    [ResponseCache(CacheProfileName = "Default")]
    public IActionResult Index()
    {
        return RedirectToAction("DocsPage", new { slug = "features" });
    }


    [HttpGet("docs/{slug?}")]
    [ResponseCache(CacheProfileName = "Default")]
    public async Task<IActionResult> DocsPage(string? slug)
    {
        if (string.IsNullOrWhiteSpace(slug)) return RedirectToAction(nameof(Index));


        // get page content
        var rawHtmlContent = await ContentHelper.GetContentAsync(_appEnv.WebRootPath, @$"Docs\{slug}.html");
        var (metadata, htmlContent) = Helper.ProcessHtmlContent(rawHtmlContent);
        metadata ??= new();


        // page info
        ViewData[PageInfo.Page] = $"docs.{slug}";
        ViewData[PageInfo.Title] = $"{metadata.Title} | ImageGlass Docs";
        ViewData[PageInfo.Description] = metadata.Description;
        ViewData[PageInfo.Keywords] = $"{string.Join(',', metadata.Keywords)}, {ViewData[PageInfo.Keywords]}";


        return View("DocsPage", htmlContent);
    }

}
