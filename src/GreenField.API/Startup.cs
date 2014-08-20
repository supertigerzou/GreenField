using System.Diagnostics;
using GreenField.API.App_Start;
using GreenField.API.Middlewares;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

//[assembly: OwinStartup(typeof(GreenField.API.Startup))]

namespace GreenField.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var logOptions = new LoggerOptions
                {
                    Log = (key, value) => Debug.WriteLine("{0}: {1}", key, value)
                };
            app.UseLogger(logOptions);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}