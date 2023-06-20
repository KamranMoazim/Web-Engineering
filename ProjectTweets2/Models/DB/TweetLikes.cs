
using ProjectTweets2.Models.GeneralModels;

namespace ProjectTweets2.Models.DB
{
    public class TweetLikes : Audit
    {
        public int TweetId { get; set; }
        // public Tweets Tweets { get; set; }

        public int UserId { get; set; }
        // public User User { get; set; }
    }
}