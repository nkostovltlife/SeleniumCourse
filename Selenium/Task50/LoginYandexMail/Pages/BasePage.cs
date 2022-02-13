using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace LoginYandexMail.Pages
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
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

        public void EnterText(IWebElement element, string textToEnter)
        {
            element.Click();
            element.Clear();
            element.SendKeys(textToEnter);
        }
    }
}
