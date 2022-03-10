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
            ap.NavigateToAuthenticationPage();
            ap.LoginWithTestAccount();
            ma.ClickMyWishlistLink();
            Assert.IsFalse(mw.isWishlistTablePresent());
            mw.SelectProductByName(printedChiffonDress);
            pp.AddProductToWishlist();
            pp.OpenMyCustomerAccount();
            ma.ClickMyWishlistLink();
            mw.ClickViewMyWishlistLink();

            Assert.AreEqual(1, mw.MyWishlistsProducts.Count);
            Assert.IsTrue(mw.IsProductInMyWishlists(printedChiffonDress));

            mw.DeleteWishlist();
            mw.ClickSignOutButton();
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
            ap.NavigateToAuthenticationPage();
            ap.LoginWithTestAccount();
            ma.ClickMyWishlistLink();
            mw.CreateWishlistManually();
            mw.SelectProductByName(fadedShortSleeveTshirts);
            pp.AddProductToWishlist();
            pp.OpenMyCustomerAccount();
            ma.ClickMyWishlistLink();
            mw.ClickViewMyWishlistLink();

            Assert.AreEqual(1, mw.MyWishlistsProducts.Count);
            Assert.IsTrue(mw.IsProductInMyWishlists(fadedShortSleeveTshirts));

            mw.DeleteWishlist();
            mw.ClickSignOutButton();
        }
    }
}
