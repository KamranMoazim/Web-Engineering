using System.Diagnostics;
using lec12.Models;
using Microsoft.AspNetCore.Mvc;

namespace lec12.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        // HTTP protocol is stateless - state is not maintained
        // OI - client_side - cookies - save data in client browser - (key-value) pair
        // II - server_side - sessions

        // Partial View = book page-619
        // 1 - to remove code duplication
        // 2 - to divide big file into chunks
        // file name start with _
        // file finding sequence
        // 1. Controller Folder - Like Home
        // 2. Shared Folder
        // 3. Pages Folder

        _logger = logger;
    }

    public IActionResult Index()
    {
        string cookieKey = "first_visit_datetime";
        object data = "Welcome New User";

        if (!HttpContext.Request.Cookies.ContainsKey(cookieKey))
        {
            HttpContext.Response.Cookies.Append(cookieKey, System.DateTime.Now.ToString());
            return View(data);
        }
        else
        {
            string? lastVisitedDatetime = HttpContext.Request.Cookies[cookieKey];
            data = $"Welcome Back | {lastVisitedDatetime}";
            return View(data);
        }
    }

    public IActionResult Index1()
    {
        List<Student> students = new List<Student>(){
            new Student{Id="1", Name="st1"},
            new Student{Id="2", Name="st2"},
        };
        return View(students);
    }


    public IActionResult Index2()
    {
        List<Course> courses = new List<Course>(){
            new Course{Id="1", Name="cs1"},
            new Course{Id="2", Name="cs2"},
        };
        return View(courses);
    }



    public IActionResult Login()
    {
        return View();
    }

    // [HttpPost]
    // public IActionResult Login(User user)
    // {
    //     string cookieKey = "is_logged_in";

    //     if (!HttpContext.Request.Cookies.ContainsKey(cookieKey))
    //     {
    //         HttpContext.Response.Cookies.Append(cookieKey, System.DateTime.Now.ToString());
    //     }
    //     else
    //     {
    //         string? lastVisitedDatetime = HttpContext.Request.Cookies[cookieKey];
    //         return View();
    //     }
    // }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    internal class Student
    {
        public String Id { get; set; }
        public String Name { get; set; }
    }

    internal class Course
    {
        public String Id { get; set; }
        public String Name { get; set; }
    }
}
