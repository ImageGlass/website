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


    public IActionResult Index()
    {
        return View("HomePage");
    }


    [HttpGet("privacy")]
    public async Task<IActionResult> PrivacyPage()
    {
        // page info
        ViewData[PageInfo.Title] = $"Privacy information | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "ImageGlass privacy information";
        ViewData[PageInfo.Keywords] = $"imageglass privacy, {ViewData[PageInfo.Keywords]}";

        // get page content from GitHub
        var markdownContent = await GitHub.GetFileContentAsync("general/privacy.md");
        var htmlContent = GitHub.ParseMarkdown(markdownContent);
        
        return View("PrivacyPage", htmlContent);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
