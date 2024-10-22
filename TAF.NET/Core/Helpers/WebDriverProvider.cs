using OpenQA.Selenium;

namespace TAF.Core.Helpers
{
    public static class WebDriverProvider
    {
        private static IWebDriver _webDriver;

        public static IWebDriver WebDriver
        {
            get => _webDriver;
            set => _webDriver = value;
        }
    }
}
