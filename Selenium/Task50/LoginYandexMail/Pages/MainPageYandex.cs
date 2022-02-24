using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginYandexMail.Pages
{
    public class MainPageYandex : BasePage
    {
        private const string yandexURL = "https://yandex.by/";
        private By mailLinkLocator = By.XPath("//div[contains(text(),'Почта')]");

        public MainPageYandex(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement mailLink => Driver.FindElement(mailLinkLocator);

        public void NavigateToYandexPage()
        {
            Driver.Navigate().GoToUrl(yandexURL);
        }
    }
}
