using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;

namespace FinalTask.Pages
{
    public class BasePage
    {
        AuthenticationPage ap;
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }

        public void EnterText(IWebElement element, string textToEnter)
        {
            element.Click();
            element.Clear();
            element.SendKeys(textToEnter);
        }

        private static Random random = new Random();

        public string GenerateRandomEmail(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()) + "@aaa.com";
        }

        public void TakeScreenshot(string focus)
        {
            try
            {
                ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;

                Screenshot screenshot = screenshotDriver.GetScreenshot();

                screenshot.SaveAsFile(Path.GetFullPath(@"..\..\..\Courses\SeleniumCourse\SolutionTask-70\Task-70\Screenshots\") + TestContext.CurrentContext.Test.Name + "_Screenshot_" + focus + ".png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
