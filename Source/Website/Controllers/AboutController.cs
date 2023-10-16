using ImageGlassWeb.Data;
using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlassWeb.Controllers;

public class AboutController : BaseController
{
    private readonly ImageGlassContext _context;


    public AboutController(ImageGlassContext context)
    {
        _context = context;
    }

    [HttpGet("about")]
    [ResponseCache(CacheProfileName = "Default")]
    public async Task<IActionResult> Index()
    {
        // page info
        ViewData[PageInfo.Page] = "about";
        ViewData[PageInfo.Title] = $"About | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "ImageGlass' author story";
        ViewData[PageInfo.Keywords] = $"imageglass author, duong dieu phap, {ViewData[PageInfo.Keywords]}";

        // get news items
        ViewData[PageInfo.SidebarList] = await _context.QueryNewsModels(5);

        return View("AboutPage");
    }
}
