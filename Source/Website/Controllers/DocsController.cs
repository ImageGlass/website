using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class DocsController : BaseController
{
    public IActionResult Index()
    {
        ViewData[PageInfo.Page] = "docs";

        return View("DocsListingPage");
    }
}
