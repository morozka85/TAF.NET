using OpenQA.Selenium;

namespace CoreUI.Helpers
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
