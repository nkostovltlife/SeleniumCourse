using LoginYandexMail.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace LoginYandexMail
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        [TestCase("nikolaykkostov", "Selenium")]
        [TestCase("ivonakkostova", "Selenium1")]
        [Description("Verifies the user is able to login with correct credentials")]
        public void VerifyYandexMailLogin_CorrectCredentials(string username, string password)
        {
            MainPageYandex mp = new MainPageYandex(driver);
            LoginPage lp = new LoginPage(driver);
            MailInboxPage mip = new MailInboxPage(driver);

            mp.NavigateToYandexPage();
            mp.mailLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);   
            lp.EnterText(lp.usernameInputField, username);
            lp.LoginButtonClick();
            lp.EnterText(lp.passwordInputField, password);
            lp.LoginButtonClickAndWaitMailInboxPageLoaded();

            Assert.AreEqual(username, mip.LoggedUser.Text);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
