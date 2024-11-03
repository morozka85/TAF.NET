using Serilog;
using OpenQA.Selenium;

namespace TAF.Core.Helpers
{
    public static class ScreenshotHelper
    {
        public static void SaveScreenshot(IWebDriver driver)
        {
            if (driver is ITakesScreenshot takesScreenshot)
            {
                var screenshotsDirectory = Path.Combine(Environment.CurrentDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotsDirectory);

                string fileName = $"Screenshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}.png";
                string screenshotPath = Path.Combine(screenshotsDirectory, fileName);

                var screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile(screenshotPath);
                Log.Information($"Screenshot {fileName} saved to: {screenshotPath}");
            }
            else
            {
                Log.Warning("Current driver does not support taking screenshots.");
            }
        }
    }
}
