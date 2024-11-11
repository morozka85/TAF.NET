using Serilog;
using CoreAPI;
using TAF.Core.Configuration;
using BusinessAPI.Services;

namespace TestsTAF.NET.Test.API
{
    public abstract class BaseApiTest
    {
        protected ApiClient ApiClient;
        protected DashboardService DashboardService;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/apiTest.log", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            var testSettings = ConfigurationHelper.GetApplicationConfiguration<TestSettings>();
            DashboardService = new DashboardService(testSettings.BaseUrlApi + "yuliya_morozova_personal", testSettings.Token);
            Log.Information("API Client initialized with Base URL: " + testSettings.BaseUrlApi);
        }

        [SetUp]
        public void Setup()
        {

            Log.Information("Setting up for API test.");
        }

        [TearDown]
        public void Teardown()
        {
            Log.Information("Tearing down after API test.");
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            Log.Information("Cleaning up after all API tests.");
            Log.CloseAndFlush();
        }
    }
}

