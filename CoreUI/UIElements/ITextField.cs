using OpenQA.Selenium;

namespace CoreUI.UIElements
{
    public interface ITextField
    {
        string Text { get; }
        bool IsDisplayed();
        By Locator { get; }
    }

}
