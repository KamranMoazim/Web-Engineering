
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("SingleTweet")]
        public IActionResult SingleTweet()
        // int id,
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

        [HttpGet("CreateTweet")]
        public IActionResult CreateTweet()
        {
            return View();
        }

        [HttpGet("TagTweet")]
        public IActionResult TagTweet(string tag)
        {
            return View("SingleTweet");
        }

        [HttpPost("CreateTweet")]
        public IActionResult CreateTweet(string title, string tags, string detail)
        {
            Console.WriteLine(title);
            Console.WriteLine(tags);
            Console.WriteLine(detail);

            return View();
        }
    }
}