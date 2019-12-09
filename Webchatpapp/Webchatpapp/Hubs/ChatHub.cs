using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Webchatpapp.Hubs
{
    //[Authorize]
    public class ChatHub : Hub
    {
        private static ConcurrentDictionary<string, UserData> _users = new ConcurrentDictionary<string, UserData>();
        private static int _usersCount = 0;

        //public override Task OnConnected()
        //{
        //    _usersCount++;
        //    var user = new UserData()
        //    {
        //        Active = true,
        //        Name = "user" + _usersCount,
        //        Color = "blue",
        //        ConnectedAt = DateTime.Now
        //    };
        //    _users[Context.ConnectionId] = user;
        //    return base.OnConnected();
        //}

        public override Task OnConnected()
        {
            _usersCount++;
            //Interlocked.Increment(ref _usersCount);
            var user = new UserData()
            {
                Active = true,
                Name = "user" + _usersCount,
                Color = "blue",
                ConnectedAt = DateTime.Now
            };
            _users[Context.ConnectionId] = user;
            return base.OnConnected();
        }
        [Authorize]
        public Task ChangeNickname(string newName)
        {
            UserData user;
            if (_users.TryGetValue(Context.ConnectionId, out user))
            {
                var oldName = user.Name;
                user.Name = newName;
                return Clients.All.Message(
                    oldName + " now is " + newName, "system");
            }
            return null;
        }
        public Task Send(string message)
        {
            UserData user;
            if (_users.TryGetValue(Context.ConnectionId, out user))
            {
                var m = string.Format("[{0}]: {1}", user.Name, message);
                return Clients.All.Message(m);
            }
            return null;
        }
    }

    public class UserData
    {
        public UserData()
        {
        }

        public bool Active { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime ConnectedAt { get; set; }
    }
}