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

        IWebDriver driver;
        private WebDriverWait wait;

        public Task50_7Page(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
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

        public void NavigateToTask50_7Page()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement getNewUserButton => Driver.FindElement(getNewUserButtonLocator);

        public bool IsUserImageDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(userImageLocator));
            return Driver.FindElement(userImageLocator).Displayed;
        }
    }
}
