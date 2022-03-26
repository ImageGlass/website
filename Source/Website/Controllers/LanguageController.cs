using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class LanguageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
