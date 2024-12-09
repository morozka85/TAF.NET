using OpenQA.Selenium;
using System;

namespace CoreUI.UIElements
{
    public class Button : BaseUIElement, IButton
    {
        public Button(By locator) : base(locator) { }

    }
}
