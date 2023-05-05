

namespace ProjectTweet.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString() => $"UserId: {UserId}, Username: {Username}, Password: {Password}";
    }
}