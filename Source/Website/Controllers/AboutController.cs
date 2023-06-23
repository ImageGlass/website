using ImageGlass.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class AboutController : BaseController
{
    public IActionResult Index()
    {
        ViewData[PageInfo.Page] = "about";

        return View("AboutPage");
    }
}
