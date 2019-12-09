using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebChatAppCore.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
       


        public override async Task OnConnectedAsync()
        {

            await base.OnConnectedAsync();
            await Clients.Caller.SendAsync("ReceiveMessage", "", "Success");
            await Clients.Others.SendAsync("ReceiveMessage", "", "new user");
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            await Clients.Caller.SendAsync("ReceiveMessage", "", "disconnect");
            await Clients.Others.SendAsync("ReceiveMessage", "", "user left");
        }
    }
}
