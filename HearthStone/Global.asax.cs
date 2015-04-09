using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using HearthStone.Engine.Services;
using HearthStone.Hub;
using Microsoft.AspNet.SignalR;

namespace HearthStone
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GameLogService.Log += GameLogServiceOnLog;
        }

        private void GameLogServiceOnLog(string text)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
            context.Clients.All.broadcastMessage("Game info:", text);
        }
    }
}