using ImageGlassWeb.Data;
using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlassWeb.Controllers;

public class ToolController : BaseController
{
    private readonly ImageGlassContext _context;


    public ToolController(ImageGlassContext context)
    {
        _context = context;
    }


    [HttpGet("tools")]
    public async Task<IActionResult> ToolListing()
    {
        // page info
        ViewData[PageInfo.Page] = "download.tool";
        ViewData[PageInfo.Title] = $"Tools | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "A collection of external tools that can be downloaded and installed to enhance your experience with ImageGlass 9.";
        ViewData[PageInfo.Keywords] = $"imageglass tools, exif tool, exifglass, {ViewData[PageInfo.Keywords]}";


        ViewData[PageInfo.SidebarList] = await _context.QueryNewsModels(5);

        return View("ToolListingPage");
    }
}
