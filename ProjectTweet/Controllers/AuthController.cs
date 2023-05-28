
using Microsoft.AspNetCore.Mvc;
using ProjectTweet.Models;
using ProjectTweet.Models.Repositories;

namespace ProjectTweet.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserRepsitory userRepsitory;
        private readonly String cookieName = "userToken";

        public AuthController()
        {
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

            HttpContext.Response.Cookies.Append(cookieName, user.UserId.ToString());

            return View("MyProfile", userModel);
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Append(cookieName, (0).ToString());

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

            // return View("MyProfile", userModel);
            return View("Login");
        }

        [HttpPost("RemoveFollow/{userId}/{followedUserId}")]
        public IActionResult RemoveFollower(int userId, int followedUserId)
        {

            bool v = userRepsitory.removeFollwerOrFollowee(userId, followedUserId);

            if (v == false)
            {
                return View();
            }

            return Redirect("MyProfile");
        }



        [HttpPost("MyProfile")]
        public IActionResult MyProfile(UserModel user)
        {

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

            if (HttpContext.Request.Cookies.ContainsKey(cookieName))
            {
                string? cookie = HttpContext.Request.Cookies[cookieName];

                UserModel userModel = userRepsitory.getProfile(int.Parse(cookie!));

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
            List<ProfileModel> profileModels = new List<ProfileModel>(); //  = this.userRepsitory.getProfilesByJoinedDate();
            profileModels.Add(
                new ProfileModel
                {
                    FirstName = "test",
                    LastName = "test",
                    ProfileId = 1,
                    TagLine = "test",
                    JoinedDate = DateTime.Now,
                }
            );
            return View(profileModels);
        }

        [HttpPost("FollowOthers/{toFollow}")]
        public IActionResult FollowOtherRequest(int toFollow)
        {
            int userId = 0;
            return View("FollowOthers");
        }
    }
}