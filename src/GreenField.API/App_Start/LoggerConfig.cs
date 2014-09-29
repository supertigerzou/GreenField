using GreenField.API.Middlewares;

namespace GreenField.API.App_Start
{
    public class LoggerConfig
    {
        public static LoggerOptions Init()
        {
            return new LoggerOptions
                {
                    RequestKeys = new[] {"owin.RequestPath", "owin.RequestMethod"},
                    ResponseKeys = new[] {"owin.ResponseStatusCode"}
                };
        }
    }
}