using lec8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lec8.Controllers
{

    // http://localhost:3000/Home/Index
    // http://localhost:3000/ControllerName/ActionMethodName
    public class HomeController : Controller // CONTROLLER - control the flow of application
    {

        // VIEW is a user Interface

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public string Index()
        // public IActionResult Index()
        public ViewResult Index()
        {
            // here we will go to the MODEL
            // those classes that are created as per Domain of our Task


           // return "My First MVC Application";


            return View();
        }

        public IActionResult MyIndex()
        {
            return View();
        }

        public ViewResult Index2()
        {
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
}