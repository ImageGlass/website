using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class SupportController : BaseController
{
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

        // get page content from GitHub
        var markdownContent = await GitHub.GetFileContentAsync("general/privacy.md");
        var htmlContent = GitHub.ParseMarkdown(markdownContent);

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

        // get page content from GitHub
        var markdownContent = await GitHub.GetFileContentAsync("general/license.md");
        var htmlContent = GitHub.ParseMarkdown(markdownContent);

        return View("LicensePage", htmlContent);
    }
}
