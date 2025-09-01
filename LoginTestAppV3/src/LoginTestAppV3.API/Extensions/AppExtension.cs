using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;

namespace LoginTestAppV3.API.Extensions;

public static class AppExtension
{
    public static void SerilogConfigration(this IHostBuilder host, IConfiguration config)
    {
        host.UseSerilog(configureLogger: (context, loggerConfig) =>
        {
            loggerConfig.WriteTo.Console();
            loggerConfig.WriteTo.File(new JsonFormatter(), "Logs/log-.txt", rollingInterval: RollingInterval.Day);
            //loggerConfig.WriteTo.MSSqlServer(config.GetConnectionString("LogConnection"), new MSSqlServerSinkOptions { AutoCreateSqlDatabase = true, AutoCreateSqlTable = true, TableName = "LoginAppV3Logs" });
            loggerConfig.WriteTo.MSSqlServer(
                connectionString: config.GetConnectionString("LogConnection"),
                sinkOptions: new MSSqlServerSinkOptions
                {
                    AutoCreateSqlDatabase = true,
                    AutoCreateSqlTable = true,
                    TableName = "LoginAppV3Logs"
                },
                sinkOptionsSection: null,
                appConfiguration: null,
                restrictedToMinimumLevel: LogEventLevel.Information,
                formatProvider: null,
                columnOptions: null,
                columnOptionsSection: null,
                logEventFormatter: null);
        });
    }
}
