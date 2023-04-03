using System.Collections;
using MyLibrary;

namespace lec4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var x = 30;
            x = 4;

            dynamic a = "fsdfds";
            a = 34;

            int[] arr = { 4, 5, 6, 7, 7 };
            foreach (var i in arr)
            {

            }

            ArrayList list = new ArrayList();
            list.Add(2);
            list.Add(2.3);
            list.Add(4.4f);

            List<int> list1 = new List<int>();
            list1.Add(2);
            // list1.Add(2.3);
            // list1.Add(4.4f);

            User user = new();

            Console.WriteLine("Enter Your Name : ");
            string? username = Console.ReadLine();
            Console.Write("Enter Age : ");
            string? stringAge = Console.ReadLine();

            int age = System.Convert.ToInt16(stringAge);
            // int age = int(stringAge);

            user.MyName = username;
            user.MyAge = age;

            User user1 = new User { MyName = username, MyAge = age, city = "Lahore" };

            Console.WriteLine(user.ToString());

        }
    }
}