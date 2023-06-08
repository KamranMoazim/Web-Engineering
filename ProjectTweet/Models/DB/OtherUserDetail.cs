using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweet.Models.DB
{
    public class OtherUserDetail
    {
        public ProfileModel Profile { get; set; }
        public List<TweetModel> Tweets { get; set; }
    }
}