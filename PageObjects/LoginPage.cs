using OpenQA.Selenium;
using CoreUI.UIElements;
using Serilog;

namespace PageObjects
{
    public class LoginPage
    {
        public IInputField UserName => new InputField(By.Id("login-username"));
        public IInputField Password => new InputField(By.Id("login-password"));
        public IButton LoginButton => new Button(By.Id("login-button"));
        public ITextField TextErrorCreds => new TextField(By.CssSelector("span[class*='Message-sc-']"));
        public ITextField TextErrorUserName => new TextField(By.XPath("//div[@id='username-error']/span"));


        public void SetLogin(string userName, string password)
        {
            UserName.InputText(userName);
            Password.InputText(password);
            LoginButton.Click();
        }
    }
}