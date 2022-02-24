using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Task50_6
{
    [TestFixture]
    public class TestTask50_6
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [Test]
        [Description("Verifies that JSAlertBox is closed when the alertbox button is clicked")]
        public void VerifyJSAlertBoxClosedWhenOKButtonClicked()
        {
            Task50_6Page tp = new Task50_6Page(driver);

            tp.NavigateToTask50_6Page();     
            tp.jSAlertBoxButton.Click();
            driver.SwitchTo().Alert().Accept();

            Assert.IsTrue(tp.IsAlertClosed(driver));
        }

        [Test]
        [Description("Verifies that when the JSConfirmBox is dismissed (Cancel button is clicked), the alert is closed.")]
        public void VerifyJSConfirmBoxClosedWhenCancelButtonClicked()
        {
            Task50_6Page tp = new Task50_6Page(driver);

            tp.NavigateToTask50_6Page();
            tp.jSConfirmBoxButton.Click();
            driver.SwitchTo().Alert().Dismiss();

            Assert.AreEqual(true, tp.IsAlertClosed(driver));
        }

        [Test]
        [Description("Verifies when the user adds text in the JSPromptBox and accept the alert, it will be applied in the page.  ")]
        public void VerifyAddingTextInJSPromptBoxSuccessful()
        {
            Task50_6Page tp = new Task50_6Page(driver);
            tp.NavigateToTask50_6Page();
            Thread.Sleep(1000);

            tp.jSPromptBoxButton.Click();
            driver.SwitchTo().Alert().SendKeys("Nikolay Kostov");
            driver.SwitchTo().Alert().Accept();

            Assert.IsTrue(tp.jSPromptBoxMessage.Text.Contains("Nikolay Kostov"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
