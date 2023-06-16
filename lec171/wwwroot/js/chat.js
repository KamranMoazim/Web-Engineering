"use strict";

function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}



var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();



//Disable the send button until connection is established.
// document.getElementById("sendButton").disabled = true;
document.getElementById("sendMessageToGroup").disabled = true;
document.getElementById("addToGroup").disabled = true;
document.getElementById("removeFromGroup").disabled = true;

connection.start().then(function () {
    // document.getElementById("sendButton").disabled = false;
    document.getElementById("sendMessageToGroup").disabled = false;
    document.getElementById("addToGroup").disabled = false;
    document.getElementById("removeFromGroup").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});


// to catch response from server
connection.on("ReceiveMessage", function (message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = message;
});


// to catch response from server
connection.on("Send", function (message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = message;
});







// document.getElementById("sendButton").addEventListener("click", function (event) {
//     var user = document.getElementById("userInput").value;
//     var message = document.getElementById("messageInput").value;
//     // to invoke server-side message
//     connection.invoke("SendMessage", `${user} says ${message}`).catch(function (err) {
//         return console.error(err.toString());
//     });
//     event.preventDefault();
// });




document.getElementById("sendMessageToGroup").addEventListener("click", function (event) {
    var group = document.getElementById("groupInput").value;
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    // to invoke server-side message
    connection.invoke("SendMessageToGroup", group, `In Group ${group} - ${user} says ${message}`).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


document.getElementById("addToGroup").addEventListener("click", function (event) {
    var group = document.getElementById("groupInput").value;
    // to invoke server-side message
    connection.invoke("AddToGroup", group).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("removeFromGroup").addEventListener("click", function (event) {
    var group = document.getElementById("groupInput").value;
    // to invoke server-side message
    connection.invoke("RemoveFromGroup", group).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
