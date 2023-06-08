

namespace ProjectTweet.Models.DB
{
    public class TweetModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }
        public int LikesCount { get; set; }

        public UserModel User { get; set; }
        public List<CommentModel> Comments { get; set; }
        // public TweetModel()
        // {
        //     Comments = new List<CommentModel>();
        // }

    }
}