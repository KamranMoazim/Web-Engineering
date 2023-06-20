
using ProjectTweets2.Models.GeneralModels;

namespace ProjectTweets2.Models.DB
{
    public class GroupName : Audit
    {
        public int Id { get; set; }
        public string Groupname { get; set; }
    }
}