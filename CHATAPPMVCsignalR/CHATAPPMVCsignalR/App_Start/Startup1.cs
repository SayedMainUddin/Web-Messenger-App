using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CHATAPPMVCsignalR.App_Start.Startup1))]

namespace CHATAPPMVCsignalR.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
