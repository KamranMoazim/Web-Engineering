using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec11.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public override string? ToString()
        {
            return $"UserName : {UserName}, Password : {Password}";
        }
    }
}