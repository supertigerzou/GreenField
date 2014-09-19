using GreenField.API.App_Start;
using GreenField.API.Middlewares;
using GreenField.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Diagnostics;
using System.Web.Http;

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
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookContext, Configuration>());
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