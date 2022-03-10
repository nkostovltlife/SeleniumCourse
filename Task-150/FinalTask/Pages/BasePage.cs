using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace FinalTask.Pages
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

        private static Random random = new Random();

        public string GenerateRandomEmail(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()) + "@aaa.com";
        }
    }
}
