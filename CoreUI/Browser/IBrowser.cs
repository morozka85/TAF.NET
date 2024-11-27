using OpenQA.Selenium;

namespace CoreUI.Browser
{
    public interface IBrowser
    {
        void Initialize();
        void Cleanup();
        IWebDriver WebDriver { get; }
    }

}
