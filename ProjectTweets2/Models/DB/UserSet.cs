

using ProjectTweets2.Models.GeneralModels;

namespace ProjectTweets2.Models.DB
{
    public class UserSet : Audit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollwerId { get; set; }
    }
}