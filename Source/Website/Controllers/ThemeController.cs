using Microsoft.AspNetCore.Mvc;
using ImageGlassWeb.Data;
using ImageGlassWeb.Utils;

namespace ImageGlassWeb.Controllers;

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

        var pList = await _context.QueryThemeModels(12, page ?? 1);

        return View("ThemeListingPage", pList);
    }


    [HttpGet("theme/{slugId}")]
    [ResponseCache(CacheProfileName = "Default")]
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

        // page data
        ViewData[PageInfo.SidebarList] = await _context.QueryThemeModels(5);

        return View("ThemeDetailPage", model);
    }


    [HttpGet("theme/download/{slugId}")]
    public async Task<IActionResult> DownloadTheme(string? slugId)
    {
        var id = GetIdFromSlugId(slugId);
        if (id is null) return NotFound();

        var model = await _context.GetThemeModel(id.Value, false);
        if (model == null) return NotFound();

        // update the download count
        model.Count++;
        if (await TryUpdateModelAsync(model, "", i => i.Count)) {
            await _context.SaveChangesAsync();

            return Redirect(model.Link);
        }

        return NoContent();
    }
}
