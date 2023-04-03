using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class User//  : System.Object
    {

        public User()
        {
            Console.WriteLine("Constructor called");
        }
        
        // public string? username { get; set; }
        // public int age { get; set; }

        // auto implemented properties
        public string? city { get; set; } // variable will be generated at COMPILE TIME

        private string? username;
        private int age;

        // properties
        public string? MyName
        {
            get {
                return username;
            }

            set {
                username = value;
            }

        }

        public int MyAge
        {
            get {
                return age;
            }

            set {
                if (value > 0)
                {                
                    age = value;
                }
                else 
                {
                    throw new Exception("age cannot be less than zero");
                }
            }

        }

        public override string ToString()
        {
            // return base.ToString() + " ----- name : " + username + " age : " + age;
            
            // interpolated string
            return $" ----- name : {username} age : {age}";
        }
    }
}
