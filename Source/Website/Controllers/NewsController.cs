using Microsoft.AspNetCore.Mvc;
using ImageGlass.Data;
using ImageGlass.Utils;

namespace ImageGlass.Controllers;

public class NewsController : BaseController
{
    private readonly ImageGlassContext _context;

    
    public NewsController(ImageGlassContext context)
    {
        _context = context;
    }


    [HttpGet("news")]
    public async Task<IActionResult> Index(int? page)
    {
        // page info
        ViewData[PageInfo.Title] = $"Latest updates | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "Get the lastest updates of ImageGlass. Read ImageGlass stories and everything in the world.";
        ViewData[PageInfo.Keywords] = $"imageglass lastest update, imageglass {DateTime.UtcNow.Year}, {ViewData[PageInfo.Keywords]}";

        // get news items
        var pList = await _context.QueryNewsModels(10, page ?? 1);

        return View("NewsListingPage", pList);
    }


    [HttpGet("news/{slugId}")]
    public async Task<IActionResult> NewsDetailPage(string? slugId, bool? preview)
    {
        var id = GetIdFromSlugId(slugId);
        if (id is null) return NotFound();

        var model = await _context.GetNewsModel(id.Value, preview);
        if (model == null) return NotFound();

        // page info
        ViewData[PageInfo.Title] = model.Title;
        ViewData[PageInfo.Description] = model.Description;
        ViewData[PageInfo.Thumbnail] = model.Image;
        ViewData[PageInfo.H1] = string.Empty; // use the content H1

        // get page content from GitHub
        var markdownContent = await GitHub.GetFileContentAsync($"news/{model.Id}.md");
        var htmlContent = GitHub.ParseMarkdown(markdownContent);

        ViewData["NewsHtmlContent"] = htmlContent;

        return View("NewsDetailPage", model);
    }

}
