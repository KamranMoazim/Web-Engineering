
using System.ComponentModel.DataAnnotations;
using ProjectTweets2.Models.GeneralModels;

namespace ProjectTweets2.Models.DB
{
    public class Comments : Audit
    {
        [Key]
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime PostedAt { get; set; }

        public int TweetId { get; set; }
        public Tweets Tweets { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}