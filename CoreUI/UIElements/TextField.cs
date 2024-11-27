using OpenQA.Selenium;

namespace CoreUI.UIElements
{
    public class TextField: BaseUIElement, ITextField
    {
        public TextField(By locator)
            : base(locator) { }

        public string Text => GetText();
    }
}
