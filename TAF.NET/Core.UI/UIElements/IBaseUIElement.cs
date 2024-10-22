using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF.Core.UI.UIElements
{
    public interface IBaseUIElement
    {
        IWebElement WebElement { get; }
        void Click();
        string GetText();
        bool IsDisplayed();
        bool IsEnabled();
    }
}
