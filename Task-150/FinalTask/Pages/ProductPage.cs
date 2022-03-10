using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class ProductPage : BasePage
    {
        private By InformationMessageCloseButtonBy = By.CssSelector("a[title = 'Close']");
        private By myWishlistButtonBy = By.CssSelector("a[title = 'My wishlists']");
        private By ViewCustomerAccountLinkBy = By.CssSelector("a[title = 'View my customer account']");

        [FindsBy(How = How.Id, Using = "wishlist_button")]
        public IWebElement AddToWishlistButton;

        [FindsBy(How = How.CssSelector, Using = "a[title = 'Close']")]
        public IWebElement InformationMessageCloseButton;

        [FindsBy(How = How.CssSelector, Using = "a[title = 'View my customer account']")]
        public IWebElement ViewCustomerAccountLink;

        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void AddProductToWishlist()
        {
            AddToWishlistButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(InformationMessageCloseButtonBy));
            InformationMessageCloseButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ViewCustomerAccountLinkBy));
        }

        public void OpenMyCustomerAccount()
        {
            ViewCustomerAccountLink.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(myWishlistButtonBy));
        }
    }
}
