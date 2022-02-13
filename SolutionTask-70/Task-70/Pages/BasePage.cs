using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Task_70.Pages
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            this.driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return this.wait;
            }
        }

        public void EnterText(IWebElement element, string textToEnter)
        {
            element.Click();
            element.Clear();
            element.SendKeys(textToEnter);
        }

        public void TakeScreenshot()
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;

            Screenshot screenshot = screenshotDriver.GetScreenshot();

            screenshot.SaveAsFile(Path.GetFullPath(@"..\..\..\Courses\SeleniumCourse\SolutionTask-70\Task-70\Screenshots\") + TestContext.CurrentContext.Test.Name + "_Screenshot" + ".png", ScreenshotImageFormat.Png);
        }
    }
}