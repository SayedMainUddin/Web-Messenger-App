using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using NewChatAppMvcSignalR.Models;

namespace NewChatAppMvcSignalR.Hubs
{
    public class Messenger : Hub
    {
        private MessageContext db = new MessageContext();

        public void GetLog()
        {
            List<Log> logData = db.Logs.ToList();
            Clients.Caller.ReceiveLog(logData);
        }
       public void sendMessage(string user, string message)
         {
            Log log = new Log()
            {
                Sender = user,
                Content = message
            };
            db.Logs.Add(log);
            db.SaveChanges();
            Clients.All.Receive(log);
        }
    }
}