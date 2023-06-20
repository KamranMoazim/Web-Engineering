
using System.ComponentModel.DataAnnotations;
using ProjectTweets2.Models.GeneralModels;

namespace ProjectTweets2.Models.DB
{
    public class Tweets : Audit
    {
        [Key]
        public int TweetId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedAt { get; set; }

        public Tags Tags { get; set; }

        public int LikesCount { get; set; }
        public int RetweetsCount { get; set; }
        public int CommentsCount { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public int TagsId { get; set; }


        public List<Comments> Comments { get; set; }



        public List<User> UserLikes { get; set; }

        public List<ReTweets> TweetReTweets { get; set; }
        public List<TweetLikes> TweetLikes { get; set; }
    }
}