using Core.Configuration;
using Serilog;
using CoreUI.Helpers;
using CoreUI.Browser;
using Core;
using OpenQA.Selenium.Support.UI;

namespace TestsUI
{
    [TestFixture]
    public abstract class BaseUITest : BaseTest
    {
        protected static Browser Browser => Browser.Instance;
        protected static TestSettings TestSettings = ConfigurationHelper.GetApplicationConfiguration<TestSettings>();
        protected static WebDriverWait Wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(15));
        [OneTimeSetUp]
        public void UiInitialize()
        {
            Log.Information("Initializing browser ...");
            Browser.Initialize();
        }

        [SetUp]
        public void BrowserInitialized()
        {
            Browser.WebDriver.Navigate().GoToUrl(TestSettings.BaseUrl);
            Log.Information("Browser initialized and navigated to Base URL: " + TestSettings.BaseUrl);
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
            {
                ScreenshotHelper.SaveScreenshot(Browser.WebDriver);
            }
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
        public void UITeardown()
        {
            try
            {
                Browser.Cleanup();
            }
            finally
            {
                Log.Information("Browser is quited.");
            }
        }
    }
}
