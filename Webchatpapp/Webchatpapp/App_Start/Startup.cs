using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Webchatpapp.App_Start.Startup))]

namespace Webchatpapp.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR("/myhub",new HubConfiguration(){EnableJSONP = true,EnableDetailedErrors = true});
        }
    }
}
