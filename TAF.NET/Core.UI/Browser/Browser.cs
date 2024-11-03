using OpenQA.Selenium;
using TAF.Core.Configuration;
using Serilog;

namespace TAF.Core.UI.Browser
{
    public class Browser : IBrowser
    {
        private static readonly Lazy<Browser> _instance = new Lazy<Browser>(() => new Browser());

        private Browser() { }

        public static Browser Instance => _instance.Value;

        public IWebDriver WebDriver { get; private set; }

        public void Initialize()
        {
            try
            {
                var testSettings = ConfigurationHelper.GetApplicationConfiguration<TestSettings>();
                if (testSettings == null)
                {
                    throw new InvalidOperationException("Test settings are not configured properly.");
                }
                WebDriver = BrowserFactory.GetDriver(testSettings.BrowserType);
            }
            catch (Exception ex)
            {
                Log.Information("Browser initialization failed:", ex.Message);
                throw;
            }
        }

        public void Cleanup()
        {
            try
            {
                WebDriver?.Quit();
                WebDriver?.Dispose();
            }
            catch (Exception ex)
            {
                Log.Information("Error during WebDriver cleanup:", ex.Message);
            }
            finally
            {
                WebDriver = null;
            }
        }
    }
}