using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlassWeb.Controllers;

public class SupportController : BaseController
{
    private readonly IWebHostEnvironment _appEnv;


    public SupportController(IWebHostEnvironment appEnv)
    {
        _appEnv = appEnv;
    }



    [HttpGet("support")]
    [ResponseCache(CacheProfileName = "Default")]
    public IActionResult Index()
    {
        // page info
        ViewData[PageInfo.Page] = "support";
        ViewData[PageInfo.Title] = $"Support | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "Got a question? Need help with a problem? You're in the right place to find all the ImageGlass customer and technical support you need!";
        ViewData[PageInfo.Keywords] = $"imageglass support, {ViewData[PageInfo.Keywords]}";

        return View("SupportPage");
    }


    [HttpGet("privacy")]
    [ResponseCache(CacheProfileName = "Default")]
    public async Task<IActionResult> PrivacyPage()
    {
        // page info
        ViewData[PageInfo.Page] = "support.privacy";
        ViewData[PageInfo.Title] = $"Privacy information | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "ImageGlass privacy information";
        ViewData[PageInfo.Keywords] = $"imageglass privacy, {ViewData[PageInfo.Keywords]}";

        // get page content
        var htmlContent = await ContentHelper.GetContentAsync(_appEnv.WebRootPath, "privacy.html");

        return View("MarkdownPage", htmlContent);
    }


    [HttpGet("license")]
    [ResponseCache(CacheProfileName = "Default")]
    public async Task<IActionResult> LicensePage()
    {
        // page info
        ViewData[PageInfo.Page] = "support.license";
        ViewData[PageInfo.Title] = $"End-user license agreement (EULA) | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "ImageGlass end-user lisence agreement (EULA)";
        ViewData[PageInfo.Keywords] = $"imageglass eula, imageglass license, imageglass commercial use, {ViewData[PageInfo.Keywords]}";

        // get page content
        var htmlContent = await ContentHelper.GetContentAsync(_appEnv.WebRootPath, "license.html");

        return View("LicensePage", htmlContent);
    }
}
