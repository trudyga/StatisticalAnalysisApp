using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using StatisticalAnalysisApplication.Filters.Exception;

namespace StatisticalAnalysisApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PrimaryAnalysisRoute",
                routeTemplate: "api/{controller}/{action}",
                defaults: new
                {
                    action = RouteParameter.Optional
                });
        }
    }
}
