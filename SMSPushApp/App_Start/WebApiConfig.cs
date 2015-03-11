using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SMSPushApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
//            config.Routes.MapHttpRoute(
//  "API",
//  "API/{action}",
//  new { controller = "API" }
//);

//   //         GlobalConfiguration.Configuration.Routes.MapHttpRoute(
//   //  name: "DefaultApi",
//   //  routeTemplate: "api/{controller}/{id}",
//   //  defaults: new { id = System.Web.Http.RouteParameter.Optional }
//   //);
        }
    }
}
