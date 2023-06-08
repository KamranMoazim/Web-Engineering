using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTweets2.Models.DB;

namespace ProjectTweets2.Models.ViewModel
{
    public class OtherUserDetail
    {
        public User Profile { get; set; }
        public List<Tweets> Tweets { get; set; }
    }
}