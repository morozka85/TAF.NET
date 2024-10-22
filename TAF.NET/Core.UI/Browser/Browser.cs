using OpenQA.Selenium;
using TAF.Core.Configuration;
using TAF.Core.UI.Browser;
using Serilog;

namespace TAF.Core.UI.Browser
{
    public class Browser : IBrowser
    {
        private static readonly Lazy<Browser> instance = new Lazy<Browser>(() => new Browser());
        private IWebDriver webDriver;

        private Browser() { }

        public static Browser Instance => instance.Value;

        public IWebDriver WebDriver => this.webDriver;

        public void Initialize()
        {
            try
            {
                var testSettings = ConfigurationHelper.GetApplicationConfiguration<TestSettings>();
                if (testSettings == null)
                {
                    throw new InvalidOperationException("Test settings are not configured properly.");
                }
                this.webDriver = BrowserFactory.GetDriver(testSettings.BrowserType);
                this.webDriver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                Log.Information($"Browser initialization failed: {ex.Message}");
                throw;
            }
        }

        public void Cleanup()
        {
            try
            {
                this.webDriver?.Quit();
                this.webDriver?.Dispose();
            }
            catch (Exception ex)
            {
                Log.Information($"Error during WebDriver cleanup: {ex.Message}");
            }
            finally
            {
                this.webDriver = null;
            }
        }
    }
}