using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FinalTask.Pages
{
    public class CategoryPage : BasePage
    {
        private By continueShoppingButtonBy = By.CssSelector("span[title = 'Continue shopping']");
        private By addCartButtonBy = By.XPath(".//a[@title = 'Add to cart']");
        private By productPriceBy = By.XPath(".//span[@itemprop = 'price']");

        [FindsBy(How = How.CssSelector, Using = "ul .product-container")]
        public IList<IWebElement> AllProducts;

        [FindsBy(How = How.CssSelector, Using = "cart-info .price")]
        public IList<IWebElement> AllCartPrices;

        [FindsBy(How = How.CssSelector, Using = "span[title = 'Continue shopping']")]
        public IWebElement ContinueShoppingButton;

        [FindsBy(How = How.CssSelector, Using = ".shopping_cart .ajax_cart_quantity")]
        public IWebElement CartQuantity;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'price cart_block_total ajax_block_cart_total']")]
        public IWebElement TotalCartPrice;

        public CategoryPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void Add3ProductsInCart(string firstProductPrice, string secondProductPrice, string thirdProductPrice)
        {
            int counter = 1;
            foreach (IWebElement Product in AllProducts)
            {
                Product.Click();
                string tmp = Product.Text;
                if (tmp.Contains(firstProductPrice) || tmp.Contains(secondProductPrice) || tmp.Contains(thirdProductPrice))
                {
                    Product.FindElement(addCartButtonBy).Click();
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(continueShoppingButtonBy));
                    ContinueShoppingButton.Click();Thread.Sleep(2000);
                }
                if (counter == 3)
                {
                    break;
                }
                counter++;
            }
        }

        public int GetCartQuantity()
        {
            return Int32.Parse(CartQuantity.Text);
        }

        public bool IsCartContains3AddedProducts(string firstProductPrice, string secondProductPrice, string thirdProductPrice)
        {
            bool result = true;
            foreach (IWebElement CartPrice in AllCartPrices)
            {
                string tmp = CartPrice.Text.Substring(1);
                if (!tmp.Equals(firstProductPrice) && !tmp.Equals(secondProductPrice) && !tmp.Equals(thirdProductPrice))
                {
                    result = false;
                }
            }
            return result;
        }

        public bool IsTotalCorrect(string firstProductPrice, string secondProductPrice, string thirdProductPrice)
        {
            string tmp = TotalCartPrice.GetAttribute("textContent");
            if (Convert.ToDouble(tmp.Replace("$", "")) == Convert.ToDouble(firstProductPrice) + Convert.ToDouble(secondProductPrice) + Convert.ToDouble(thirdProductPrice) + 2.00)
            {
                return true;
            }
            return false;
        }
      
    }
}
