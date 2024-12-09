using OpenQA.Selenium;

namespace CoreUI.UIElements
{
    public class InputField : BaseUIElement, IInputField
    {
        public InputField(By locator)
            : base(locator) { }
        public string Text => GetText();
    }
}
