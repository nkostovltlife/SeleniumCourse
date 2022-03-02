using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class MyAccountPage : BasePage
    {
        private By myWishlistBlockBy = By.Id("mywishlist");
        private By womanCartBy = By.XPath("//ul[@class = 'product_list grid row']");

        [FindsBy(How = How.CssSelector, Using = "a[title='My wishlists']")]
        public IWebElement MyWishlistLink;

        [FindsBy(How = How.XPath, Using = "//a[@href='http://automationpractice.com/index.php?id_category=3&controller=category' and @class]")]
        public IWebElement WomanCategoryButton;

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ClickMyWishlistLink()
        {
            MyWishlistLink.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(myWishlistBlockBy));
        }

        public void ClickWomanCategoryButton()
        {
            WomanCategoryButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(womanCartBy));
        }
    }
}
