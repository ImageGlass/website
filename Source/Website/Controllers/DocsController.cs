using Microsoft.AspNetCore.Mvc;

namespace ImageGlass.Controllers;

public class DocsController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
