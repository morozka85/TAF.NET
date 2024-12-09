using OpenQA.Selenium;

namespace CoreUI.UIElements
{
    public interface IBaseUIElement
    {
        IWebElement WebElement { get; }
        void Click();
        string GetText();
        bool IsDisplayed();
        bool IsEnabled();
        string GetAttributeValue(string attribute);
    }
}
