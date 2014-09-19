using GreenField.API.Middlewares;
using System.Diagnostics;

namespace GreenField.API.App_Start
{
    public class LoggerConfig
    {
        public static LoggerOptions Init()
        {
            return new LoggerOptions
                {
                    Log = (key, value) => Debug.WriteLine("{0}: {1}", key, value),
                    RequestKeys = new[] {"owin.RequestPath", "owin.RequestMethod"},
                    ResponseKeys = new[] {"owin.ResponseStatusCode"}
                };
        }
    }
}