using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweet.Models
{
    public class HomePageModel
    {
        public List<TweetModel> ListOfTweets { get; set; }
        public List<TweetModel> TopTweets { get; set; }
    }
}