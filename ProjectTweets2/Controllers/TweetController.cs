
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectTweets2.Models.DB;
using ProjectTweets2.Models.Repositories;

namespace ProjectTweets2.Controllers
{
    [Route("[controller]")]
    public class TweetController : Controller
    {
        private readonly String cookieName = "userToken";
        private readonly ILogger<TweetController> _logger;
        private readonly TweetRepository tweetRepository;

        public TweetController(ILogger<TweetController> logger)
        {
            _logger = logger;
            tweetRepository = new TweetRepository();
        }



        [HttpGet("MyTweets")]
        public IActionResult MyTweets()
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);
            var ListOfTweets = tweetRepository.GetAllMyTweets(userId);

            return View(ListOfTweets);
        }


        [HttpGet("MySharedTweets")]
        public IActionResult MySharedTweets()
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);
            var ListOfTweets = tweetRepository.GetAllMySharedTweets(userId);

            return View(ListOfTweets);
        }

        [HttpPost("MyTweets/{tweetId}")]
        public IActionResult DeleteMyTweet(int tweetId)
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);

            tweetRepository.DeleteTweet(tweetId);

            var ListOfTweets = tweetRepository.GetAllMyTweets(userId);

            return View("MyTweets", ListOfTweets);
        }

        [HttpPost("MySharedTweets/{tweetId}")]
        public IActionResult DeleteMySharedTweets(int tweetId)
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);

            tweetRepository.DeleteSharedTweet(tweetId);

            var ListOfTweets = tweetRepository.GetAllMySharedTweets(userId);

            return View("MySharedTweets", ListOfTweets);
        }

        [HttpGet("SingleTweet/{tweetId}")]
        public IActionResult ViewSingleTweet(int tweetId)
        // int id,
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            Tweets tweetModel = tweetRepository.GetParticularTweet(tweetId);

            return View("SingleTweet", tweetModel);
        }

        [HttpGet("CreateTweet")]
        public IActionResult CreateTweet()
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }

        [HttpPost("CreateTweet")]
        public IActionResult CreateTweet(string title, string tags, string detail, IFormFile file)
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Console.WriteLine(title);
            // Console.WriteLine(tags);
            // Console.WriteLine(detail);

            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);
            var newTags = tags.Split(",");

            string filePath = "";
            string fileName = "";



            if (file != null && file.Length > 0)
            {
                Console.WriteLine("file.Length : " + file.Length);
                fileName = Path.GetFileName(file.FileName);
                filePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot", "Images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Console.WriteLine("File uploaded successfully!");

                // Console.WriteLine("Directory.GetCurrentDirectory(): " + Directory.GetCurrentDirectory() + "/wwwroot");
                // Console.WriteLine("File name: " + fileName);
                // Console.WriteLine("File path: " + filePath);
            }

            Tweets tweet = new Tweets();

            tweet.Content = detail;
            tweet.Title = title;
            tweet.ImageName = fileName;
            tweet.ImagePath = filePath;
            tweet.LikesCount = 0;
            tweet.Tags = new Tags();
            tweet.Tags.Tag1 = newTags[0];
            tweet.Tags.Tag2 = newTags[1];
            tweet.Tags.Tag3 = newTags[2];
            tweet.UserId = userId;
            tweet.RetweetsCount = 0;
            tweet.PostedAt = DateTime.Now;

            tweetRepository.CreateNewTweet(tweet);

            return View();
        }

        [HttpGet("FriendsTweets")]
        public IActionResult FriendsTweets()
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);

            var ListOfTweets = tweetRepository.GetTweetsOfMyFriends(userId);

            return View(ListOfTweets);
        }

        [HttpGet("SharedTweets")]
        public IActionResult SharedTweets()
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);

            var ListOfTweets = tweetRepository.GetSharedTweetsOfMyFriends(userId);

            return View(ListOfTweets);
        }


        // [HttpPost("CommentTweet")]
        [HttpPost("SingleTweet/{tweetId}/CommentTweet")]
        public IActionResult CommentTweet(int tweetId, string comment)
        {
            // return RedirectToRoute("SingleTweet", new { tweetId = tweetId });

            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Console.WriteLine(id);
            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);

            Console.WriteLine(tweetId);
            Console.WriteLine(comment);

            tweetRepository.CreateNewComment(comment, tweetId, userId);

            Tweets tweetModel = tweetRepository.GetParticularTweet(tweetId);


            return View("SingleTweet", tweetModel);
            // return RedirectToRoute("SingleTweet");
        }

        [HttpPost("SingleTweet/{tweetId}/LikeTweet")]
        public IActionResult LikeTweet(int tweetId)
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Console.WriteLine(id);
            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);


            tweetRepository.LikeTweet(userId, tweetId);

            Tweets tweetModel = tweetRepository.GetParticularTweet(tweetId);


            return View("SingleTweet", tweetModel);
            // return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost("SingleTweet/{tweetId}/ShareTweet")]
        public IActionResult ShareTweet(int tweetId)
        {
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Console.WriteLine(id);
            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);


            tweetRepository.ShareATweet(userId, tweetId);

            Tweets tweetModel = tweetRepository.GetParticularTweet(tweetId);


            return View("SingleTweet", tweetModel);
            // return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet("TagTweets/{tag}")]
        public IActionResult TagTweets(string tag)
        {
            Console.WriteLine("tag : " + tag);
            var ListOfTweets = tweetRepository.GetAllTweetsOfParticularTag(tag);

            Console.WriteLine("ListOfTweets : " + ListOfTweets.Count);

            return View(ListOfTweets);
        }




        private int CheckIfLoggedIn()
        {
            if (HttpContext.Request.Cookies.ContainsKey(cookieName))
            {
                string? cookie = HttpContext.Request.Cookies[cookieName];
                return int.Parse(cookie!);
            }

            return 0;
        }
    }
}