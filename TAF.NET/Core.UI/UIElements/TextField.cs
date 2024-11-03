using OpenQA.Selenium;

namespace TAF.Core.UI.UIElements
{
    public class TextField: BaseUIElement, ITextField
    {
        public TextField(By locator)
            : base(locator) { }

        public string Text => GetText();
    }
}
