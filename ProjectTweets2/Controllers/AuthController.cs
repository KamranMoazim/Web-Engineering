using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectTweets2.Models.DB;
using ProjectTweets2.Models.Repositories;
using ProjectTweets2.Models.ViewModel;

namespace ProjectTweets2.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserRepsitory userRepsitory;
        private readonly TweetRepository tweetRepository;
        private readonly String cookieName = "userToken";
        private readonly String sessionName = "userToken";

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
            userRepsitory = new UserRepsitory();
            tweetRepository = new TweetRepository();
        }



        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(User user)
        {

            User userModel = userRepsitory.login(user);

            if (userModel == null)
            {
                return View();
            }

            HttpContext.Session.SetString(sessionName, userModel.UserId.ToString());
            HttpContext.Response.Cookies.Append(cookieName, userModel.UserId.ToString());

            // Console.WriteLine("cookie --- " + HttpContext.Request.Cookies[cookieName]);

            return View("MyProfile", userModel);
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            HttpContext.Session.SetString(sessionName, (0).ToString());
            HttpContext.Response.Cookies.Append(cookieName, (0).ToString());

            return View("Login");
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(User user, string confirmPassword)
        {

            if (user.Password != confirmPassword)
            {
                return View();
            }

            User userModel = userRepsitory.register(user);

            // return View("MyProfile", userModel);
            return View("Login");
        }

        [HttpPost("RemoveFollower/{followedUserId}")]
        public IActionResult RemoveFollower(int followedUserId)
        {
            // Console.WriteLine("followedUserId " + followedUserId);

            int userId = CheckIfLoggedIn();

            if (userId == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            bool v = userRepsitory.removeFollower(userId, followedUserId);

            return RedirectToAction("MyProfile", "Auth");
        }


        [HttpPost("RemoveFollowee/{userId}/{followedUserId}")]
        public IActionResult RemoveFollowee(int userId, int followedUserId)
        {

            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            bool v = userRepsitory.removeFollowee(userId, followedUserId);

            if (v == false)
            {
                return View();
            }

            return Redirect("MyProfile");
        }



        [HttpPost("MyProfile")]
        public IActionResult MyProfile(User user)
        {

            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            user.UserId = CheckIfLoggedIn();
            bool v = userRepsitory.updateUserProfile(user);

            if (v == false)
            {
                return View();
            }

            return Redirect("MyProfile");
        }

        [HttpGet("MyProfile")]
        public IActionResult MyProfile()
        {

            // if (HttpContext.Request.Cookies.ContainsKey(cookieName) || HttpContext.Session.GetString(sessionName) != null)
            if (CheckIfLoggedIn() != 0)
            {
                string? session = HttpContext.Session.GetString(sessionName);
                string? cookie = HttpContext.Request.Cookies[cookieName];

                User userModel = userRepsitory.getProfile(int.Parse(cookie!));

                if (userModel == null)
                {
                    return View("Login");
                }

                return View(userModel);
            }

            return View("Login");
        }

        [HttpGet("FollowOthers")]
        public IActionResult FollowOthers()
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            int v = CheckIfLoggedIn();
            List<User> profileModels = userRepsitory.getProfilesByJoinedDate(v);

            return View(profileModels);
        }

        [HttpPost("FollowOthers/{toFollow}")]
        public IActionResult FollowOthers(int toFollow)
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            Console.WriteLine(toFollow);

            int v = CheckIfLoggedIn();
            userRepsitory.makeFollower(v, toFollow);

            List<User> profileModels = userRepsitory.getProfilesByJoinedDate(v);

            return View(profileModels);
        }


        [HttpGet("OtherUserDetail/{userId}")]
        public IActionResult OtherUserDetail(int userId)
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Console.WriteLine(userId);

            OtherUserDetail otherUserDetail = new OtherUserDetail
            {
                Profile = userRepsitory.getProfile(userId),
                Tweets = tweetRepository.GetAllMyTweets(userId),
            };
            return View(otherUserDetail);
        }



        private int CheckIfLoggedIn()
        {
            if (HttpContext.Request.Cookies.ContainsKey(cookieName))
            {
                string? cookie = HttpContext.Request.Cookies[cookieName];
                int v = int.Parse(cookie!);
                Console.WriteLine("v-cookie " + v);
                return v;
            }

            return 0;
        }

    }
}