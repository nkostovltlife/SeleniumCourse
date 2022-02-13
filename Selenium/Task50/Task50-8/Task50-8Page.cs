using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task50_8
{
    public class Task50_8Page
    {
        private By downloadButtonLocator = By.Id("cricle-btn");
        private By progressBarDeadLineLocator = By.XPath("//div[text() = '50%']");

        private const string url = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";

        IWebDriver driver;
        private WebDriverWait wait;

        public Task50_8Page(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(15));
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return this.wait;
            }
        }

        public void NavigateToTask50_8Page()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement downloadButton => Driver.FindElement(downloadButtonLocator);

        public void ReloadPage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(progressBarDeadLineLocator));
            Driver.Navigate().Refresh();
        }
    }
}
