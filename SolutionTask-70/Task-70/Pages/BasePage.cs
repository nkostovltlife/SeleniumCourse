using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Task_70.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            this.Driver.Manage().Window.Maximize();     
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }

        [AllureStep("Add text")]
        public void EnterText(IWebElement element, string textToEnter)
        {
            element.Click();
            element.Clear();
            element.SendKeys(textToEnter);
        }

        public void TakeScreenshot(string focus)
        {
            try
            {               
                ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;       
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                string screenshotDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Courses\SeleniumCourse\SolutionTask-70\Task-70\Screenshots\"));
                var fileName = TestContext.CurrentContext.Test.Name + "_Screenshot_" + focus + "_" + DateTime.Now.ToString("HH-mm-ss") + ".png";              
                var fileLocation = Path.Combine(screenshotDirectory, fileName);
                
                screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}