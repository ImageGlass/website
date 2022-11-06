using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImageGlass.Data;
using ImageGlass.Models;
using ImageGlass.Utils;

namespace ImageGlass.Controllers;

public class ReleaseController : BaseController
{
    private readonly ImageGlassContext _context;

    public ReleaseController(ImageGlassContext context)
    {
        _context = context;
    }


    [HttpGet("kobe")]
    public async Task<IActionResult> KobeReleases(int? page)
    {
        var pageNumber = page ?? 1;
        var source = _context.Releases
            .Where(i => i.Visible && i.ReleaseType == ReleaseType.Kobe)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VRelease(i))
            .AsNoTracking();

        var pList = await PaginatedList<VRelease>
            .CreateAsync(source, pageNumber, 10);

        // page info
        ViewData[PageInfo.Title] = "ImageGlass Kobe releases";
        ViewData[PageInfo.Keywords] = "imageglass kobe, " + ViewData[PageInfo.Keywords];
        ViewData[PageInfo.Thumbnail] = "https://github.com/ImageGlass/config/raw/main/screenshots/v9.0-beta-2/9.0b2_1.jpg";

        return View("ReleaseListing", pList);
    }


    [HttpGet("moon")]
    public async Task<IActionResult> MoonReleases(int? page)
    {
        var pageNumber = page ?? 1;
        var source = _context.Releases
            .Where(i => i.Visible && i.ReleaseType == ReleaseType.Moon)
            .OrderByDescending(i => i.CreatedDate)
            .Select(i => new VRelease(i))
            .AsNoTracking();

        var pList = await PaginatedList<VRelease>
            .CreateAsync(source, pageNumber, 10);

        // page info
        ViewData[PageInfo.Title] = "ImageGlass Moon releases";
        ViewData[PageInfo.Description] = "ImageGlass Moon is the bleeding-edge (or beta) release of ImageGlass Kobe, is built and shipped to users with the latest state and features of ImageGlass.";
        ViewData[PageInfo.Keywords] = "imageglass moon, imageglass beta, " + ViewData[PageInfo.Keywords];
        ViewData[PageInfo.Thumbnail] = "https://github.com/ImageGlass/config/raw/main/screenshots/v9.0-beta-2/9.0b2_1.jpg";

        return View("ReleaseListing", pList);
    }


    [HttpGet("release/{slugId}")]
    public async Task<IActionResult> ReleaseDetails(string? slugId, bool? preview)
    {
        var id = GetIdFromSlugId(slugId);
        if (id is null) return NotFound();

        var isPreview = preview ?? false;
        var model = await _context.Releases.Where(i => i.ReleaseId == id && (isPreview || i.Visible))
            .Include(i => i.ReleaseImages)
            .Include(i => i.Downloads)
            .Select(i => new VReleaseDetails(i, isPreview))
            .FirstOrDefaultAsync();

        if (model == null) return NotFound();

        // page info
        ViewData[PageInfo.Title] = model.Title;
        ViewData[PageInfo.Keywords] = $"imageglass {model.Version}, imageglass {model.ReleaseType}, " + ViewData[PageInfo.Keywords];
        ViewData[PageInfo.Thumbnail] = model.Image;

        return View("ReleaseDetails", model);
    }


}
