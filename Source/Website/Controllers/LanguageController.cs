using ImageGlass.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ImageGlass.Controllers;

public class LanguageController : BaseController
{
    const string CROWNDIN_KEY = "0b08634573c456476345efa8bad174f2";

    private static JsonSerializerOptions JsonOptions { get; } = new()
    {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

        Converters =
        {
            // Write enum value as string
            new JsonStringEnumConverter(),
        },

        // ignoring policy
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull,
        IgnoreReadOnlyProperties = true,
        IgnoreReadOnlyFields = true,
    };

    public async Task<IActionResult> Index()
    {
        var url = $"https://api.crowdin.com/api/project/imageglass/status?key={CROWNDIN_KEY}&json";

        var requestMsg = new HttpRequestMessage(HttpMethod.Get, url);
        using var httpClient = new HttpClient();
        var response = await httpClient.SendAsync(requestMsg);
        var languageList = new List<LanguageModel>();

        if (response.IsSuccessStatusCode)
        {
            using var contentStream = await response.Content.ReadAsStreamAsync();

            languageList = await JsonSerializer.DeserializeAsync
                <List<LanguageModel>>(contentStream, JsonOptions);
        }

        return View(languageList);
    }
}
