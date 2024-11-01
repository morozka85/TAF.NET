using Serilog;
using TAF.Core.Waiters;
using TAF.PageObjects;
using NUnit.Framework;

namespace TestsTAF.NET.Test.UI
{
    public class LoginTests : BaseUITest
    {
        [Test]
        [TestCase("test", "test", "Bad Credentials")]
        public void LoginWithBadCredsTest(string login, string password, string expectedResult)
        {
            Log.Information("Starting Login With Bad Creds.");
            var loginPage = new LoginPage();
            loginPage.SetLogin(login, password);
            Assert.That(loginPage.TextErrorLogin.IsDisplayed(), $"Expected error is not got");
            Assert.That(loginPage.TextErrorPassword.IsDisplayed(), $"Expected error is not got");
            Assert.That(loginPage.TextErrorLogin.GetText(), Is.EqualTo(expectedResult));
            Log.Information($"The LoginWithBadCredsTest is comleted succesfully");
        }
    }
}