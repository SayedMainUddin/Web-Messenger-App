using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NewChatAppMvcSignalR.App_Start.Startup1))]

namespace NewChatAppMvcSignalR.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
