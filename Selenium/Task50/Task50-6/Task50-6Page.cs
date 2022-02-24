using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.UI;
using System;

namespace Task50_6
{
    public class Task50_6Page
    {
        private By JSAlertBoxButtonLocator = By.XPath("//div[@class='panel panel-primary'][1]//button");
        private By JSConfirmBoxButtonLocator = By.XPath("//div[@class='panel panel-primary'][2]//button");
        private By JSPromptBoxButtonLocator = By.XPath("//div[@class='panel panel-primary'][3]//button");
        private By JSPromptBoxMessageLocator = By.Id("prompt-demo");

        private const string url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

        public Task50_6Page(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver { get; }

        public void NavigateToTask50_6Page()
        {
            Driver.Navigate().GoToUrl(url);
        }
        
        public IWebElement jSAlertBoxButton => Driver.FindElement(JSAlertBoxButtonLocator);
        public IWebElement jSConfirmBoxButton => Driver.FindElement(JSConfirmBoxButtonLocator);
        public IWebElement jSPromptBoxButton => Driver.FindElement(JSPromptBoxButtonLocator);
        public IWebElement jSPromptBoxMessage => Driver.FindElement(JSPromptBoxMessageLocator);

        public bool IsAlertClosed(IWebDriver driver)
        {
            IAlert alert = SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent().Invoke(driver);
            return (alert == null);
        }
    }
}
