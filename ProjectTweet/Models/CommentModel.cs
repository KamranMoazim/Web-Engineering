
namespace ProjectTweet.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int TweetId { get; set; }
        public UserModel User { get; set; }
        public string Comment { get; set; }
        public DateTime PostedDate { get; set; }
    }
}