using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task50_8
{
    [TestFixture]
    public class TestTask50_8
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        [Description("The script reloads the page when the progress bar shows 50% or more")]
        public void ReloadPageWhenProgressBarEqual50()
        {
            Task50_8Page tp = new Task50_8Page(driver);

            tp.NavigateToTask50_8Page();
            tp.downloadButton.Click();
            tp.ReloadPage();      
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
