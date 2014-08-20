using Microsoft.Owin;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GreenField.API.Middlewares
{
    public class LoggerOptions
    {
        public Action<string, object> Log { get; set; }
    }

    public class Logger : OwinMiddleware
    {
        private readonly LoggerOptions _options;

        public Logger(OwinMiddleware next, LoggerOptions options) : base(next)
        {
            this._options = options;
        }

        public override Task Invoke(IOwinContext context)
        {
            _options.Log("owin.RequestPath", context.Environment["owin.RequestPath"]);

            return Next.Invoke(context);
        }
    }
}