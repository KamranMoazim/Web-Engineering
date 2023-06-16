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


            // MyTweetsDbContext _context = new MyTweetsDbContext();
            // await _context.GroupName.AddAsync(new GroupName { Groupname = groupName });

            // Users.Add(groupName);

            Console.WriteLine("AddToGroup : " + userId1 + userId2);
            Console.WriteLine("Sorted AddToGroup : " + sortedStr);

            // add user to group
            await Groups.AddToGroupAsync(Context.ConnectionId, sortedStr);
            // send message to this group users
            // await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }


        public async Task RemoveFromGroup(string userId1, string userId2)
        {
            // string groupName = userId1 + userId2;
            // Console.WriteLine("RemoveFromGroup : " + userId1 + userId2);

            // MyTweetsDbContext _context = new MyTweetsDbContext();
            // GroupName? groupName1 = await _context.GroupName.Where(x => x.Groupname == groupName).FirstOrDefaultAsync();
            // _context.GroupName.Remove(groupName1);

            // Users.Remove(groupName);

            string groupName = userId1 + userId2;

            char[] charArray = groupName.ToCharArray();

            Array.Sort(charArray);

            string sortedStr = new string(charArray);

            Console.WriteLine("RemoveFromGroup : " + userId1 + userId2);
            Console.WriteLine("Sorted RemoveFromGroup : " + sortedStr);


            await Groups.RemoveFromGroupAsync(Context.ConnectionId, sortedStr);
            // await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }

        public async Task SendMessage(string userId1, string userId2, string message)
        // public async Task SendMessage(string message)
        {

            MyTweetsDbContext _context = new MyTweetsDbContext();

            // GroupName? groupName1 = await _context.GroupName.Where(x => x.Groupname == userId1 + userId2).FirstOrDefaultAsync();
            // GroupName? groupName2 = await _context.GroupName.Where(x => x.Groupname == userId2 + userId1).FirstOrDefaultAsync();

            // string userId1 = "1", userId2 = "2";

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

            // if (groupName1 == null && groupName2 == null)
            // {
            //     await AddToGroup(userId1, userId2);
            // }
            // else
            // {

            //     string groupName = userId1 + userId2;

            //     if (groupName1 == null)
            //     {
            //         groupName = userId2 + userId1;
            //         await Clients.Group(groupName).SendAsync("ReceiveMessage", $"{message}");
            //     }
            //     else
            //     {
            //         await Clients.Group(groupName).SendAsync("ReceiveMessage", $"{message}");
            //     }

            //     Console.WriteLine("SendMessage : " + userId1 + userId2 + message);

            // }
        }
    }
}




// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.SignalR;

// namespace SignalrChatAppwithGroupUser.Hubs
// {
//     public class ChatHub : Hub
//     {
//         public Task SendMessageToGroup(string groupName, string message)
//         {
//             return Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId}: {message}");
//         }

//         public async Task AddToGroup(string groupName)
//         {
//             await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

//             await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
//         }

//         public async Task RemoveFromGroup(string groupName)
//         {
//             await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

//             await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
//         }

//         public Task SendPrivateMessage(string user, string message)
//         {     
//             return Clients.User(user).SendAsync("ReceiveMessage", message);
//         }
//     }
// }