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

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        [Description("Verifies the user is able to login with correct credentials")]
        public void VerifyUserLogin_CorrectCredentials()
        {
            MainPageYandex mp = new MainPageYandex(driver);
            LoginPage lp = new LoginPage(driver);

            mp.NavigateToYandexPage();
            mp.TakeScreenshot();
            mp.OpenLoginLink.Click();
            lp.EnterText(lp.UsernameInputField, username);
            lp.LoginButtonClicAndWaitPasswordInputField();
            lp.EnterText(lp.PasswordInputField, password);
            lp.LoginButtonClickAndWaitMainPageLoaded();

            Assert.AreEqual(username, mp.LoggedUser.Text);
        }

        [Test]
        [Description("Verifies the user is able to logout")]
        public void VerifyUserLogout()
        {
            MainPageYandex mp = new MainPageYandex(driver);
            LoginPage lp = new LoginPage(driver);

            mp.NavigateToYandexPage();
            mp.OpenLoginLink.Click();
            lp.EnterText(lp.UsernameInputField, username);
            lp.LoginButtonClicAndWaitPasswordInputField();
            lp.EnterText(lp.PasswordInputField, password);
            lp.LoginButtonClickAndWaitMainPageLoaded();
            mp.LoggedUser.Click();
            mp.LogoutButton.Click();

            Assert.IsTrue(mp.OpenLoginLink.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
