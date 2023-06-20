
using System.ComponentModel.DataAnnotations;
using ProjectTweets2.Models.GeneralModels;

namespace ProjectTweets2.Models.DB
{
    public class User : Audit
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TagLine { get; set; }
        public DateTime JoinedDate { get; set; }


        public List<Comments> Comments { get; set; }

        public List<Tweets> Tweets { get; set; }







        public List<ReTweets> UserReTweets { get; set; }
        public List<TweetLikes> LikedTweets { get; set; }



        public List<User> Follower { get; set; }
        public List<User> Followee { get; set; }


        // [ForeignKey("ToUserId")]
        // public List<Messages> SentMessages { get; set; }
        // public List<Messages> ReceivedMessages { get; set; }


        // [ForeignKey("FromUserId")]

    }
}