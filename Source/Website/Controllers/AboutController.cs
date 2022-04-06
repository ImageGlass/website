using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class AboutController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
