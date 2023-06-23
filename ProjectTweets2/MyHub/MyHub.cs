using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectTweets2.Models.DB;

namespace ProjectTweets2.MyHub
{
    public class MyHub : Hub
    {

        public async Task AddToGroup(string userId1, string userId2)
        {

            string groupName = userId1 + userId2;

            char[] charArray = groupName.ToCharArray();

            Array.Sort(charArray);

            string sortedStr = new string(charArray);

            // Users.Add(groupName);

            Console.WriteLine("AddToGroup : " + userId1 + userId2);
            Console.WriteLine("Sorted AddToGroup : " + sortedStr);

            // add user to group
            await Groups.AddToGroupAsync(Context.ConnectionId, sortedStr);
        }


        public async Task RemoveFromGroup(string userId1, string userId2)
        {

            string groupName = userId1 + userId2;

            char[] charArray = groupName.ToCharArray();

            Array.Sort(charArray);

            string sortedStr = new string(charArray);

            Console.WriteLine("RemoveFromGroup : " + userId1 + userId2);
            Console.WriteLine("Sorted RemoveFromGroup : " + sortedStr);


            await Groups.RemoveFromGroupAsync(Context.ConnectionId, sortedStr);
        }

        public async Task SendMessage(string userId1, string userId2, string message)
        // public async Task SendMessage(string message)
        {

            MyTweetsDbContext _context = new MyTweetsDbContext();


            string groupName = userId1 + userId2;

            char[] charArray = groupName.ToCharArray();

            Array.Sort(charArray);

            string sortedStr = new string(charArray);

            Console.WriteLine("SendMessage : " + userId1 + userId2);
            Console.WriteLine("Sorted SendMessage : " + sortedStr);

            DateTime now = DateTime.Now;

            _context.Messages.Add(new Messages { To = int.Parse(userId2), From = int.Parse(userId1), msg = message, Time = now });

            _context.SaveChanges();

            User? user = _context.User.Find(int.Parse(userId1));

            var ms = new SendMsgType { UserId = int.Parse(userId1), Username = user.Username, Message = message, Time = now };

            await Clients.GroupExcept(sortedStr, Context.ConnectionId).SendAsync("ReceiveMessage", ms);

        }
    }
}
