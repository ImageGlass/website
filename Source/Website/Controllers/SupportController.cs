using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class SupportController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
