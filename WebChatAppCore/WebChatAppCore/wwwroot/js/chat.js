"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
//var connection = $.connection("/chatHub");
connection.start()
    .then(function () {
        var username;
        while (username === undefined || username === '' || username === 'user') {
            username = prompt("Enter name", 'user');
        } 
        //$("#userName").val(username);
        $("#sendButton").prop('disabled' , false);
        //$("#sendButton").attr('disabled' , false);
        //$("#sendButton").removeAttr('disabled' );

        $("#sendButton").on("click", function () {
            //var user = $("#userName").val();
            var message = $("#messageInput").val();
            $("#messageInput").val(null);
            connection.invoke("SendMessage", username, message)
                .catch(function (err) {
                    return console.error(err.toString());
                });
        });
        connection.on("ReceiveMessage", function (user, message) {

            var li = '<li><b class="text-success">' + user + ' : </b><i class="text-info">' + message + '</i></li>';
            $("#messagesList").append(li);

        });
    })
    .catch(function (err) {
        return console.error(err.toString());
    });

