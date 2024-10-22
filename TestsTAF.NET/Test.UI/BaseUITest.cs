using OpenQA.Selenium.Support.UI;
using Serilog;
using TAF.Core.Configuration;
using TAF.Core.UI.Browser;

namespace TestsTAF.NET.Test.UI
{
    public abstract class BaseUITest
    {

        protected static Browser Browser => Browser.Instance;
        protected WebDriverWait Wait;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/test.log", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information("Initializing browser...");
            Browser.Initialize();
            Wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(10));
        }

        [SetUp]
        public void Setup()
        {
            var testSettings = ConfigurationHelper.GetApplicationConfiguration<TestSettings>();
            Browser.WebDriver.Navigate().GoToUrl(testSettings.BaseUrl);
            Log.Information("Browser initialized and navigated to Base URL: " + testSettings.BaseUrl);
   
        }

        [TearDown]
        public void Teardown()
        {
            try
            {
                Browser.WebDriver.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error cleaning up after test.");
            }
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            try
            {
                Browser.Cleanup();
            }
            finally
            {
                Log.Information("Browser is quited.");
                Log.CloseAndFlush();
            }
        }
    }
}
