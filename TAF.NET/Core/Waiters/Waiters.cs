using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TAF.Core.UI.UIElements;

namespace TAF.Core.Waiters
{
    public static class Waiters
    {
        //public static void WaitForElementIsVisible(IWebDriver driver, By by, int timeoutInSeconds)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    wait.Until(ExpectedConditions.ElementIsVisible(by));
        //}
        //public static void WaitForElementToBeEnabled(IWebDriver driver, By by, int timeoutInSeconds)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    wait.Until(ExpectedConditions.ElementToBeClickable(by));
        //}

        //public static void WaitForElementIsDisplayed(IWebElement element, int timeoutInSeconds = 10)
        //{
        //    IWebDriver driver = ((IWrapsDriver)element).WrappedDriver;
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    wait.Until(driver => element.Displayed);
        //}

        public static void WaitForElementIsDisplayed(IWebElement element, WebDriverWait wait)
        {
            wait.Until(driver => element.Displayed);
        }
    }
}
