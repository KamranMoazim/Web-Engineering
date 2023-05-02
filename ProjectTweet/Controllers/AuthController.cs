using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjectTweet.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public AuthController()
        {
            Response.Cookies.Append("is_logged_in", false.ToString());
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            Console.WriteLine(email);
            Console.WriteLine(password);

            if (email == "test@email.com" && password == "test")
            {
                return RedirectToAction("MyProfile");
            }

            ViewBag.Error = "Invalid email or password";

            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            return View("Login");
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(string email, string password, string confirmPassword)
        {
            Console.WriteLine(email);
            Console.WriteLine(password);
            Console.WriteLine(confirmPassword);

            return View();
        }

        [HttpGet("MyProfile")]
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}