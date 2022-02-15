using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task_70.Pages
{
    public class LoginPage : BasePage
    {
        private By passwordInputFieldLocator = By.Id("passp-field-passwd");
        private By loggedUserLocator = By.XPath("//span[@class = 'username desk-notif-card__user-name']");

        [FindsBy(How = How.Id, Using = "passp-field-login")]
        public IWebElement UsernameInputField;

        [FindsBy(How = How.Id, Using = "passp-field-passwd")]
        public IWebElement PasswordInputField;

        [FindsBy(How = How.Id, Using = "passp:sign-in")]
        public IWebElement LoginButton;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click LoginButton and wait Password Input Field")]
        public void LoginButtonClicAndWaitPasswordInputField()
        {
            LoginButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(passwordInputFieldLocator));
        }

        [AllureStep("Click LoginButton and wait Main Page")]
        public void LoginButtonClickAndWaitMainPageLoaded()
        {
            LoginButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(loggedUserLocator));
        }


    }
}
