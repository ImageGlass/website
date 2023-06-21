using Crowdin.Api;
using Crowdin.Api.Translations;
using ImageGlass.Models;
using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;

namespace ImageGlass.Controllers;

public class LanguageController : BaseController
{
    private readonly HttpClient _client = new();
    private readonly CrowdinApiClient _crowdin = new CrowdinApiClient(new CrowdinCredentials()
    {
        AccessToken = Constants.CROWNDIN_KEY,
    });


    [HttpGet("languages")]
    public async Task<IActionResult> LanguageListing()
    {
        var supportedLangsTask = _crowdin.Languages.ListSupportedLanguages(limit: 500);
        var projectProgressTask = _crowdin.TranslationStatus.GetProjectProgress(Constants.CROWNIN_PROJECT_ID, limit: 500);

        await Task.WhenAll(supportedLangsTask, projectProgressTask);
        var allLangs = (await supportedLangsTask).Data;
        var languageList = (await projectProgressTask).Data.Select(status =>
        {
            var lang = allLangs.FirstOrDefault(i => i.Id == status.LanguageId);

            return new LanguageModel()
            {
                LanguageId = status.LanguageId,
                Name = lang?.Name ?? string.Empty,
                TranslationProgress = status.TranslationProgress,
            };
        });


        // page info
        ViewData[PageInfo.Title] = "ImageGlass language packs";
        ViewData[PageInfo.Description] = "Download all language packs of ImageGlass.";
        ViewData[PageInfo.Keywords] = "imageglass language pack, " + ViewData[PageInfo.Keywords];


        return View("LanguageListing", languageList);
    }


    [HttpGet("language/download/{langId}")]
    public async Task<IActionResult> DownloadLanguage(string langId, string? langName)
    {
        var downloadLink = await _crowdin.Translations.ExportProjectTranslation(Constants.CROWNIN_PROJECT_ID, new ExportProjectTranslationRequest()
        {
            TargetLanguageId = langId,
        });


        try
        {
            // do not dispose the stream
            var contentStream = await _client.GetStreamAsync(downloadLink?.Url);

            var fileName = string.IsNullOrEmpty(langName)
                ? $"{langId}.zip"
                : $"{langName} ({langId}).zip";

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
