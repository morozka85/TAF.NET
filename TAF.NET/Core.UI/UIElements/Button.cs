using OpenQA.Selenium;

namespace TAF.Core.UI.UIElements
{
    public class Button : BaseUIElement, IButton
    {
        public Button(By locator) : base(locator) { }
    }
}
