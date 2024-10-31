using OpenQA.Selenium;

namespace TAF.Core.UI.UIElements
{
    public class InputField : BaseUIElement, IInputField
    {
        public InputField(By locator)
            : base(locator) { }
        public string Text => GetText();
    }
}
