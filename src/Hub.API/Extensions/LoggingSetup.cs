using Serilog;

namespace Hub.API.Extensions;

public static class LoggingSetup
{
    public static IHostBuilder UseLoggingSetup(this IHostBuilder host, IConfiguration configuration)
    {
        host.UseSerilog((_, _, lc) =>
        {
            var value = typeof(Program).Namespace;
            if (value != null)
                lc.ReadFrom.Configuration(configuration)
                    .MinimumLevel.Verbose()
                    .Enrich.WithProperty("ApplicationContext", value)
                    .Enrich.FromLogContext()
                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day); // Configure file sink here
        });

        return host;
    }
}