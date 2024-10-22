using OpenQA.Selenium;
using TAF.Core.Helpers;
using TAF.Core.UI.UIElements;
using Serilog;
using TAF.Core.Waiters;
using TAF.Core.UI.Browser;

namespace TAF.PageObjects
{
    public class LoginPage : ILoginPage
    {

        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            WebDriverProvider.WebDriver = _driver;
        }
        public IInputField Login => new InputField(By.XPath("//input[@name = 'login']"));
        public IInputField Password => new InputField(By.XPath("//input[@name = 'password']"));
        public IButton LoginButton => new Button(By.XPath("//button[text()='Login']"));
        public ITextField TextErrorLogin => new TextField(By.XPath("//div[contains(@class, 'login-field')]//div[contains(@class, 'error')]"));
        public ITextField TextErrorPassword => new TextField(By.XPath("//div[contains(@class, 'password-field')]//div[contains(@class, 'error')]"));

        public void SetLogin(string login, string password)
        {
            this.Login.InputText(login);
            Log.Information($"Login is set: {login}");
            this.Password.InputText(password);
            Log.Information($"Password is set: {password}");
            this.LoginButton.Click();
            Log.Information($"Login Button is clicked");
        }
    }
}