using OpenQA.Selenium;

namespace YandexLogin.Pages
{
    public class LoginPage : BasePage
    {
        private By usernameInputFieldLocator = By.Id("passp-field-login");
        private By passwordInputFieldLocator = By.Id("passp-field-passwd");
        private By loginButtonLocator = By.Id("passp:sign-in");
        private By loggedUserLocator = By.XPath("//span[@class = 'username desk-notif-card__user-name']");

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement usernameInputField => Driver.FindElement(usernameInputFieldLocator);
        public IWebElement passwordInputField => Driver.FindElement(passwordInputFieldLocator);
        public IWebElement loginButton => Driver.FindElement(loginButtonLocator);

        public void LoginButtonClickAndWaitPasswordField()
        {
            loginButton.Click();
            Wait.Until(drv => drv.FindElement(passwordInputFieldLocator));
        }

        public void LoginButtonClickAndWaitMainPageLoaded()
        {
            loginButton.Click();
            Wait.Until(drv => drv.FindElement(loggedUserLocator));
        }
    }
}
