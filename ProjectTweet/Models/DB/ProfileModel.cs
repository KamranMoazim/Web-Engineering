using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweet.Models.DB
{
    public class ProfileModel
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TagLine { get; set; }
        public DateTime JoinedDate { get; set; }


    }
}