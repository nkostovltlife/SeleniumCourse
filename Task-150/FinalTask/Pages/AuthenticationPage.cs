using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class AuthenticationPage : BasePage
    {
        private By mrbuttonBy = By.Id("id_gender1");
        private const string url = "//http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private string signInEmail = "aaa@scx.com";
        private string signInPassword = "Welcome1";

        [FindsBy(How = How.Id, Using = "email_create")]
        public IWebElement CreateAccountEmailInput;

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        public IWebElement CreateAccountButton;

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement SignInEmailInput;

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement SignInPasswordInput;

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement SignInButton;

        public AuthenticationPage(IWebDriver driver) :base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToAuthenticationPage()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void ClickCreateAccountButton()
        {
            CreateAccountButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(mrbuttonBy));
        }
        public void ClickSignInButton()
        {
            SignInButton.Click();
        }

        public void LoginWithTestAccount()
        {
            EnterText(SignInEmailInput, signInEmail);
            EnterText(SignInPasswordInput, signInPassword);
            ClickSignInButton();
        }
    }
}
