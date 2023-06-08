using System.Diagnostics;
using lec172.Models;
using Microsoft.AspNetCore.Mvc;

namespace lec172.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        // ViewComponent - used for a bit more complex Views
        // so we can manage data easily, becuase it has completely different context than parent
        // it has its own Controller-Class

        // ViewModel- a model class which we have to particularly create for particular View
        // create ViewModel Folder within Models Folder

        // edit _ViewImports.cshtml

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
