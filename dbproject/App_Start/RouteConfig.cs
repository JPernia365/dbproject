using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace dbproject
{
    public class RouteConfig
    {

   


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute("ByType", "coffee/type/{bean}/{size}", new{controller = "Coffee",action = "ByType"});

            routes.MapRoute(name: "Default",url: "{controller}/{action}/{id}",//must be same id in name in controller
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );






        }
    }
}
