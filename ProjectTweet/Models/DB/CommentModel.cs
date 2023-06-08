
namespace ProjectTweet.Models.DB
{
    public class CommentModel
    {
        public int Id { get; set; }
        // public int TweetId { get; set; }
        public string Comment { get; set; }
        public DateTime PostedDate { get; set; }
        public TweetUser User { get; set; }
    }
}