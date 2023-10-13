using Crowdin.Api;
using Crowdin.Api.Languages;
using Crowdin.Api.Translations;
using ImageGlass.Models;
using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ImageGlass.Controllers;

public class LanguageController : BaseController
{
    private readonly HttpClient _client = new();
    private const string CROWNDIN_KEY = "8e2f937a310925530c8755cd7f4b3dc2265a90852d64922212a1a92840f0c9e051ff4c719a9928c2";
    private const int CROWNIN_PROJECT_ID = 209133;
    private const int CROWNIN_FILE_ID = 44;

    private readonly CrowdinApiClient _crowdin = new(new() { AccessToken = CROWNDIN_KEY });


    [HttpGet("languages")]
    [ResponseCache(CacheProfileName = "Default")]
    public async Task<IActionResult> LanguageListing()
    {
        var supportedLangsTask = _crowdin.Languages.ListSupportedLanguages(limit: 500);
        var projectProgressTask = _crowdin.TranslationStatus.GetProjectProgress(CROWNIN_PROJECT_ID, limit: 500);

        await Task.WhenAll(supportedLangsTask, projectProgressTask);
        var allLangs = (await supportedLangsTask).Data;
        var progressList = (await projectProgressTask).Data;

        var langList = new List<LanguageModel>();
        for (int i = 0; i < progressList.Count; i++)
        {
            var prog = progressList[i];
            var lang = allLangs.FirstOrDefault(i => i.Id == prog.LanguageId);
            if (lang is null) continue;

            langList.Add(new LanguageModel() {
                LanguageId = prog.LanguageId,
                Name = lang.Name ?? string.Empty,
                TranslationProgress = prog.TranslationProgress,
            });
        }
        langList = langList.OrderBy(i => i.Name).ToList();


        // page info
        ViewData[PageInfo.Page] = "download.language";
        ViewData[PageInfo.Title] = "ImageGlass language packs";
        ViewData[PageInfo.Description] = "Download all language packs of ImageGlass.";
        ViewData[PageInfo.Keywords] = "imageglass language pack, " + ViewData[PageInfo.Keywords];


        return View("LanguageListing", langList);
    }


    [HttpGet("language/download/{langId}")]
    public async Task<IActionResult> DownloadLanguage(string langId, string? langName)
    {
        try
        {
            var downloadLink = await _crowdin.Translations.ExportProjectTranslation(CROWNIN_PROJECT_ID, new ExportProjectTranslationRequest()
            {
                TargetLanguageId = langId,
                FileIds = new int[] { CROWNIN_FILE_ID },
            });


            // do not dispose the stream
            var contentStream = await _client.GetStreamAsync(downloadLink?.Url);

            var fileName = string.IsNullOrEmpty(langName)
                ? $"{langId}.iglang"
                : $"{langName} ({langId}).iglang";

            return File(contentStream, "application/xml", fileName);
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
