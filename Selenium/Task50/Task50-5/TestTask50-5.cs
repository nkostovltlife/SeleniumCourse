using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task50_5
{
    [TestFixture]
    public class TestTask50_5
    {
        private string option1 = "California";
        private string option4 = "New York";
        private string option5 = "Ohio";

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [Test]
        [Description("Verifies that 3 random options are selected")]
        public void Verify3RandomOptionsSelected()
        {
            Task50_5Page tp = new Task50_5Page(driver);
            tp.NavigateToTask50_5Page();
            tp.Select3Options(option1, option4, option5);

            Assert.AreEqual(3, tp.Select.AllSelectedOptions.Count);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
