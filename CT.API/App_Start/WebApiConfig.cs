using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CT.Infra.CrossCutting.IoC;
using Unity.WebApi;

namespace CT.API
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

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(new Container().GetModule());

        }
    }
}
