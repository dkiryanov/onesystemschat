using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BLL.Infrastructure;
using Microsoft.AspNet.SignalR;
using OneSystemsChat.App_Start;

namespace OneSystemsChat
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutomapperConfig.RegisterMappings();
            AutomapperBllConfig.RegisterMappings();

            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(60*60*60);
        }
    }
}
