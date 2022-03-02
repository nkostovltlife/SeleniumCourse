
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace FinalTask.Pages
{
    public class MyWishlistsPage : BasePage
    {
        private const string wishlistName = "Manual Wishlist";

        private By myWishlistTableBy = By.Id("block-history");
        private By myWishlistsProductsBlockBy = By.XPath("//div[@id='block-order-detail' and @style = 'display: block;']");

        [FindsBy(How = How.XPath, Using = "//div[@id = 'best-sellers_block_right'] //a[@class = 'product-name']")]
        public IList<IWebElement> Products;

        [FindsBy(How = How.Id, Using = "block-history")]
        public IWebElement MyWishlistTable;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'View')]")]
        public IWebElement ViewMyWishlistLink;

        [FindsBy(How = How.Id, Using = "s_title")]
        public IList<IWebElement> MyWishlistsProducts;

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement NewWishlistsNameInput;

        [FindsBy(How = How.Id, Using = "submitWishlist")]
        public IWebElement NewWishliststSaveButton;

        [FindsBy(How = How.CssSelector, Using = ".wishlist_delete > a")]
        public IWebElement WishlistDeleteButton;


        public MyWishlistsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool isWishlistTablePresent()
        {
            try
            {
                Driver.FindElement(myWishlistTableBy);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        public void SelectProductByName(string productName)
        {
            try
            {
                foreach (IWebElement Product in Products)
                {
                    if (Product.Text.Contains(productName))
                    {
                        Product.Click();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ClickViewMyWishlistLink()
        {
            ViewMyWishlistLink.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(myWishlistsProductsBlockBy));
        }

        public bool IsProductInMyWishlists(string productName)
        {
            foreach (IWebElement MyWishlistProduct in MyWishlistsProducts)
            {
                if (MyWishlistProduct.Text.Contains(productName))
                {
                    return true;
                }
            }
            return false;
        }

        public void CreateWishlistManually()
        {
            EnterText(NewWishlistsNameInput, wishlistName);
            NewWishliststSaveButton.Click();
        }

        public void DeleteWishlist()
        {
            WishlistDeleteButton.Click();
            Driver.SwitchTo().Alert().Accept();
        }
    }
}
