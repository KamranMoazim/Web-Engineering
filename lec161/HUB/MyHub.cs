
using Microsoft.AspNetCore.SignalR;


namespace lec161.HUB
{

    // libman install @microsoft/signalr@latest -p unpkg -d wwwroot/js/signalr --files dist/browser/signalr.js --files dist/browser/signalr.min.js

    public class MyHub : Hub
    {
        // SignalR - to enable real-time communication b/w client and server
        // Hub - high level pipeline b/w client and server, we define functions which we can use from client side
        // we uses web-sockets
        // if web-sockets are available then use them, 
        //      else use Server-Sent-Events, send information after some time
        //      else use Long-Polling, 


        // Async/Await
        // Async - which can be 
        // Task - we will complete this in future
        // Await - which may take time

        // unpkg - to get the client side library
        // how to add client side library in vscode

        // dist/browse/signalr.js, signalr.min.js

        // dotnet add package Microsoft.AspNet.SignalR.JS

        // https://github.com/shujamughal/EAD/tree/master/73_SignalR

        // use strict in js file
        // means error will be checked

        public async Task SendMessage(string message) // methods which we wants to allow clients to call
        {
            // ReceiveMessage - a function name - which will be defined in client side
            await Clients.All.SendAsync("ReceiveMessage", message); // to all 
            // await Clients.Others.SendAsync("ReceiveMessage", message); // other than which send the message , will receive message
            // await Clients.Caller.SendAsync("ReceiveMessage", message); // only which have called , will receive message
            // await Clients.OthersInGroup.SendAsync("ReceiveMessage", message);
        }

    }
}