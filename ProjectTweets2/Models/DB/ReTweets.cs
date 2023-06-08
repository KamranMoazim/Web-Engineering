using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweets2.Models.DB
{
    public class ReTweets
    {
        public int TweetId { get; set; }
        // public Tweets Tweets { get; set; }

        public int UserId { get; set; }
        // public User User { get; set; }

        public DateTime PostedAt { get; set; }
    }
}