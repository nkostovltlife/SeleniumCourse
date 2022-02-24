using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task50_7
{
    public class Task50_7Page
    {
        private By getNewUserButtonLocator = By.Id("save");
        private By userImageLocator = By.CssSelector("#loading img");

        private const string url = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";

        public Task50_7Page(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }

        public void NavigateToTask50_7Page()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement getNewUserButton => Driver.FindElement(getNewUserButtonLocator);

        public bool IsUserImageDisplayed()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(userImageLocator));
            return Driver.FindElement(userImageLocator).Displayed;
        }
    }
}
