using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTweets2.Models.DB;

namespace ProjectTweets2.Models.ViewModel
{
    public class HomePageModel
    {
        public List<Tweets> ListOfTweets { get; set; }
        public List<Tweets> TopTweets { get; set; }
    }
}