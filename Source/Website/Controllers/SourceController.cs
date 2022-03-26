using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class SourceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
