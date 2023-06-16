using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweets2.MyHub
{
    public class SendMsgType
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}