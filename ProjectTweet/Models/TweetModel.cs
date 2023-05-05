

namespace ProjectTweet.Models
{
    public class TweetModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserModel User { get; set; }
        public List<CommentModel> Comments { get; set; }
        public TweetModel()
        {
            Comments = new List<CommentModel>();
        }

    }
}