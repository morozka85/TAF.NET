using OpenQA.Selenium;
using Serilog;
using TAF.Core.Helpers;

namespace TAF.Core.UI.UIElements
{
    public abstract class BaseUIElement : IBaseUIElement
    {
        protected IWebDriver WebDriver => Helpers.WebDriverProvider.WebDriver;
        protected By Locator { get; private set; }
        private IWebElement _webElement;

        protected BaseUIElement(By locator)
        {
            Locator = locator;
        }

        private IWebElement GetElement()
        {
            IWebElement element = null;
            try
            {
                Waiter.WaitFor(() =>
                {
                    try
                    {
                        element = WebDriver.FindElement(Locator);
                        return element != null;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
                return element;
            }
            catch (TimeoutException)
            {
                Log.Logger.Warning($"Element not found within the timeout period for locator: {Locator}");
                return null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "An unexpected error occurred while trying to find an element");
                throw;
            }
        }

        public IWebElement WebElement
        {
            get
            {
                var element = GetElement();
                if (element == null)
                {
                    throw new InvalidOperationException($"WebElement with locator {Locator} could not be found.");
                }
                return element;
            }
        }

        public virtual void Click()
        {
            try
            {
                if (IsDisplayed())
                {
                    WebElement.Click();
                }
                else
                {
                    Log.Logger.Warning($"Element {WebElement} is not displayed");
                }
            }
            catch (WebDriverException exception)
            {
                Log.Logger.Warning($"WebDriverException: {exception.StackTrace}");
            }
        }

        public virtual void InputText(string text)
        {
            try
            {
                WebElement.Clear();
                WebElement.SendKeys(text);
            }
            catch (WebDriverException exception)
            {
                Log.Logger.Warning($"WebDriverException: {exception.StackTrace}");
            }
        }

        public string GetText()
        {
            return WebElement.Text;
        }

        public bool IsDisplayed()
        {
            return WebElement.Displayed;
        }

        public bool IsEnabled()
        {
            return WebElement.Enabled;
        }
    }
}
