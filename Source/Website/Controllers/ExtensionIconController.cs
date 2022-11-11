using Microsoft.AspNetCore.Mvc;
using ImageGlass.Data;
using ImageGlass.Models;
using ImageGlass.Utils;

namespace ImageGlass.Controllers;

public class ExtensionIconController : BaseController
{
    private readonly ImageGlassContext _context;

    public ExtensionIconController(ImageGlassContext context)
    {
        _context = context;
    }


    [HttpGet("extension-icons")]
    public async Task<IActionResult> ExtensionIconListingPage(int? page)
    {
        // page info
        ViewData[PageInfo.Title] = $"Extension icon packs | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "The beautiful extension icon packs to change the look and feel of ImageGlass";
        ViewData[PageInfo.Keywords] = $"imageglass theme, monochrome theme, colorful theme, windows 11 theme, windows 10 theme, dark mode, {ViewData[PageInfo.Keywords]}";

        var pList = await _context.QueryExtensionIconModels(10, page ?? 1);

        return View("ExtensionIconListingPage", pList);
    }


    [HttpGet("extension-icon/{slugId}")]
    public async Task<IActionResult> ExtensionIconDetailPage(string? slugId, bool? preview)
    {
        var id = GetIdFromSlugId(slugId);
        if (id is null) return NotFound();

        var model = await _context.GetExtensionIconModel(id.Value, preview);
        if (model == null) return NotFound();

        // page info
        ViewData[PageInfo.Title] = $"{model.Title} | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = $"Download {model.Title} for ImageGlass";
        ViewData[PageInfo.Keywords] = $"{model.Title}, imageglass theme, monochrome theme, colorful theme, windows 11 theme, windows 10 theme, dark mode, {ViewData[PageInfo.Keywords]}";
        ViewData[PageInfo.Thumbnail] = model.Image;

        return View("ExtensionIconDetailPage", model);
    }

}
