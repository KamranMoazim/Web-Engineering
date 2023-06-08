
using ProjectTweet.Models.DB;

namespace ProjectTweet.Models
{
    public class HomePageModel
    {
        public List<TweetModel> ListOfTweets { get; set; }
        public List<TweetModel> TopTweets { get; set; }
    }
}