using FinalTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace FinalTask
{
    [TestFixture]
    public class Tests 
    {
        private const string expectedMyAccountPageTitle  = "My account - My Store";
        private const string accountNotCreatedErrorMessage = "The account is not created";
        private const string printedChiffonDress = "Printed Chiffon Dress";
        private const string fadedShortSleeveTshirts = "Faded Short Sleeve T-shirts";
        private const string firstProductPrice = "16.51";
        private const string secondProductPrice = "27.00";
        private const string thirdProductPrice = "26.00";

        IWebDriver driver;
        private AuthenticationPage ap;
        private CreateAccountPage ca;
        private MyAccountPage ma;
        private MyWishlistsPage mw;
        private ProductPage pp;
        private CategoryPage cp;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            ap = new AuthenticationPage(driver);
            ca = new CreateAccountPage(driver);
            ma = new MyAccountPage(driver);
            mw = new MyWishlistsPage(driver);
            pp = new ProductPage(driver);
            cp = new CategoryPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void VerifyAccountCreated()
        {
            ap.NavigateToAuthenticationPage();
            ap.EnterText(ap.CreateAccountEmailInput, ap.GenerateRandomEmail(8));
            ap.ClickCreateAccountButton();
            ca.FillRegistrationForm();
            ca.ClickRegisterButton();
            
            Assert.AreEqual(expectedMyAccountPageTitle, driver.Title, accountNotCreatedErrorMessage);
        }

        [Test]
        public void VerifyAccountLoginSuccessful()
        {
            ap.NavigateToAuthenticationPage();
            ap.LoginWithTestAccount();

            Assert.AreEqual(expectedMyAccountPageTitle, driver.Title);
        }

        [Test]
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
