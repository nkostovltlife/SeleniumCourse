using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Task50_7
{
    [TestFixture]
    public class TestTask50_7
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        [Description("Verifies user's image is loaded after GetNewUser button is clicked")]
        public void VerifyNewUserImageLoaded()
        {
            Task50_7Page tp = new Task50_7Page(driver);

            tp.NavigateToTask50_7Page();
            tp.getNewUserButton.Click();

            Assert.IsTrue(tp.IsUserImageDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
