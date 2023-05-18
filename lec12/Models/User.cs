using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec12.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool login(User user)
        {
            if (user.Password == "abc" && user.UserName == "abc")
            {
                return true;
            }
            return false;
        }
    }
}