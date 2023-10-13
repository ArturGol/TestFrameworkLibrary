using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using static TestFrameworkLibrary.Helpers.HelperMethods;

namespace TestProjectUI.Pages.Reports
{
    public class ReportsPage : BasePage
    {
        private IWebElement _reportName => Driver.FindElement(By.Id("filter_text"));
        private IWebElement _reportNameClick => Driver.FindElement(By.XPath("//a[@class='listViewNameLink']"));
        private IWebElement _reportRunButton => Driver.FindElement(By.Name("FilterForm_applyButton"));
        private IWebElement _reports => Driver.FindElement(By.Id("main-title-module"));
        private IReadOnlyCollection<IWebElement> _dataReports => Driver.FindElements(By.XPath("//tr[@data-id]"));
        public CenterSectionReportPage CenterSection => new CenterSectionReportPage(Driver);
        public bool IsDisplay
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

                IWebElement element = wait.Until(_driver =>
                {
                    try
                    {
                        IWebElement elementFound = _driver.FindElement(By.XPath("//*[@id='main-title-module']//span[text()='Reports']"));

                        return elementFound;
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }

                });

                return element != null ? element.Displayed && Driver.Url.Contains("Reports") : false;
            }
        }

        public ReportsPage(IWebDriver driver) : base(driver)
        {
        }

        public void FindReport(string reportName)
        {
            FindElementWithRetry(By.Id("filter_text"), Driver);
           
            _reportName.Clear();
            _reportName.SendKeys(reportName);

            _reports.Click();

            FindElementWithRetry(By.XPath("//a[@class='listViewNameLink']"), Driver);

            _reportNameClick.Click();

            //CustomAction(By.XPath("//a[@class='listViewNameLink']"), CustomActions.Click, Driver, 5);
        }

        public void RunReport()
        {
            FindElementWithRetry(By.Name("FilterForm_applyButton"), Driver);
            _reportRunButton.Click();
        }

        public bool IsAnyData()
        {
            FindElementWithRetry(By.XPath("//tr[@data-id]") , Driver);
            return _dataReports.Count > 0;
        }
    }
}