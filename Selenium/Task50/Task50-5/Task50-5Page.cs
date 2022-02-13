using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task50_5
{
    public class Task50_5Page
    {
        private By selectLocator = By.Id("multi-select");
        private By option1Locator = By.CssSelector("select[name='States'] option[value = 'California']");
        private By option4Locator = By.CssSelector("select[name='States'] option[value = 'New York']");
        private By option5Locator = By.CssSelector("select[name='States'] option[value = 'Ohio']");

        private const string url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";

        IWebDriver driver;

        public Task50_5Page(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public void NavigateToTask50_5Page()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public SelectElement Select => new SelectElement(Driver.FindElement(selectLocator));
        public IWebElement option1 => Driver.FindElement(option1Locator);
        public IWebElement option4 => Driver.FindElement(option4Locator);
        public IWebElement option5 => Driver.FindElement(option5Locator);

        public void Select3Options(string optionOne, string optionTwo, string optionThree)
        {
            Select.SelectByText(optionOne);
            Select.SelectByText(optionTwo);
            Select.SelectByText(optionThree);
        }
    }
}
