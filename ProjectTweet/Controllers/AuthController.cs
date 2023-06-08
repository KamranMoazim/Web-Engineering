
using Microsoft.AspNetCore.Mvc;
using ProjectTweet.Models;
using ProjectTweet.Models.DB;
using ProjectTweet.Models.Repositories;

namespace ProjectTweet.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserRepsitory userRepsitory;
        private readonly String cookieName = "userToken";
        private readonly String sessionName = "userToken";


        //         string data;
        //         if (HttpContext.Session.Keys.Contains("token"))
        //         {
        //             data = "Welcome Back Again , " + HttpContext.Session.GetString("token");
        //         }
        //         else
        //         {
        //             data = "Hi, " + DateTime.Now.ToString();
        //             HttpContext.Session.SetString("token", data);
        //         }
        //         return View("Index", data);


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

            HttpContext.Session.SetString(sessionName, user.UserId.ToString());
            HttpContext.Response.Cookies.Append(cookieName, user.UserId.ToString());

            return View("MyProfile", userModel);
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
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

            if (HttpContext.Request.Cookies.ContainsKey(cookieName) || HttpContext.Session.GetString(sessionName) != null)
            {
                string? session = HttpContext.Session.GetString(sessionName);
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
            List<ProfileModel> profileModels = new List<ProfileModel>();
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
        public IActionResult FollowOthers(int toFollow)
        {
            Console.WriteLine(toFollow);
            List<ProfileModel> profileModels = new List<ProfileModel>();
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


        [HttpGet("OtherUserDetail/{userId}")]
        public IActionResult OtherUserDetail(int userId)
        {
            Console.WriteLine(userId);

            OtherUserDetail otherUserDetail = new OtherUserDetail
            {
                Profile = new ProfileModel
                {
                    FirstName = "test",
                    LastName = "test",
                    ProfileId = 1,
                    TagLine = "test",
                    JoinedDate = DateTime.Now,
                },
                Tweets = new List<TweetModel>
                {
                    new TweetModel
                    {
                        Id = 1,
                        Title = "My first tweet",
                        Content = "Hello world",
                        CreatedAt = DateTime.Now,
                        LikesCount = 0,
                        User = new UserModel
                        {
                            UserId = 1,
                            Username = "johndoe",
                            FirstName = "Firs",
                            LastName = "Las",
                            Password = "XXXXXX",
                            Followee = new List<FollowUserModel>(),
                            Follower = new List<FollowUserModel>(),

                        },
                        Comments = new List<CommentModel>(),
                        Tags = new List<String>(new String []{"Tech", "News", "cSharp"})
                    }
                }
            };
            return View(otherUserDetail);
        }
    }
}