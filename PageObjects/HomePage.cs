using CoreUI.UIElements;
using OpenQA.Selenium;

namespace PageObjects
{
    public class HomePage
    {
        public IButton LoginButton => new Button(By.CssSelector("button[data-testid = 'login-button']"));
        public IButton UserWidgetButton => new Button(By.CssSelector("button[data-testid = 'user-widget-link']"));
    }
}
