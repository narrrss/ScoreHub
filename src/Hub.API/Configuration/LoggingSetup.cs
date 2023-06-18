
using System;
using Serilog;

namespace Hub.API.Configuration
{
    public static class LoggingSetup
    {
        public static IHostBuilder UseLoggingSetup(this IHostBuilder host, IConfiguration configuration)
        {
            host.UseSerilog((_, _, lc) =>
            {
                lc.ReadFrom.Configuration(configuration);
            });

            return host;
        }

    }
}

