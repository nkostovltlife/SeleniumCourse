using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task_70.Pages
{
    public class MainPageYandex : BasePage
    {
        private const string yandexURL = "https://yandex.ru/";

        [FindsBy(How = How.ClassName, Using = "desk-notif-card__login-new-item-title")]
        public IWebElement LoginLink;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'username desk-notif-card__user-name']")]
        public IWebElement LoggedUser;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Выйти')]")]
        public IWebElement LogoutButton;


        public MainPageYandex(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Navigate to home page")]
        public void NavigateToYandexPage()
        {
            Driver.Navigate().GoToUrl(yandexURL);
        }

        [AllureStep("Click Login link")]
        public void LoginLinkClick()
        { 
            LoginLink.Click();
        }
    }
}