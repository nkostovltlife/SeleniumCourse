using Allure.Commons;
using FinalTask.Automation;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace FinalTask
{
    [TestFixture(BrowserType.Chrome, "latest", "Windows 10")]
    [TestFixture(BrowserType.Firefox, "latest", "Windows 10")]
    [AllureNUnit]
    public class LoginTests : BaseTestsPage
    {
        private const string expectedMyAccountPageTitle = "My account - My Store";
        private const string accountNotCreatedErrorMessage = "The account is not created";
        private const string pageTitleNotExpectedErrorMessage = "The Page title is different then expected";

        public LoginTests(BrowserType browser, string version, string os) : base(browser, version, os)
        {

        }

        [Test]
        [AllureSubSuite("Authentication")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureIssue("0001")]
        [AllureDescription("Verifies the account creation")]
        [AllureOwner("Nikolay Kostov")]
        public void VerifyAccountCreated()
        {
            authenticationPage.NavigateToAuthenticationPage();
            authenticationPage.EnterText(authenticationPage.CreateAccountEmailInput, authenticationPage.GenerateRandomEmail(8));
            authenticationPage.ClickCreateAccountButton();
            createAccountPage.FillRegistrationForm();
            createAccountPage.ClickRegisterButton();

            Assert.AreEqual(expectedMyAccountPageTitle, Driver.Title, accountNotCreatedErrorMessage);
            myWishlistsPage.ClickSignOutButton();
        }

        [Test]
        [AllureSubSuite("Authentication")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureIssue("0002")]
        [AllureDescription("Verifies the login is successfull")]
        [AllureOwner("Nikolay Kostov")]
        public void VerifyAccountLoginSuccessful()
        {
            authenticationPage.NavigateToAuthenticationPage();
            authenticationPage.LoginWithTestAccount();

            Assert.AreEqual(expectedMyAccountPageTitle, Driver.Title, pageTitleNotExpectedErrorMessage);
            myWishlistsPage.ClickSignOutButton();
        }
    }
}