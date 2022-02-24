using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task50_5
{
    public class Task50_5Page
    {
        private By selectLocator = By.Id("multi-select");
        private const string url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";

        public Task50_5Page(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver { get; }

        public void NavigateToTask50_5Page()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public SelectElement Select => new SelectElement(Driver.FindElement(selectLocator));

        public void Select3Options(string optionOne, string optionTwo, string optionThree)
        {
            Select.SelectByValue(optionOne);
            Select.SelectByValue(optionTwo);
            Select.SelectByValue(optionThree);
        }
    }
}
