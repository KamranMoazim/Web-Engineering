using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectTweets2.Models;
using ProjectTweets2.Models.DB;
using ProjectTweets2.Models.Repositories;
using ProjectTweets2.Models.ViewModel;

namespace ProjectTweets2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // private MyTweetsDbContext _context;
    private readonly TweetRepository tweetRepository;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        // _context = new MyTweetsDbContext();
        tweetRepository = new TweetRepository();

    }

    public IActionResult Index()
    {


        var ListOfTweets = tweetRepository.GetRecentTweets(20);
        var TopTweets = tweetRepository.GetTopTweets(5);


        var model = new HomePageModel
        {
            ListOfTweets = ListOfTweets,
            TopTweets = TopTweets
        };


        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
