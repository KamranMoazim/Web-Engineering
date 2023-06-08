// friends
// likes
// share

using System.Collections.Generic;

namespace ProjectTweet.Models.DB
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<FollowUserModel> Follower { get; set; }
        public List<FollowUserModel> Followee { get; set; }
        public string Password { get; set; }

        public override string ToString() => $"UserId: {UserId}, Username: {Username}, Password: {Password}";
    }
}