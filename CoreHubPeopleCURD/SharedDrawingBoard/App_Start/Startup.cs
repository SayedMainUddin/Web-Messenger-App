﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using SharedDrawingBoard.Hubs;

[assembly: OwinStartup(typeof(SharedDrawingBoard.App_Start.Startup))]

namespace SharedDrawingBoard.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.MapSignalR();
            //app.MapSignalR("/drawingBoard", new HubConfiguration());
        }
    }
}
