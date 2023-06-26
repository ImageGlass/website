using Microsoft.AspNetCore.Mvc;
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


    [HttpGet("download")]
    public async Task<IActionResult> Download(int? page)
    {
        var pList = await _context.QueryReleaseModels(ReleaseChannel.Stable, 1);
        if (pList.Count > 0)
        {
            return RedirectToAction(nameof(ReleaseDetailPage), new { slugId = pList[0].SlugAndId });
        }

        return RedirectToAction(nameof(StableReleasesListingPage));
    }


    [HttpGet("releases")]
    public async Task<IActionResult> StableReleasesListingPage(int? page)
    {
        // page info
        ViewData[PageInfo.Page] = "download.release.stable";
        ViewData[PageInfo.Title] = $"Stable releases | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Keywords] = $"imageglass stable, {ViewData[PageInfo.Keywords]}";

        // page data
        ViewData["_ControllerAction"] = nameof(StableReleasesListingPage);

        var pList = await _context.QueryReleaseModels(ReleaseChannel.Stable, 10, page ?? 1);
        return View("ReleaseListingPage", pList);
    }


    [HttpGet("releases/beta")]
    public async Task<IActionResult> BetaReleasesListingPage(int? page)
    {
        // page info
        ViewData[PageInfo.Page] = "download.release.beta";
        ViewData[PageInfo.Title] = $"Beta releases | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "The bleeding-edge beta release of ImageGlass. It is built and shipped to users with the latest state and features of ImageGlass.";
        ViewData[PageInfo.Keywords] = $"imageglass beta, {ViewData[PageInfo.Keywords]}";

        // page data
        ViewData["_ControllerAction"] = nameof(BetaReleasesListingPage);

        var pList = await _context.QueryReleaseModels(ReleaseChannel.Beta, 10, page ?? 1);
        return View("ReleaseListingPage", pList);
    }


    [HttpGet("release/{slugId}")]
    public async Task<IActionResult> ReleaseDetailPage(string? slugId, bool? preview)
    {
        var id = GetIdFromSlugId(slugId);
        if (id is null) return NotFound();

        var model = await _context.GetReleaseDetailModel(id.Value, preview);
        if (model == null) return NotFound();

        // page info
        ViewData[PageInfo.Page] = $"download.release.{model.ReleaseChannel}";
        ViewData[PageInfo.Title] = $"{model.Title} | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = $"Download {model.Title}";
        ViewData[PageInfo.Keywords] = $"imageglass {model.Version}, imageglass {model.ReleaseChannel}, " + ViewData[PageInfo.Keywords];
        ViewData[PageInfo.Thumbnail] = model.Image;

        // page data
        ViewData[PageInfo.SidebarList] = await _context.QueryNewsModels(5);
        if (!string.IsNullOrEmpty(model.ScreenshotsDir))
        {
            ViewData["_ReleaseScreenshots"] = await GitHub.GetFilesAsync("releases/screenshots", model.ScreenshotsDir);
        }


        return View("ReleaseDetailPage", model);
    }


}
