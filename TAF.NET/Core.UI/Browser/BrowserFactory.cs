using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;

namespace TAF.Core.UI.Browser
{
    public static class BrowserFactory
    {
        public static IWebDriver GetDriver(string browserType)
        {
            return browserType switch
            {
                "Chrome" => new ChromeDriver(GetChromeOptions()),
                "Edge" => new EdgeDriver(GetEdgeOptions()),
                _ => throw new ArgumentException($"Unsupported browser: {browserType}")
            };
        }
        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("headless");
            
            return options;
        }

        private static EdgeOptions GetEdgeOptions()
        {
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("headless");
            
            return options;
        }
    }
}
