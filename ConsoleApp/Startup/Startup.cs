using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using ConsoleApp.Common.ServiceInstallers.Extentions;
using ConsoleApp.Startup.Services.Extentions;
using System;
using System.Reflection;

namespace ConsoleApp.Startup
{
    public class Startup
    {
        internal static IServiceProvider ServiceProvider;
        private static IServiceCollection _serviceCollection = new ServiceCollection();

        static Startup()
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appconfig.json", optional: true, reloadOnChange: true)
                    .Build();

            AddLogger(config);
            RegisterService(config);
        }

        public static void RegisterService(IConfigurationRoot config)
        {
            _serviceCollection.RegisterApplicationServices(Assembly.GetExecutingAssembly());
            _serviceCollection.RegisterServices(config);
            _serviceCollection.AddServices(config);

            ServiceProvider = _serviceCollection.BuildServiceProvider();
        }

        private static void AddLogger(IConfigurationRoot config)
        {
            var logLevel = (Microsoft.Extensions.Logging.LogLevel)Enum.Parse(typeof(Microsoft.Extensions.Logging.LogLevel), config.GetSection("Logging:LogLevel:Default").Value);
            var nLogConfig = config.GetSection("NLog");

            _serviceCollection.AddLogging(logBuilder =>
            {
                logBuilder.ClearProviders();
                logBuilder.SetMinimumLevel(logLevel);

                LogManager.Configuration = new NLogLoggingConfiguration(nLogConfig);
                logBuilder.AddNLog(nLogConfig);
            });
        }
    }
}
