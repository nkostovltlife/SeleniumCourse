using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task50_9
{
    [TestFixture]
    public class TestTask50_9
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        [Description("Verifies that GetTableData method returns list of custom objects (class fields: Name, Position, Office) with age > x and salary <= y for all pages")]
        public void VerifyGetTableDataMethodCollectCorrectData()
        {
            Task50_9Page tp = new Task50_9Page(driver);
            
            tp.NavigateToTask50_9Page();

            Assert.AreEqual(5, tp.GetTableData(40, 150000).Count);
            Assert.AreEqual("San Francisco", tp.GetTableData(40, 150000)[0].Office.ToString());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
