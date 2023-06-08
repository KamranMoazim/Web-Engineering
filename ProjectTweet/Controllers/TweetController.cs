
using Microsoft.AspNetCore.Mvc;
using ProjectTweet.Models;
using ProjectTweet.Models.DB;


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
            var ListOfTweets = new List<TweetModel>{
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
                },
                new TweetModel
                {
                    Id = 2,
                    Title = "My second tweet",
                    Content = "Hello world",
                    CreatedAt = DateTime.Now,
                    LikesCount = 0,
                    User = new UserModel
                    {
                        UserId = 1,
                        Username = "johndoe",
                        FirstName = "F1",
                        LastName = "L1",
                        Password = "XXXXXX",
                        Followee = new List<FollowUserModel>(),
                        Follower = new List<FollowUserModel>(),

                    },
                    Comments = new List<CommentModel>(),
                    Tags = new List<String>(new String []{"Tech", "News", "cSharp"})
                }
            };

            return View(ListOfTweets);
        }

        [HttpGet("SingleTweet")]
        public IActionResult ViewSingleTweet()
        // int id,
        {
            TweetModel tweetModel = new TweetModel
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
                Comments = new List<CommentModel>{
                    new CommentModel{
                        Id = 1,
                        Comment = "Amazing Tweet, This is the First Comment",
                        PostedDate = DateTime.Now,
                        // User = new UserModel{
                        //     UserId = 1,
                        //     Username = "johndoe",
                        //     FirstName = "Firs",
                        //     LastName = "Las",
                        //     Password = "XXXXXX",
                        //     Followee = new List<FollowUserModel>(),
                        //     Follower = new List<FollowUserModel>()
                        // }
                    }
                },
                Tags = new List<String>(new String[] { "Tech", "News", "cSharp" })
            };


            return View("SingleTweet", tweetModel);
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
            var ListOfTweets = new List<TweetModel>{
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
                },
                new TweetModel
                {
                    Id = 2,
                    Title = "My second tweet",
                    Content = "Hello world",
                    CreatedAt = DateTime.Now,
                    LikesCount = 0,
                    User = new UserModel
                    {
                        UserId = 1,
                        Username = "johndoe",
                        FirstName = "F1",
                        LastName = "L1",
                        Password = "XXXXXX",
                        Followee = new List<FollowUserModel>(),
                        Follower = new List<FollowUserModel>(),

                    },
                    Comments = new List<CommentModel>(),
                    Tags = new List<String>(new String []{"Tech", "News", "cSharp"})
                }
            };

            return View(ListOfTweets);
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