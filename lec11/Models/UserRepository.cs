using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec11.Models
{
    public class UserRepository
    {

        public List<User> Users { get; set; } = new List<User>{
            new User{UserName = "abc",Password="abc"},
            new User{UserName = "abc1",Password="abc1"},
        };

        public UserRepository()
        {
        }

        public bool SignIn(User user)
        {
            foreach (var eachUser in Users)
            {
                if (eachUser.UserName == user.UserName)
                {
                    if (eachUser.Password == user.Password)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }


    }
}