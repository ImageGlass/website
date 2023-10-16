using ImageGlassWeb.Data;
using ImageGlassWeb.Models;
using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ImageGlassWeb.Controllers;

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

        // featured content
        var pList = await _context.QueryReleaseModels(1, releaseChannel: ReleaseChannel.Stable);
        var latestStableRelease = pList.FirstOrDefault();

        // github repo stats
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

            var repoJson = await client.GetStringAsync("https://api.github.com/repos/d2phap/ImageGlass");
            var repoDict = JsonHelper.ParseJson<Dictionary<string, object>>(repoJson ?? "{}") ?? new();

            // repo stats
            if (repoDict.TryGetValue("stargazers_count", out var starsCount)) {
                ViewData["_RepoStarsCount"] = starsCount;
            }
            if (repoDict.TryGetValue("forks_count", out var forksCount)) {
                ViewData["_RepoForksCount"] = forksCount;
            }
            if (repoDict.TryGetValue("subscribers_count", out var subscribersCount)) {
                ViewData["_RepoSubscribersCount"] = subscribersCount;
            }
        }
        catch {}

        return View("HomePage", latestStableRelease);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
