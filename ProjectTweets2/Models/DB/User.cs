using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweets2.Models.DB
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TagLine { get; set; }
        public DateTime JoinedDate { get; set; }


        public List<Comments> Comments { get; set; }

        public List<Tweets> Tweets { get; set; }






        public List<Tweets> LikedTweets { get; set; }

        public List<ReTweets> UserReTweets { get; set; }



        public List<User> Follower { get; set; }
        public List<User> Followee { get; set; }

    }
}