using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task_70.Pages;

namespace Task_70
{
    [TestFixture]
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
        [Description("Verifies the user is able to login with correct credentials")]
        public void VerifyUserLogin_CorrectCredentials()
        {
            mp.NavigateToYandexPage();
            mp.OpenLoginLink.Click();
            lp.EnterText(lp.UsernameInputField, username);
            lp.LoginButtonClicAndWaitPasswordInputField();
            lp.EnterText(lp.PasswordInputField, password);
            lp.LoginButtonClickAndWaitMainPageLoaded();
            mp.TakeScreenshot("UserLoggedIn");

            Assert.AreEqual(username, mp.LoggedUser.Text);
        }

        [Test]
        [Description("Verifies the user is able to logout")]
        public void VerifyUserLogout()
        {
            mp.NavigateToYandexPage();
            mp.OpenLoginLink.Click();
            lp.EnterText(lp.UsernameInputField, username);
            lp.LoginButtonClicAndWaitPasswordInputField();
            lp.EnterText(lp.PasswordInputField, password);
            lp.LoginButtonClickAndWaitMainPageLoaded();
            mp.LoggedUser.Click();
            mp.LogoutButton.Click();
            mp.TakeScreenshot("UserLoggedOut");

            Assert.IsTrue(mp.OpenLoginLink.Displayed);
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
