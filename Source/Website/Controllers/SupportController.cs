using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class SupportController : BaseController
{
    public IActionResult Index()
    {
        return View("SupportPage");
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

        return View("MarkdownPage", htmlContent);
    }


    [HttpGet("license")]
    public async Task<IActionResult> LicensePage()
    {
        // page info
        ViewData[PageInfo.Title] = $"End-user license agreement (EULA) | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "ImageGlass end-user lisence agreement (EULA)";
        ViewData[PageInfo.Keywords] = $"imageglass eula, imageglass license, imageglass commercial use, {ViewData[PageInfo.Keywords]}";

        // get page content from GitHub
        var markdownContent = await GitHub.GetFileContentAsync("general/license.md");
        var htmlContent = GitHub.ParseMarkdown(markdownContent);

        return View("LicensePage", htmlContent);
    }


    [HttpGet("faqs")]
    public async Task<IActionResult> FAQsPage()
    {
        // page info
        ViewData[PageInfo.Title] = $"FAQs | {ViewData[PageInfo.Name]}";
        ViewData[PageInfo.Description] = "ImageGlass FAQs";
        ViewData[PageInfo.Keywords] = $"imageglass faqs, {ViewData[PageInfo.Keywords]}";

        // get page content from GitHub
        var markdownContent = await GitHub.GetFileContentAsync("general/faqs.md");
        var htmlContent = GitHub.ParseMarkdown(markdownContent);

        return View("MarkdownPage", htmlContent);
    }

}
