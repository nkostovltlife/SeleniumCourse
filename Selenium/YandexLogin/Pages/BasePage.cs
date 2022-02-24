using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace YandexLogin.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Window.Maximize();
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
