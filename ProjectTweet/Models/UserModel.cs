

namespace ProjectTweet.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<TweetModel> Tweets { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}