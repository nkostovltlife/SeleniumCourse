using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Task50_5
{
    [TestFixture]
    public class TestTask50_5
    {
        private string option1 = "California";
        private string option4 = "New York";
        private string option5 = "Ohio";

        IWebDriver driver;

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

            Assert.IsTrue(tp.option1.Selected);
            Assert.IsTrue(tp.option4.Selected);
            Assert.IsTrue(tp.option5.Selected);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
