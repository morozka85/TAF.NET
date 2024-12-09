using Serilog;
using CoreAPI;
using ServicesAPI;
using Core;
using Microsoft.Extensions.Configuration;
using Core.Configuration;

namespace TestsAPI
{
    public abstract class BaseApiTest : BaseTest
    {
        protected ApiClient ApiClient;
        protected UserService UserService;
        protected PlayListService PlayListService;

        [OneTimeSetUp]
        public void SetupAPI()
        {
            var testSettings = ConfigurationHelper.GetApplicationConfiguration<TestSettings>();
            Log.Information("API Client initialized with Base URL: " + testSettings.BaseUrlApi);
            UserService = new UserService(testSettings.BaseUrlApi, testSettings.Token);
            PlayListService = new PlayListService(testSettings.BaseUrlApi, testSettings.Token);

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

