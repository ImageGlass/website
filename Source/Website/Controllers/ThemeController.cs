using Microsoft.AspNetCore.Mvc;
using ImageGlass.Data;
using ImageGlass.Models;
using ImageGlass.Utils;

namespace ImageGlass.Controllers;

public class ThemeController : BaseController
{
    private readonly ImageGlassContext _context;

    public ThemeController(ImageGlassContext context)
    {
        _context = context;
    }


    [HttpGet("themes")]
    public async Task<IActionResult> ThemePackListingPage(int? page)
    {
        // page info
        ViewData[PageInfo.Page] = "download.theme";
        ViewData[PageInfo.Title] = $"Theme packs | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "The beautiful theme packs to change the look and feel of ImageGlass";
        ViewData[PageInfo.Keywords] = $"imageglass theme, monochrome theme, colorful theme, windows 11 theme, windows 10 theme, dark mode, {ViewData[PageInfo.Keywords]}";

        var pList = await _context.QueryThemeModels(10, page ?? 1);

        return View("ThemeListingPage", pList);
    }


    [HttpGet("theme/{slugId}")]
    public async Task<IActionResult> ThemeDetailPage(string? slugId, bool? preview)
    {
        var id = GetIdFromSlugId(slugId);
        if (id is null) return NotFound();

        var model = await _context.GetThemeModel(id.Value, preview);
        if (model == null) return NotFound();

        // page info
        ViewData[PageInfo.Page] = "download.theme";
        ViewData[PageInfo.Title] = $"{model.Title} | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = $"Download {model.Title} for ImageGlass";
        ViewData[PageInfo.Keywords] = $"{model.Title}, imageglass theme, monochrome theme, colorful theme, windows 11 theme, windows 10 theme, dark mode, {ViewData[PageInfo.Keywords]}";
        ViewData[PageInfo.Thumbnail] = model.Image;

        return View("ThemeDetailPage", model);
    }

}
