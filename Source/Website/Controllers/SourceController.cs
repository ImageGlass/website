using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class SourceController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
