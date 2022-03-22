using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace FinalTask.Automation
{
    public class WebdriverFactory
    {
        DriverOptions browserOptions;

        private DriverOptions GetDriverOptions(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome: browserOptions = new ChromeOptions(); break;

                case BrowserType.Firefox: browserOptions = new FirefoxOptions(); break;

                default: browserOptions = new ChromeOptions(); break;
            }
            return browserOptions;
        }

        public IWebDriver CreateSauceLabsDriver(BrowserType browser, string version, string os)
        {
            string sauceUsername = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            string sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

        GetDriverOptions(browser);
            browserOptions.BrowserVersion = version;
            browserOptions.PlatformName = os;
            var sauceUrl = new Uri($"https://{sauceUsername}:{sauceAccessKey}@ondemand.eu-central-1.saucelabs.com:443/wd/hub");

            return new RemoteWebDriver(sauceUrl, browserOptions);
        }

        public IWebDriver CreateSeleniumGridDriver(BrowserType browser)
        {
            string url = "http://localhost:4444/wd/hub";
            var browserOptions = GetDriverOptions(browser);

            return new RemoteWebDriver(new Uri(url), browserOptions);
        }

        public IWebDriver CreateLocalDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome : return new ChromeDriver();

                case BrowserType.Firefox : return new FirefoxDriver();

                default: throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }

    }
}
