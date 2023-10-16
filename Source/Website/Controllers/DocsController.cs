using ImageGlassWeb.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlassWeb.Controllers;

public class DocsController : BaseController
{
    public IActionResult Index()
    {
        ViewData[PageInfo.Page] = "docs";

        return View("DocsListingPage");
    }
}
