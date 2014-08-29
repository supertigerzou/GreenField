using System.Data.Entity;
using System.Diagnostics;
using GreenField.API.App_Start;
using GreenField.API.Middlewares;
using GreenField.API.Providers;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using GreenField.Users.Data;

//[assembly: OwinStartup(typeof(GreenField.API.Startup))]

namespace GreenField.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            var logOptions = new LoggerOptions
                {
                    Log = (key, value) => Debug.WriteLine("{0}: {1}", key, value),
                    RequestKeys = new[] { "owin.RequestPath", "owin.RequestMethod" },
                    ResponseKeys = new[] { "owin.ResponseStatusCode" }
                };
            app.UseLogger(logOptions);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, Users.Migrations.Configuration>());
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            var options = new OAuthAuthorizationServerOptions
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                    Provider = new SimpleAuthrizationServerProvider()
                };

            app.UseOAuthAuthorizationServer(options);
        }
    }
}