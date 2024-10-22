using OpenQA.Selenium;

namespace TAF.Core.UI.Browser
{
    public interface IBrowser
    {
        void Initialize();
        void Cleanup();
        IWebDriver WebDriver { get; }
    }

}
