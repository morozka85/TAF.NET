using PageObjects;
using Serilog;

namespace TestsUI
{
    public class BaseUITestWithLogin : BaseUITest
    {
        [SetUp]
        public void LoginSetUp()
        {
            Pages.HomePage.LoginButton.Click();
            Pages.LoginPage.SetLogin(TestSettings.UserName, TestSettings.Password);
            Pages.HomePage.UserWidgetButton.IsDisplayed();
            Log.Information("Login succesfull");
        }
    }
}
