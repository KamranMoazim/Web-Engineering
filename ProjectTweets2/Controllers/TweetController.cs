
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
        public IActionResult CreateTweet(string title, string tags, string detail)
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

            Tweets tweet = new Tweets();

            tweet.Content = detail;
            tweet.Title = title;
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
            if (CheckIfLoggedIn() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Console.WriteLine(id);
            string? cookie = HttpContext.Request.Cookies[cookieName];
            int userId = int.Parse(cookie!);

            Console.WriteLine(comment);

            tweetRepository.CreateNewComment(comment, tweetId, userId);

            Tweets tweetModel = tweetRepository.GetParticularTweet(tweetId);

            return View("SingleTweet", tweetModel);
        }

        [HttpGet("TagTweets/{tag}")]
        public IActionResult TagTweets(string tag)
        {
            var ListOfTweets = tweetRepository.GetAllTweetsOfParticularTag(tag);

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