using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Endeavour.OBSERVER
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

         config.Routes.MapHttpRoute(
           name: "TopicApi",
           routeTemplate: "api/topics/{id}",
            defaults: new { controller = "topics", id = RouteParameter.Optional }
           );

         config.Routes.MapHttpRoute(
            name: "FormFields",
           routeTemplate: "api/topics/{formid}/formfields/{id}",
           defaults: new { controller = "FormFields", id = RouteParameter.Optional }
        );

        }
    }
}
