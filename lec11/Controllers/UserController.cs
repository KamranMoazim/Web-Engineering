using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lec11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lec11.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private UserRepository userRepository;

        public UserController()
        {
            // ViewData["Error"] = "";
            userRepository = new UserRepository();
        }

        [HttpGet("/User/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/User/SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost("/User/SignIn")]
        public IActionResult SignIn(User user) // this is MODEL BINDING
        {
            Console.WriteLine(user);

            if (userRepository.SignIn(user))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // [HttpPost("/User/SignIn")]
        // public IActionResult SignIn(User user) // this is MODEL BINDING
        // {
        //     Console.WriteLine(user);

        //     if (userRepository.SignIn(user))
        //     {
        //         ViewData["Error"] = "";
        //         // return View("Index", user);
        //         return RedirectToAction("Index", "Home");
        //     }
        //     else
        //     {
        //         ViewData["Error"] = "User NOT MATCHED/FOUND";
        //         return View();
        //     }
        // }

        // [HttpPost("/User/SignIn")]
        // public IActionResult SignIn(string username, string password)
        // {
        //     Console.WriteLine(username);
        //     Console.WriteLine(password);
        //     user.UserName = username;
        //     user.Password = password;
        //     return Redirect("Index");
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}