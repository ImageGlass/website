using IgWebHelper;
using ImageGlassWeb.Data;
using ImageGlassWeb.Models;
using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        // featured content
        var releaseList = await _context.QueryReleaseModels(1, releaseChannel: ReleaseChannel.Stable);
        var latestStableRelease = releaseList.FirstOrDefault(i => !i.Version.StartsWith('8'));


        // page info
        ViewData[PageInfo.Page] = "home";
        ViewData[PageInfo.Thumbnail] = latestStableRelease?.Image;


        // github repo stats
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

            var repoJson = await client.GetStringAsync("https://api.github.com/repos/d2phap/ImageGlass");
            var repoDict = JsonHelper.ParseJson<Dictionary<string, object>>(repoJson ?? "{}") ?? new();

            // repo stats
            if (repoDict.TryGetValue("stargazers_count", out var starsCount))
            {
                ViewData["_RepoStarsCount"] = starsCount;
            }
            if (repoDict.TryGetValue("forks_count", out var forksCount))
            {
                ViewData["_RepoForksCount"] = forksCount;
            }
            if (repoDict.TryGetValue("subscribers_count", out var subscribersCount))
            {
                ViewData["_RepoSubscribersCount"] = subscribersCount;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }

        return View("HomePage", latestStableRelease);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [Route("error/handle-exception")]
    public IActionResult HandleException()
    {
        // log error
        var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        if (feature != null)
        {
            _logger.LogError(new EventId(), feature.Error, feature.Error.Message, feature.Endpoint);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [Route("error/{code}")]
    public IActionResult Index(int code)
    {
        Response.Clear();
        Response.StatusCode = code;

        ViewData[PageInfo.Page] = "error";

        return View("ErrorPage", code);
    }
}
