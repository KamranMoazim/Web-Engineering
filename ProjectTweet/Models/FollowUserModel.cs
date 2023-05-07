using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweet.Models
{
    public class FollowUserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
    }
}