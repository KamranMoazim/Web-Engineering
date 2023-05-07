
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
            UserModel userModel = new UserModel
            {
                UserId = 1,
                Username = "test",
                FirstName = "test",
                LastName = "test",
                Password = "test",
                Follower = new List<FollowUserModel>(){
                    new FollowUserModel(){
                        UserId = 2,
                        Username = "test2",
                        FirstName = "test2",
                    },
                    new FollowUserModel(){
                        UserId = 3,
                        Username = "test3",
                        FirstName = "test3",
                    },
                },
                Followee = new List<FollowUserModel>(){
                    new FollowUserModel(){
                        UserId = 4,
                        Username = "test4",
                        FirstName = "test4",
                    },
                    new FollowUserModel(){
                        UserId = 5,
                        Username = "test5",
                        FirstName = "test5",
                    },
                }
            };

            return View(userModel);
        }

        [HttpGet("FollowOthers")]
        public IActionResult FollowOthers()
        {
            List<ProfileModel> profileModels = this.userRepsitory.getProfilesByJoinedDate();
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