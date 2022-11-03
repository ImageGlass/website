using System.Text;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageGlass.Controllers;

public class UrlController : BaseController
{

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

