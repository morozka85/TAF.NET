using FluentAssertions;
using PageObjects;

namespace TestsUI
{
    public class LoginTests : BaseUITest
    {
        [Test]
        
        public void LoginTest()
        {
            Pages.HomePage.LoginButton.Click();
            Pages.LoginPage.SetLogin(TestSettings.UserName, TestSettings.Password);
            Pages.HomePage.UserWidgetButton.IsDisplayed().Should().BeTrue();
        }

        [TestCase("test", "test")]
        [TestCase("", "")]
        public void LoginWithBadCredsTest(string userName, string password, string expectedResult= "Incorrect username or password.")
        {
            Pages.HomePage.LoginButton.Click();
            Pages.LoginPage.SetLogin(userName, password);
            Pages.LoginPage.TextErrorCreds.IsDisplayed().Should().BeTrue();
            Pages.LoginPage.TextErrorCreds.Text.Should().Be(expectedResult);
        }

        [TestCase("`test")]
        public void ForbidenCharsForUserNameTest(string userName, string expectedResult = "Forbidden character(s)")
        {
            Pages.HomePage.LoginButton.Click();
            Pages.LoginPage.UserName.InputText(userName);
            Pages.LoginPage.TextErrorUserName.IsDisplayed().Should().BeTrue();
            Pages.LoginPage.TextErrorUserName.Text.Should().Contain(expectedResult);
        }
    }
}