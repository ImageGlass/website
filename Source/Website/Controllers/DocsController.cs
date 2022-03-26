using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class DocsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
