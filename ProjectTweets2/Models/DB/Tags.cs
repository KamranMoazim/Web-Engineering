using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTweets2.Models.DB
{
    public class Tags
    {
        [Key]
        public int TagsId { get; set; }

        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }

        public override string ToString()
        {
            return Tag1 + " " + Tag2 + " " + Tag3;
        }

        // public Tweets Tweet { get; set; }
    }
}