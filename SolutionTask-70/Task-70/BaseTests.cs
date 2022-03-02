using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using Task_70.Pages;

namespace Task_70
{
    [TestFixture]
    public class BaseTests
    {
        IWebDriver driver;
        private string sauceUsername = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
        private string sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
        DriverOptions browserOptions;
        protected string browser;
        protected string version;
        protected string os;


        public MainPageYandex mp;
        public LoginPage lp;

        public BaseTests(string browser, string version, string os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }

        [SetUp]
        public void Setup()
        {
            Environment.CurrentDirectory = @"..\..\..\Courses\SeleniumCourse\SolutionTask-70\Task-70\Screenshots\";
            browserOptions = GetDriverOptions(browser);
            browserOptions.BrowserVersion = version;
            browserOptions.PlatformName = os;

            var sauceUrl = new Uri($"https://{sauceUsername}:{sauceAccessKey}@ondemand.eu-central-1.saucelabs.com:443/wd/hub");
            driver = new RemoteWebDriver(sauceUrl, browserOptions);

            mp = new MainPageYandex(driver);
            lp = new LoginPage(driver);
        }

        

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                mp.TakeScreenshot("TestFailed");
            }
            driver.Quit();
        }

        private DriverOptions GetDriverOptions(string browser)
        {
            switch (browser)
            {
                case "chrome": browserOptions = new ChromeOptions(); break;

                case "firefox": browserOptions = new FirefoxOptions(); break;

                case "MicrosoftEdge": browserOptions = new EdgeOptions(); break;

                default: browserOptions = new ChromeOptions(); break;          
            }
            return browserOptions;
        }
    }
}
