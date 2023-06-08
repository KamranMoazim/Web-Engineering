using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweets2.Models.DB
{
    public class UserSet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollwerId { get; set; }
    }
}