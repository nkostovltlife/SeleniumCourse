using OpenQA.Selenium;

namespace YandexLogin.Pages
{
    public class MainPageYandex : BasePage
    {
        private const string yandexURL = "https://yandex.by/";
        private By openLoginLinkLocator = By.ClassName("desk-notif-card__login-new-item-title");
        private By loggedUserLocator = By.XPath("//span[@class = 'username desk-notif-card__user-name']");

        public MainPageYandex(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement openLoginLink => Driver.FindElement(openLoginLinkLocator);
        public IWebElement loggedUser => Driver.FindElement(loggedUserLocator);

        public void NavigateToYandexPage()
        {
            Driver.Navigate().GoToUrl(yandexURL);
        }
    }
}
