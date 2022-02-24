using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Task50_9
{
    public class Task50_9Page
    {
        private By nextButtonLocator = By.Id("example_next");
        private By rowsInTableLocator = By.XPath("//tbody/tr");
        private By pagesInTableLocator = By.CssSelector("span .paginate_button");
        private string nameLocator = "//tbody/tr[{0}]/td[1]";
        private string positionLocator = "//tbody/tr[{0}]/td[2]";
        private string officeLocator = "//tbody/tr[{0}]/td[3]";
        private string ageLocator = "//tbody/tr[{0}]/td[4]";
        private string salaryLocator = "//tbody/tr[{0}]/td[6]";

        private const string url = "https://demo.seleniumeasy.com/table-sort-search-demo.html";

        List<Employee> data = new List<Employee>();

        public Task50_9Page(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver { get; }

        public void NavigateToTask50_9Page()
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement nextButton => Driver.FindElement(nextButtonLocator);

        public List<Employee> GetTableData(int x, int y)
        {
            int pagesInTable = Driver.FindElements(pagesInTableLocator).Count;
            for (int j = 1; j <= pagesInTable; j++)
            {
                int rowsInTable = Driver.FindElements(rowsInTableLocator).Count;
                for (int i = 1; i <= rowsInTable; i++)
                {
                    int age = Int16.Parse(Driver.FindElement(By.XPath(String.Format(ageLocator, i))).Text);
                    int salary = Int32.Parse(Driver.FindElement(By.XPath(String.Format(salaryLocator, i))).GetAttribute("data-order"));
                    if (age > x && salary <= y)
                    {
                        string name = Driver.FindElement(By.XPath(String.Format(nameLocator, i))).Text;
                        string position = Driver.FindElement(By.XPath(String.Format(positionLocator, i))).Text;
                        string office = Driver.FindElement(By.XPath(String.Format(officeLocator, i))).Text;

                        data.Add(new Employee(name, position, office));                    
                    }
                }
                if (j != 4)
                {
                    nextButton.Click();
                }
            }
            return data;
        }
    }
}
