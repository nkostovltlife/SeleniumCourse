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
    public class CartTests : BaseTestsPage
    {
        private const string firstProductPrice = "16.51";
        private const string secondProductPrice = "27.00";
        private const string thirdProductPrice = "26.00";

        public CartTests(BrowserType browser, string version, string os) : base(browser, version, os)
        {

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
            authenticationPage.NavigateToAuthenticationPage();
            authenticationPage.LoginWithTestAccount();
            myAccountPage.ClickWomanCategoryButton();
            categoryPage.Add3ProductsInCart(firstProductPrice, secondProductPrice, thirdProductPrice);

            Assert.AreEqual(3, categoryPage.GetCartQuantity(), "Cart Quantity has wrong value");
            Assert.IsTrue(categoryPage.IsCartContains3AddedProducts(firstProductPrice, secondProductPrice, thirdProductPrice));
            Assert.IsTrue(categoryPage.IsTotalCorrect(firstProductPrice, secondProductPrice, thirdProductPrice));
        }
    }
}
