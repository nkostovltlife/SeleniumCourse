using Allure.Commons;
using FinalTask.Automation;
using FinalTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace FinalTask
{
    [TestFixture]
    public class BaseTestsPage
    {
        protected AuthenticationPage ap;
        protected CreateAccountPage ca;
        protected MyAccountPage ma;
        protected MyWishlistsPage mw;
        protected ProductPage pp;
        protected CategoryPage cp;
        protected BrowserType browser;
        protected string version;
        protected string os;

        WebdriverFactory webDriverFactory = new WebdriverFactory();

        public BaseTestsPage(BrowserType browser, string version, string os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }

        public IWebDriver Driver { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Driver = webDriverFactory.CreateSauceLabsDriver(browser, version, os);
            //Driver = webDriverFactory.CreateSeleniumGridDriver(browser);
            //Driver = webDriverFactory.CreateLocalDriver(browser);
        }

        [SetUp]
        public void Setup()
        {
            ap = new AuthenticationPage(Driver);
            ca = new CreateAccountPage(Driver);
            ma = new MyAccountPage(Driver);
            mw = new MyWishlistsPage(Driver);
            pp = new ProductPage(Driver);
            cp = new CategoryPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot("TestFailed");
            }
            IWebElement body = Driver.FindElement(By.TagName("body"));
            body.SendKeys(Keys.Control + 't');
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Close();
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        public void TakeScreenshot(string focus)
        {
            try
            {
                ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string screenshotDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\SeleniumCourse\Task-150\FinalTask\Screenshots\"));
                var fileName = TestContext.CurrentContext.Test.Name + "_Screenshot_" + focus + "_" + browser + "_" + os +"_"+ DateTime.Now.ToString("HH-mm-ss") + ".png";
                var fileLocation = Path.Combine(screenshotDirectory, fileName);
                screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment(fileName, "image/png",fileLocation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
