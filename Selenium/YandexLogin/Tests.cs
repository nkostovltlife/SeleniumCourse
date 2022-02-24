using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YandexLogin.Pages;

namespace YandexLogin
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
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
            mp.openLoginLink.Click();
            lp.EnterText(lp.usernameInputField, username);
            lp.LoginButtonClickAndWaitPasswordField();
            lp.EnterText(lp.passwordInputField, password);
            lp.LoginButtonClickAndWaitMainPageLoaded();

            Assert.AreEqual(username, mp.loggedUser.Text,"The user is not logged in.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
