using ImageGlass.Data;
using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class AboutController : BaseController
{
    private readonly ImageGlassContext _context;


    public AboutController(ImageGlassContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? page)
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
