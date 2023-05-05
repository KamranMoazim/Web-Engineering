
using Microsoft.AspNetCore.Mvc;
using ProjectTweet.Models;
using ProjectTweet.Models.Repositories;

namespace ProjectTweet.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserRepsitory userRepsitory;

        public AuthController()
        {
            // Response.Cookies.Append("is_logged_in", false.ToString());
            userRepsitory = new UserRepsitory();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(UserModel user)
        {

            UserModel userModel = userRepsitory.login(user);

            if (userModel == null)
            {
                return View();
            }

            return View("MyProfile", userModel);
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
        public IActionResult Register(UserModel user, string confirmPassword)
        {

            if (user.Password != confirmPassword)
            {
                return View();
            }

            UserModel userModel = userRepsitory.register(user);

            return View("MyProfile", userModel);
        }

        [HttpGet("MyProfile")]
        public IActionResult MyProfile()
        {
            UserModel userModel = new UserModel
            {
                UserId = 1,
                Username = "test",
                Password = "test"
            };

            return View(userModel);
        }
    }
}