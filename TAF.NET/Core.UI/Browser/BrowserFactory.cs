using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;

namespace TAF.Core.UI.Browser
{
    public static class BrowserFactory
    {
        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
           // options.AddArgument("headless");
            
            return options;
        }

        private static EdgeOptions GetEdgeOptions()
        {
            var options = new EdgeOptions();
            return options;
        }

        public static IWebDriver GetDriver(string browserType)
        {
            return browserType switch
            {
                "Chrome" => new ChromeDriver(),
                "Edge" => new EdgeDriver(),
                _ => throw new ArgumentException($"Unsupported browser: {browserType}")
            };
        }
    }
}
