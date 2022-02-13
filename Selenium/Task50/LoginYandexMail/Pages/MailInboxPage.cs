using OpenQA.Selenium;

namespace LoginYandexMail.Pages
{
    public class MailInboxPage : BasePage
    {
        private By loggedUserLocator = By.CssSelector("a[href='https://passport.yandex.by'] .user-account__name");

        public MailInboxPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement LoggedUser => Driver.FindElement(loggedUserLocator);
    }
}
