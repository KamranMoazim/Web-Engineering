
using Microsoft.AspNetCore.Mvc;


// Follow Other Page
// Shared ReTweet
// Friends Tweets

namespace ProjectTweet.Controllers
{
    [Route("[controller]")]
    public class TweetController : Controller
    {

        public TweetController()
        {
        }

        [HttpGet("MyTweets")]
        public IActionResult MyTweets()
        {
            return View();
        }

        [HttpGet("ViewSingleTweet")]
        public IActionResult ViewSingleTweet()
        // int id,
        {
            return View();
        }

        [HttpGet("CreateTweet")]
        public IActionResult CreateTweet()
        {
            return View();
        }

        [HttpPost("CreateTweet")]
        public IActionResult CreateTweet(string title, string tags, string detail)
        {
            Console.WriteLine(title);
            Console.WriteLine(tags);
            Console.WriteLine(detail);

            return View();
        }

        [HttpGet("FriendsTweets")]
        public IActionResult FriendsTweets()
        {
            return View();
        }

        [HttpGet("SharedTweets")]
        public IActionResult SharedTweets()
        {
            return View();
        }


        [HttpPost("CommentTweet")]
        public IActionResult CommentTweet(string comment)
        {
            // Console.WriteLine(id);
            Console.WriteLine(comment);

            return View("SingleTweet");
        }

        [HttpGet("TagTweets/{tag}")]
        public IActionResult TagTweets(string tag)
        {
            return View();
        }
    }
}