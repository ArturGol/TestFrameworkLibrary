using OpenQA.Selenium;
using System.Collections.Generic;
using TestFrameworkLibrary.Helpers;
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

        public ReportsPage(IWebDriver driver) : base(driver) { }

        public bool IsDisplay
        {
            get
            {
                IWebElement element = WebDriverWaitHelper.WaitFor(Driver, By.XPath("//*[@id='main-title-module']//span[text()='Reports']"));

                return element != null ? element.Displayed && Driver.Url.Contains("Reports") : false;
            }
        }

        public void FindReport(string reportName)
        {
            FindElementWithRetry(By.Id("filter_text"), Driver);
           
            _reportName.Clear();
            _reportName.SendKeys(reportName);

            _reports.Click();

            FindElementWithRetry(By.XPath("//a[@class='listViewNameLink']"), Driver);

            _reportNameClick.Click();
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