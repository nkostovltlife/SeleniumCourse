using Allure.Commons;
using FinalTask.Pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace FinalTask
{
    [TestFixture]
    [AllureNUnit]
    public class Tests : BaseTestsPage
    {
        private const string expectedMyAccountPageTitle  = "My account - My Store";
        private const string accountNotCreatedErrorMessage = "The account is not created";
        private const string printedChiffonDress = "Printed Chiffon Dress";
        private const string fadedShortSleeveTshirts = "Faded Short Sleeve T-shirts";
        private const string firstProductPrice = "16.51";
        private const string secondProductPrice = "27.00";
        private const string thirdProductPrice = "26.00";

        public Tests()
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
            ap.NavigateToAuthenticationPage();
            ap.EnterText(ap.CreateAccountEmailInput, ap.GenerateRandomEmail(8));
            ap.ClickCreateAccountButton();
            ca.FillRegistrationForm();
            ca.ClickRegisterButton();
            
            Assert.AreEqual(expectedMyAccountPageTitle, Driver.Title, accountNotCreatedErrorMessage);
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
            ap.NavigateToAuthenticationPage();
            ap.LoginWithTestAccount();

           Assert.AreEqual(expectedMyAccountPageTitle, Driver.Title);
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
        }

        [Test]
        [AllureSubSuite("Cart")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureIssue("0005")]
        [AllureDescription("Verifies 3 products are successfully added in the Cart")]
        [AllureOwner("Nikolay Kostov")]
        public void Verify3ProductsAddedInCart()
        {
            ap.NavigateToAuthenticationPage();
            ap.LoginWithTestAccount();
            ma.ClickWomanCategoryButton();
            cp.Add3ProductsInCart(firstProductPrice, secondProductPrice, thirdProductPrice);
            
            Assert.AreEqual(3, cp.GetCartQuantity());
            Assert.IsTrue(cp.IsCartContains3AddedProducts(firstProductPrice, secondProductPrice, thirdProductPrice));
            Assert.IsTrue(cp.IsTotalCorrect(firstProductPrice, secondProductPrice, thirdProductPrice));
        }
    }
}
