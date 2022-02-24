using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace LoginYandexMail.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));            
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }     

        public void EnterText(IWebElement element, string textToEnter)
        {
            element.Click();
            element.Clear();
            element.SendKeys(textToEnter);
        }
    }
}
