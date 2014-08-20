using GreenField.API.Middlewares;
using Owin;
namespace GreenField.API
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseLogger(this IAppBuilder app, LoggerOptions options)
        {
            return app.Use<Logger>(options);
        }
    }
}