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
    public class MyWishlistsTests :BaseTestsPage
    {
        private const string printedChiffonDress = "Printed Chiffon Dress";
        private const string fadedShortSleeveTshirts = "Faded Short Sleeve T-shirts";

        public MyWishlistsTests(BrowserType browser, string version, string os) : base(browser, version, os)
        {

        }

        [Test]
        [AllureSubSuite("Wishlist")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureIssue("0003")]
        [AllureDescription("Verifies the product is successfully added in autocreated wishlist")]
        [AllureOwner("Nikolay Kostov")]
        public void VerifyProductAddedInAutoCreatedWishlist()
        {
            authenticationPage.NavigateToAuthenticationPage();
            authenticationPage.LoginWithTestAccount();
            myAccountPage.ClickMyWishlistLink();
            Assert.IsFalse(myWishlistsPage.IsWishlistTablePresent());
            myWishlistsPage.SelectProductByName(printedChiffonDress);
            productPage.AddProductToWishlist();
            productPage.OpenMyCustomerAccount();
            myAccountPage.ClickMyWishlistLink();
            myWishlistsPage.ClickViewMyWishlistLink();

            Assert.AreEqual(1, myWishlistsPage.MyWishlistsProducts.Count);
            Assert.IsTrue(myWishlistsPage.IsProductInMyWishlists(printedChiffonDress));

            myWishlistsPage.DeleteWishlist();
            myWishlistsPage.ClickSignOutButton();
        }

        [Test]
        [AllureSubSuite("Wishlist")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureIssue("0004")]
        [AllureDescription("Verifies the product is successfully added in manually created wishlist")]
        [AllureOwner("Nikolay Kostov")]
        public void VerifyProductAddedInManuallyCreatedWishlist()
        {
            authenticationPage.NavigateToAuthenticationPage();
            authenticationPage.LoginWithTestAccount();
            myAccountPage.ClickMyWishlistLink();
            myWishlistsPage.CreateWishlistManually();
            myWishlistsPage.SelectProductByName(fadedShortSleeveTshirts);
            productPage.AddProductToWishlist();
            productPage.OpenMyCustomerAccount();
            myAccountPage.ClickMyWishlistLink();
            myWishlistsPage.ClickViewMyWishlistLink();

            Assert.AreEqual(1, myWishlistsPage.MyWishlistsProducts.Count);
            Assert.IsTrue(myWishlistsPage.IsProductInMyWishlists(fadedShortSleeveTshirts));

            myWishlistsPage.DeleteWishlist();
            myWishlistsPage.ClickSignOutButton();
        }
    }
}
