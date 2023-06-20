

using ProjectTweets2.Models.GeneralModels;

namespace ProjectTweets2.Models.DB
{
    public class Messages : Audit
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string msg { get; set; }

        public int From { get; set; }
        public int To { get; set; }
    }
}