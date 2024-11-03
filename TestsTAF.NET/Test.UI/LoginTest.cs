using FluentAssertions;
using Serilog;
using TAF.PageObjects;

namespace TestsTAF.NET.Test.UI
{
    public class LoginTests : BaseUITest
    {
        [Test]
        [TestCase("test", "test", "Bad Credentials")]
        public void LoginWithBadCredsTest(string login, string password, string expectedResult)
        {
            Log.Information("Starting Login With Bad Creds.");
            Pages.LoginPage.SetLogin(login, password);
            Pages.LoginPage.TextErrorLogin.IsDisplayed().Should().BeTrue("Login error message is not displayed");
            Pages.LoginPage.TextErrorPassword.IsDisplayed().Should().BeTrue("Password error message is not displayed");
            Pages.LoginPage.TextErrorLogin.Text.Should().Be(expectedResult, "Actual login error message does not match expected result");
            Pages.LoginPage.TextErrorPassword.Text.Should().Be(expectedResult, "Actual password error message does not match expected result.");
            Log.Information($"The LoginWithBadCredsTest is comleted succesfully");
        }
    }
}