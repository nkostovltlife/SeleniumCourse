using FinalTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalTask
{
    [TestFixture]
    public class BaseTestsPage
    {
        protected AuthenticationPage ap;
        protected CreateAccountPage ca;
        protected MyAccountPage ma;
        protected MyWishlistsPage mw;
        protected ProductPage pp;
        protected CategoryPage cp;

        private IWebDriver driver;
        public BaseTestsPage()
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            ap = new AuthenticationPage(Driver);
            ca = new CreateAccountPage(Driver);
            ma = new MyAccountPage(Driver);
            mw = new MyWishlistsPage(Driver);
            pp = new ProductPage(Driver);
            cp = new CategoryPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ap.TakeScreenshot("TestFailed");
            }
            Driver.Quit();
        }
    }
}
