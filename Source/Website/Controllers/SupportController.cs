using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class SupportController : BaseController
{
    public IActionResult Index()
    {
        return View("SupportPage");
    }
}
