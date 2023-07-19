"use strict";

function getCookie(name = "userToken") {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}

let enableChat = false;

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();



//Disable the send button until connection is established.
// document.getElementById("sendButton").disabled = true;
document.getElementById("startChat").disabled = true;
document.getElementById("endChat").disabled = true;
document.getElementById("sendMessage").disabled = true;


connection.start().then(function () {
    // document.getElementById("sendButton").disabled = false;
    document.getElementById("startChat").disabled = false;
    document.getElementById("endChat").disabled = false;

    if (enableChat) {
        document.getElementById("sendMessage").disabled = true;
    }


}).catch(function (err) {
    return console.error(err.toString());
});




document.getElementById("sendMessage").addEventListener("click", function (event) {

    var senderUserId = getCookie();
    var message = document.getElementById("messageInput").value;
    var receiverUserId = document.getElementById("receiverId");

    // Extract the number using regular expressions
    const regex = /(\d+)/; // Match one or more digits
    const match = regex.exec(receiverUserId.innerText);
    const number = match ? match[0] : '';
    // console.log(number); // Output: 3






    const parentElement = document.getElementById('MyId');

    const childElement1 = document.createElement('div');
    childElement1.classList.add('col-md-6');
    childElement1.classList.add('offset-md-6');


    // Create the child element
    const childElement = document.createElement('div');
    childElement.classList.add('message-sender');

    // Create the message header element
    const messageHeader = document.createElement('div');
    messageHeader.classList.add('message-header');

    // Create the username element
    const usernameElement = document.createElement('h5');
    usernameElement.classList.add('message-username');
    // usernameElement.textContent = '@chatMessage.User.Username';
    usernameElement.textContent = message;

    // Create the message time element
    const timeElement = document.createElement('span');
    timeElement.classList.add('message-time');
    // timeElement.textContent = '@chatMessage.Time.ToString()';
    timeElement.textContent = new Date();

    // Append the username and time elements to the message header
    messageHeader.appendChild(usernameElement);
    messageHeader.appendChild(timeElement);

    // Create the message content element
    const contentElement = document.createElement('p');
    contentElement.classList.add('message-content');
    // contentElement.textContent = message;
    contentElement.textContent = message;

    // Append the message header and content elements to the child element
    childElement.appendChild(messageHeader);
    childElement.appendChild(contentElement);

    // Append the child element to the parent element
    childElement1.appendChild(childElement);

    const brElement = document.createElement('br');

    childElement1.appendChild(brElement);
    parentElement.appendChild(childElement1);






    // to invoke server-side message
    connection.invoke("SendMessage", senderUserId, number, message).catch(function (err) {
        // connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

    document.getElementById("messageInput").value = "";
});





document.getElementById("startChat").addEventListener("click", function (event) {

    var senderUserId = getCookie();
    var receiverUserId = document.getElementById("receiverId");

    // Extract the number using regular expressions
    const regex = /(\d+)/; // Match one or more digits
    const match = regex.exec(receiverUserId.innerText);
    const number = match ? match[0] : '';
    // console.log("AddToGroup" + senderUserId + number); // Output: 3

    enableChat = true;

    if (enableChat) {
        document.getElementById("sendMessage").disabled = false;
    }


    // to invoke server-side message
    connection.invoke("AddToGroup", senderUserId, number).catch(function (err) {
        // connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});




document.getElementById("endChat").addEventListener("click", function (event) {

    var senderUserId = getCookie();
    var receiverUserId = document.getElementById("receiverId");

    // Extract the number using regular expressions
    const regex = /(\d+)/; // Match one or more digits
    const match = regex.exec(receiverUserId.innerText);
    const number = match ? match[0] : '';
    // console.log("RemoveFromGroup" + senderUserId + number); // Output: 3

    enableChat = false;

    if (enableChat) {
        document.getElementById("sendMessage").disabled = true;
    }


    // to invoke server-side message
    connection.invoke("RemoveFromGroup", senderUserId, number).catch(function (err) {
        // connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});











// to catch response from server
connection.on("ReceiveMessage", function (message) {

    console.log("------------- " + message.username)
    console.log("------------- " + message.message)
    console.log("------------- " + message.time)
    console.log("------------- " + message.userId)

    var receiverUserId = document.getElementById("receiverId");
    const regex = /(\d+)/; // Match one or more digits
    const match = regex.exec(receiverUserId.innerText);
    const number = match ? match[0] : '';

    var senderUserId = getCookie();

    console.log("------------- " + number)
    console.log("------------- " + senderUserId)
    console.log("------------- " + message.userId)

    if (message.userId !== senderUserId) {

        const parentElement = document.getElementById('MyId');

        const childElement1 = document.createElement('div');
        childElement1.classList.add('col-md-6');


        // Create the child element
        const childElement = document.createElement('div');
        childElement.classList.add('message-receiver');

        // Create the message header element
        const messageHeader = document.createElement('div');
        messageHeader.classList.add('message-header');

        // Create the username element
        const usernameElement = document.createElement('h5');
        usernameElement.classList.add('message-username');
        // usernameElement.textContent = '@chatMessage.User.Username';
        usernameElement.textContent = message.username;

        // Create the message time element
        const timeElement = document.createElement('span');
        timeElement.classList.add('message-time');
        // timeElement.textContent = '@chatMessage.Time.ToString()';
        timeElement.textContent = message.time;

        // Append the username and time elements to the message header
        messageHeader.appendChild(usernameElement);
        messageHeader.appendChild(timeElement);

        // Create the message content element
        const contentElement = document.createElement('p');
        contentElement.classList.add('message-content');
        // contentElement.textContent = message;
        contentElement.textContent = message.message;

        // Append the message header and content elements to the child element
        childElement.appendChild(messageHeader);
        childElement.appendChild(contentElement);

        // Append the child element to the parent element
        childElement1.appendChild(childElement);

        const brElement = document.createElement('br');

        childElement1.appendChild(brElement);
        parentElement.appendChild(childElement1);

        console.log(parentElement)
    }


    // var li = document.createElement("li");
    // document.getElementById("MySenderId").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    // li.textContent = message;
});








