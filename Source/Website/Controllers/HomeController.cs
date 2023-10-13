using ImageGlass.Data;
using ImageGlass.Models;
using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ImageGlass.Controllers;

public class HomeController : BaseController
{
    private readonly ImageGlassContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ImageGlassContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> Index()
    {
        // page info
        ViewData[PageInfo.Page] = "home";

        var pList = await _context.QueryReleaseModels(1, releaseChannel: ReleaseChannel.Stable);
        var latestStableRelease = pList.FirstOrDefault();


        return View("HomePage", latestStableRelease);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
