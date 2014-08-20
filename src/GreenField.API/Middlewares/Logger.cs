using System.Collections.Generic;
using Microsoft.Owin;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GreenField.API.Middlewares
{
    public class LoggerOptions
    {
        public IList<string> RequestKeys { get; set; }
        public IList<string> ResponseKeys { get; set; }
        public Action<string, object> Log { get; set; }
    }

    public class Logger : OwinMiddleware
    {
        private readonly LoggerOptions _options;

        public Logger(OwinMiddleware next, LoggerOptions options) : base(next)
        {
            this._options = options;
        }

        public async override Task Invoke(IOwinContext context)
        {
            foreach (var key in _options.RequestKeys)
            {
                _options.Log(key, context.Environment[key]);
            }

            await Next.Invoke(context);

            foreach (var key in _options.ResponseKeys)
            {
                _options.Log(key, context.Environment[key]);
            }
        }
    }
}