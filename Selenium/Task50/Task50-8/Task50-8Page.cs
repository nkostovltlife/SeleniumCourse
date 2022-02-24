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

        public Task50_8Page(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }

        public void NavigateToTask50_8Page()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement downloadButton => Driver.FindElement(downloadButtonLocator);

        public void ReloadPage()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(progressBarDeadLineLocator));
            Driver.Navigate().Refresh();
        }
    }
}
