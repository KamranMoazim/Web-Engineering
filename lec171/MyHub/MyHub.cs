
using Microsoft.AspNetCore.SignalR;

namespace lec171.MyHub
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string message) // methods which we wants to allow clients to call
        {
            // ReceiveMessage - a function name - which will be defined in client side
            await Clients.All.SendAsync("ReceiveMessage", message); // to all 
            // await Clients.Others.SendAsync("ReceiveMessage", message); // other than which send the message , will receive message
            // await Clients.Caller.SendAsync("ReceiveMessage", message); // only which have called , will receive message
            // await Clients.OthersInGroup.SendAsync("ReceiveMessage", message);
        }

        public async Task AddToGroup(string groupName)
        {
            // add user to group
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            // send message to this group users
            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }


        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }

        public Task SendMessageToGroup(string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId}: {message}");
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