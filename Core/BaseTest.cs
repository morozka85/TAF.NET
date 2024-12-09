using Core.Configuration;
using Microsoft.Extensions.Configuration;
using Serilog;
using NUnit.Framework;
using Serilog.Configuration;

namespace Core
{
    [TestFixture]
    public abstract class BaseTest
    {
        public IConfiguration Configuration { get; set; }

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Configuration = ConfigurationHelper.GetConfiguration();

            Log.Logger = new LoggerConfiguration()
            //.ReadFrom.Configuration(Configuration.GetSection("Serilog"))
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/test.log", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Logger.Information("Logger is configured and initiated.");
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            Log.Information("Tests have completed. Flushing and closing logger.");
            Log.CloseAndFlush();
        }
    }
}
