
using Microsoft.AspNetCore.Mvc;
using ProjectTweet.Models;
using ProjectTweet.Models.DB;

namespace ProjectTweet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
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
                    FirstName = "XXXX",
                    LastName = "XXX",
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
                    FirstName = "XXXX",
                    LastName = "XXX",
                    Password = "XXXXXX",
                    Followee = new List<FollowUserModel>(),
                    Follower = new List<FollowUserModel>(),

                },
                Comments = new List<CommentModel>(),
                Tags = new List<String>(new String []{"Tech", "News", "cSharp"})
            }
        };



        var TopTweets = new List<TweetModel>{
            new TweetModel
            {
                Id = 1,
                Title = "My first tweet",
                Content = "Hello world",
                CreatedAt = DateTime.Now,
                LikesCount = 8,
                User = new UserModel
                {
                    UserId = 1,
                    Username = "johndoe",
                    FirstName = "XXXX",
                    LastName = "XXX",
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
                LikesCount = 9,
                User = new UserModel
                {
                    UserId = 1,
                    Username = "johndoe",
                    FirstName = "XXXX",
                    LastName = "XXX",
                    Password = "XXXXXX",
                    Followee = new List<FollowUserModel>(),
                    Follower = new List<FollowUserModel>(),

                },
                Comments = new List<CommentModel>(),
                Tags = new List<String>(new String []{"Tech", "News", "cSharp"})
            }
        };

        var model = new HomePageModel
        {
            ListOfTweets = ListOfTweets,
            TopTweets = TopTweets
        };


        return View(model);
    }
}
