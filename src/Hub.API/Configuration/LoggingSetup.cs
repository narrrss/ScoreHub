
using System;
using System.Xml.Linq;
using Serilog;

namespace Hub.API.Configuration
{
    public static class LoggingSetup
    {
        public static readonly string AppName = typeof(LoggingSetup).Namespace ?? "";

        public static IHostBuilder UseLoggingSetup(this IHostBuilder host, IConfiguration configuration)
        {
            host.UseSerilog((_, _, lc) =>
            {
                lc.MinimumLevel.Verbose()
                .Enrich.WithProperty("ApplicationContext", AppName)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration).CreateLogger();
                
            });

            return host;
        }
        private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
        {
            var seqServerUrl = configuration["Serilog:SeqServerUrl"];

            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("ApplicationContext", AppName)
                .Enrich.FromLogContext()
                .WriteTo.Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "http://seq" : seqServerUrl)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }

}

