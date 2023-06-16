using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTweets2.Models.DB;

namespace ProjectTweets2.Models.ViewModel
{
    public class ChatMessage
    {
        public User User { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public bool IsSender { get; set; }
    }
}