﻿using Autofac;
using Autofac.Integration.WebApi;
using GreenField.Framework.Helpers;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace GreenField.API.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, ContainerBuilder builder)
        {
            // Get the executable assembly location
            var serviceAssembliesPath = WebHelper.MapPath("~/") + @"bin\";

            // The Assembly to load
            string path = serviceAssembliesPath + @"\GreenField.Books.dll";

            config.Services.Replace(typeof(IAssembliesResolver), new CustomAssemblyResolver(path));
            
            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.LoadFrom(path));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }
    }
}