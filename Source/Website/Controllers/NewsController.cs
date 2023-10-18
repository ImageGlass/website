using Microsoft.AspNetCore.Mvc;
using ImageGlassWeb.Data;
using ImageGlassWeb.Utils;

namespace ImageGlassWeb.Controllers;

public class NewsController : BaseController
{
    private readonly ImageGlassContext _context;
    private readonly IWebHostEnvironment _appEnv;


    public NewsController(ImageGlassContext context, IWebHostEnvironment appEnv)
    {
        _context = context;
        _appEnv = appEnv;
    }


    [HttpGet("news")]
    public async Task<IActionResult> AllNewsListingPage(int? page)
    {
        // page info
        ViewData[PageInfo.Page] = "news";
        ViewData[PageInfo.Title] = $"Latest updates | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "Get the lastest updates of ImageGlass. Read ImageGlass stories and everything in the world.";
        ViewData[PageInfo.Keywords] = $"imageglass lastest update, imageglass {DateTime.UtcNow.Year}, {ViewData[PageInfo.Keywords]}";

        // get news items
        var pList = await _context.QueryNewsModels(12, page ?? 1);

        return View("NewsListingPage", pList);
    }


    [HttpGet("news/{slugId}")]
    [ResponseCache(CacheProfileName = "Default")]
    public async Task<IActionResult> NewsDetailPage(string? slugId, bool? preview)
    {
        var id = GetIdFromSlugId(slugId);
        if (id is null) return NotFound();

        var model = await _context.GetNewsModel(id.Value, preview);
        if (model == null) return NotFound();

        // page info
        ViewData[PageInfo.Page] = "news";
        ViewData[PageInfo.Title] = $"{model.Title} | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = model.Description;
        ViewData[PageInfo.Thumbnail] = model.Image;
        ViewData[PageInfo.H1] = string.Empty; // use the content H1

        ViewData[PageInfo.SidebarList] = await _context.QueryNewsModels(5);

        // get page content
        ViewData["NewsHtmlContent"] = await ContentHelper.GetContentAsync(@$"News\{model.Id}.html");


        return View("NewsDetailPage", model);
    }

}
