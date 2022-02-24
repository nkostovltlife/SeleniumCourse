using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Task_70
{
    [TestFixture("chrome", "latest", "macOS 11")]
    [TestFixture("firefox", "91.0", "Windows 10")]
    [TestFixture("MicrosoftEdge", "latest", "Windows 10")]
    [AllureNUnit]
    public class Tests : BaseTests
    {
        private const string username = "nikolaykkostov";
        private const string password = "Selenium";

        public Tests(string browser, string version, string os) :base(browser, version, os)
        {
        }

        [Test]
        [AllureSubSuite("Login Tests")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureIssue("1234")]
        [AllureDescription("Verifies the user is able to login with correct credentials")]
        [AllureLink("Yandex Page", "https://yandex.by/")]
        [AllureOwner("Nikolay Kostov")]
        public void VerifyUserLogin_CorrectCredentials()
        {
            mp.NavigateToYandexPage();
            mp.LoginLinkClick();
            lp.EnterText(lp.UsernameInputField, username);
            lp.LoginButtonClicAndWaitPasswordInputField();
            lp.EnterText(lp.PasswordInputField, password);
            lp.LoginButtonClickAndWaitMainPageLoaded();
            mp.TakeScreenshot("UserLoggedIn");


            Assert.AreEqual(username, mp.LoggedUser.Text);
        }

        [Test]
        [AllureSubSuite("Logout Tests")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTag("CI")]
        [AllureIssue("1235")]
        [AllureDescription("Verifies the user is able to logout")]
        [AllureLink("Yandex Page", "https://yandex.by/")]
        [AllureOwner("Nikolay Kostov")]
        public void VerifyUserLogout()
        {
            mp.NavigateToYandexPage();
            mp.LoginLinkClick();
            lp.EnterText(lp.UsernameInputField, username);
            lp.LoginButtonClicAndWaitPasswordInputField();
            lp.EnterText(lp.PasswordInputField, password);
            lp.LoginButtonClickAndWaitMainPageLoaded();
            mp.LoggedUser.Click();
            mp.LogoutButton.Click();
            mp.TakeScreenshot("UserLoggedOut");

            Assert.IsTrue(mp.LoginLink.Displayed);
        }
    }
}
