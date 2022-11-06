﻿using System.Text;
using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageGlass.Controllers;

public class UrlController : BaseController
{

    /// <summary>
    /// Gets update information.
    /// </summary>
    [HttpGet("url")]
    public async Task<IActionResult> Index()
    {
        var rawContent = await ContentParser.GetGitHubRawContentAsync("Contents/news/sample-file-1.md");
        var contentData = ContentParser.GetPageContentData(rawContent);

        var metadata = ContentParser.ParsePageMeta(contentData.MetaJson);
        var htmlContent = ContentParser.ParseMarkdown(@"

::: { .box .box-info }
Update: All promotional codes are redeemed!

You still can get the store version with a discount price only for today July 20, 2022. See you next year in the 13th anniversary event!
:::

"); //  contentData.Content);


        ViewBag.Content = htmlContent;
        ViewBag.Metadata = metadata;

        return View("../About/Index");
    }


    /// <summary>
    /// Gets update information.
    /// </summary>
    [HttpGet("url/update")]
    public async Task<ActionResult> GetUpdateAsync()
    {
        var updateInfoJsonUrl = "https://raw.githubusercontent.com/ImageGlass/config/main/update.json";

        using var httpClient = new HttpClient();
        var jsonStr = await httpClient.GetStringAsync(updateInfoJsonUrl);

        return Content(jsonStr, "application/json", Encoding.UTF8);
    }
}

