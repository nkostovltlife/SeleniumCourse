using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task_70.Pages;

namespace Task_70
{
    [TestFixture]
    [AllureNUnit]
    public class Tests
    {
        IWebDriver driver;
        private const string username = "nikolaykkostov";
        private const string password = "Selenium";

        MainPageYandex mp;
        LoginPage lp;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            mp = new MainPageYandex(driver);
            lp = new LoginPage(driver);
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

        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                mp.TakeScreenshot("TestFailed");              
            }
            driver.Quit();
        }
    }
}
