using OpenQA.Selenium;
using TAF.Core.Helpers;
using TAF.Core.UI.UIElements;
using Serilog;

namespace TAF.PageObjects
{
    public class LoginPage
    {
        public IInputField Login => new InputField(By.XPath("//input[@name = 'login']"));
        public IInputField Password => new InputField(By.XPath("//input[@name = 'password']"));
        public IButton LoginButton => new Button(By.XPath("//button[text()='Login']"));
        public ITextField TextErrorLogin => new TextField(By.XPath("//div[contains(@class, 'login-field')]//div[contains(@class, 'error')]//span"));
        public ITextField TextErrorPassword => new TextField(By.XPath("//div[contains(@class, 'password-field')]//div[contains(@class, 'error')]//span"));

        public void SetLogin(string login, string password)
        {
            Login.InputText(login);
            Log.Information("Login is set");
            Password.InputText(password);
            Log.Information("Password is set");
            LoginButton.Click();
            Log.Information("Login Button is clicked");
        }
    }
}