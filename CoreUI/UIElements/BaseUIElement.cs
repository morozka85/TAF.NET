using OpenQA.Selenium;
using Serilog;
using Core.Helpers;
using System.Collections.ObjectModel;

namespace CoreUI.UIElements
{
    public abstract class BaseUIElement : IBaseUIElement
    {
        protected IWebDriver WebDriver = Browser.Browser.Instance.WebDriver;
        public By Locator { get; private set; }

        public BaseUIElement(By locator)
        {
            Locator = locator;
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

        public ReadOnlyCollection<IWebElement> WebElements
        {
            get
            {
                var elements = GetElements();
                if (elements == null || elements.Count == 0)
                {
                    return null;
                }
                return elements;
            }
        }

        public void Click()
        {
            Log.Logger.Information($"Click on the Element with locator {Locator}");
            WebElement.Click();
        }

        public void InputText(string text)
        {
            Log.Logger.Information($"Input text into the Element with locator {Locator}");
            WebElement.Clear();
            WebElement.SendKeys(text);
        }

        public string GetText()
        {
            Log.Logger.Information($"Get text from Element with locator {Locator}");
            return WebElement.Text;
        }

        public bool IsDisplayed()
        {
            Log.Logger.Information($"Check if the Element is displayed with locator {Locator}");
            return WebElement.Displayed;
        }

        public string GetAttributeValue(string attribute)
        {
            string attributeValue = WebElement.GetAttribute(attribute);
            Log.Logger.Information($"Retrieved '{attribute}' from Element with locator {Locator}: {attributeValue}");
            return attributeValue;
        }

        public bool IsEnabled()
        {
            Log.Logger.Information($"Check if the Element is enabled with locator {Locator}");
            return WebElement.Enabled;
        }

        private IWebElement GetElement()
        {
            IWebElement element = null;
            try
            {
                Waiter.WaitFor(() =>
                {
                    element = WebDriver.FindElement(Locator);
                    return element.Enabled;
                });
                return element;
            }
            catch (TimeoutException)
            {
                Log.Logger.Warning($"Element not found within the timeout period for locator {Locator}");
                return null;
            }
        }

        private ReadOnlyCollection<IWebElement> GetElements()
        {
            try
            {
                return WebDriver.FindElements(Locator);
            }
            catch (NoSuchElementException)
            {
                Log.Logger.Warning($"No elements found for locator {Locator}");
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }
        }
    }
}
