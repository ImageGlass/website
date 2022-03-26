using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
