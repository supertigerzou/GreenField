using Autofac;
using Autofac.Integration.WebApi;
using GreenField.API.App_Start;
using GreenField.API.Middlewares;
using GreenField.API.Providers;
using GreenField.Books.Data;
using GreenField.Books.Services;
using GreenField.Framework.Caching;
using GreenField.Framework.Data;
using GreenField.Framework.Helpers;
using GreenField.Framework.Services;
using GreenField.Users.Data;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

//[assembly: OwinStartup(typeof(GreenField.API.Startup))]

namespace GreenField.API
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static GoogleOAuth2AuthenticationOptions GoogleAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();

            WebApiConfig.Register(config, builder);

            // Register a logger service to be used by the controller and middleware.
            builder.Register(c => new SimpleLogger()).As<ILogger>().InstancePerRequest();
            builder.Register(c => new WebHelper()).As<IWebHelper>().InstancePerRequest();
            builder.Register(c => new BookContext()).As<IDbContext>().InstancePerRequest();
            builder.RegisterType<AuthRepository>().As<IAuthRepository>().InstancePerRequest();
            builder.RegisterGeneric(typeof (EfRepository<>)).As(typeof (IRepository<>)).InstancePerRequest();
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();
            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerRequest();
            builder.RegisterType<BookService>().As<IBookService>().InstancePerRequest();
            builder.RegisterType<PictureService>().As<IPictureService>().InstancePerRequest();

            // Autofac will add middleware to IAppBuilder in the order registered.
            // The middleware will execute in the order added to IAppBuilder.
            builder.RegisterType<Logger>().InstancePerRequest();

            var container = builder.Build();

            // Create an assign a dependency resolver for Web API to use.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            ConfigureOAuth(app);

            // This should be the first middleware added to the IAppBuilder.
            app.UseAutofacMiddleware(container);

            // Make sure the Autofac lifetime scope is passed to Web API.
            app.UseAutofacWebApi(config);

            app.UseCors(CorsOptions.AllowAll);
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
                    Provider = new SimpleAuthrizationServerProvider(new AuthRepository())
                };
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

            //Configure Google External Login
            GoogleAuthOptions = new GoogleOAuth2AuthenticationOptions
                {
                ClientId = "674805668859-gdbb5tsqglgn5dbsibqnkkuvmeu0qskd.apps.googleusercontent.com",
                ClientSecret = "HdD4ZAQBtlT4YM7-i2Y1n9Zb",
                Provider = new GoogleAuthProvider()
            };
            app.UseGoogleAuthentication(GoogleAuthOptions);
        }
    }
}