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


    [HttpGet("kobe")]
    public async Task<IActionResult> KobeReleases(int? page)
    {
        // page info
        ViewData[PageInfo.Title] = $"Kobe releases | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Keywords] = $"imageglass kobe, {ViewData[PageInfo.Keywords]}";

        var pList = await _context.QueryReleaseModels(ReleaseChannel.Kobe, 10, page ?? 1);
        return View("ReleaseListingPage", pList);
    }


    [HttpGet("moon")]
    public async Task<IActionResult> MoonReleases(int? page)
    {
        // page info
        ViewData[PageInfo.Title] = $"Moon releases | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "ImageGlass Moon is the bleeding-edge (or beta) release of ImageGlass Kobe, is built and shipped to users with the latest state and features of ImageGlass.";
        ViewData[PageInfo.Keywords] = $"imageglass moon, imageglass beta, {ViewData[PageInfo.Keywords]}";

        var pList = await _context.QueryReleaseModels(ReleaseChannel.Moon, 10, page ?? 1);
        return View("ReleaseListingPage", pList);
    }


    [HttpGet("release/{slugId}")]
    public async Task<IActionResult> ReleaseDetails(string? slugId, bool? preview)
    {
        var id = GetIdFromSlugId(slugId);
        if (id is null) return NotFound();

        var model = await _context.GetReleaseDetailModel(id.Value, preview);
        if (model == null) return NotFound();

        // page info
        ViewData[PageInfo.Title] = $"{model.Title} | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = $"Download {model.Title}";
        ViewData[PageInfo.Keywords] = $"imageglass {model.Version}, imageglass {model.ReleaseChannel}, " + ViewData[PageInfo.Keywords];
        ViewData[PageInfo.Thumbnail] = model.Image;

        return View("ReleaseDetailPage", model);
    }


}
