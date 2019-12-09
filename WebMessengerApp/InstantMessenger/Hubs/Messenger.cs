using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace InstantMessenger.Hubs
{
    public class Messenger : Hub
    {
        public void SendMessage(string user, string message)
        {
            Clients.All.Receive(user, message);
        }
    }
}