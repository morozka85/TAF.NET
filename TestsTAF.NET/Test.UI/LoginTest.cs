using Serilog;
using TAF.Core.Waiters;
using TAF.PageObjects;
using NUnit.Framework;

namespace TestsTAF.NET.Test.UI
{
    public class LoginTests : BaseUITest
    {
        [Test]
        [TestCase("test", "test")]
        public void LoginWithBadCredsTest(string login, string password)
        {
            Log.Information("Starting Login With Bad Creds.");
            var loginPage = new LoginPage(Browser.WebDriver);
            loginPage.SetLogin(login, password);
            Waiters.WaitForElementIsDisplayed(loginPage.TextErrorLogin.WebElement, Wait);
            Waiters.WaitForElementIsDisplayed(loginPage.TextErrorPassword.WebElement, Wait);
            Assert.That(loginPage.TextErrorLogin.IsDisplayed, $"Expected error is not got");
            Assert.That(loginPage.TextErrorPassword.IsDisplayed, $"Expected error is not got");
            Log.Information($"The LoginWithBadCredsTest is comleted succesfully");
        }
    }
}