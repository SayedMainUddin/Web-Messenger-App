using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CHATAPPMVCsignalR.Models;
using Microsoft.AspNet.SignalR;

namespace CHATAPPMVCsignalR.Hubs
{
    public class Messenger : Hub
    {
        private MessageContext db = new MessageContext();

        public void GetLog()
        {
            List<Log> logData = db.Logs.ToList();
           //Log[] logData = db.Logs.ToList().ToArray;
            Clients.Caller.ReceiveLog(logData);

        }
     public void SendMessage(string user,string message)
        {
            Log log = new Log()
            {
                Sender = user,
                Content = message
            };
            db.Logs.Add(log);
            db.SaveChanges();

            Clients.All.Receive(user, message);
        }
    }
}