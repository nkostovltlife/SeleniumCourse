using OpenQA.Selenium;

namespace LoginYandexMail.Pages
{
    public class LoginPage : BasePage
    {
        private By usernameInputFieldLocator = By.Id("passp-field-login");
        private By passwordInputFieldLocator = By.Id("passp-field-passwd");
        private By loginButtonLocator = By.Id("passp:sign-in");
        private By loggedUserLocator = By.CssSelector("a[href='https://passport.yandex.by'] .user-account__name");

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement usernameInputField => Driver.FindElement(usernameInputFieldLocator);
        public IWebElement passwordInputField => Driver.FindElement(passwordInputFieldLocator);
        public IWebElement loginButton => Driver.FindElement(loginButtonLocator);

        public void LoginButtonClick()
        {
            loginButton.Click();
        }

        public void LoginButtonClickAndWaitMailInboxPageLoaded()
        {
            loginButton.Click();
            //Expecpected conditions class can be used as well
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(loggedUserLocator));
            Wait.Until(condition =>
            {
                try
                {
                    var loggedUser = Driver.FindElement(loggedUserLocator);
                    return loggedUser.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
    }
}
