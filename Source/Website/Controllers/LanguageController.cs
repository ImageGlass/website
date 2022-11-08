using ImageGlass.Models;
using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ImageGlass.Controllers;

public class LanguageController : BaseController
{
    private readonly HttpClient _client = new();


    [HttpGet("languages")]
    public async Task<IActionResult> LanguageListing()
    {
        var url = $"https://api.crowdin.com/api/project/imageglass/status?key={Constants.CROWNDIN_KEY}&json";
        var languageList = new List<LanguageModel>();

        try
        {
            using var contentStream = await _client.GetStreamAsync(url);

            languageList = await JsonHelper.ParseJsonAsync<List<LanguageModel>>(contentStream);
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
            {
                //
            }
        }


        // page info
        ViewData[PageInfo.Title] = "ImageGlass language packs";
        ViewData[PageInfo.Description] = "Download all language packs of ImageGlass.";
        ViewData[PageInfo.Keywords] = "imageglass language pack, " + ViewData[PageInfo.Keywords];


        return View("LanguageListing", languageList);
    }


    [HttpGet("language/download/{langCode}")]
    public async Task<IActionResult> DownloadLanguage(string langCode, string? langName)
    {
        var url = $"https://api.crowdin.com/api/project/imageglass/download/{langCode}.zip?key={Constants.CROWNDIN_KEY}";

        try
        {
            // do not dispose the stream
            var contentStream = await _client.GetStreamAsync(url);

            var fileName = string.IsNullOrEmpty(langName)
                ? $"{langCode}.zip"
                : $"{langName} ({langCode}).zip";

            return File(contentStream, "application/octet-stream", fileName);
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
            {
                //
            }
        }

        return Ok();
    }
    
}
