using System.Diagnostics;
using lec141.Models;
using Microsoft.AspNetCore.Mvc;

namespace lec141.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string data;

        if (HttpContext.Session.Keys.Contains("token"))
        {
            data = "Welcome Back Again , " + HttpContext.Session.GetString("token");
        }
        else
        {
            data = "Hi, " + DateTime.Now.ToString();
            HttpContext.Session.SetString("token", data);
        }

        return View("Index", data);
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
