using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static TestFrameworkLibrary.Helpers.HelperMethods;

namespace TestProjectUI.Pages.ActivityLog
{
    public class ActivityLogPage: BasePage
    {
        public ActivityLogPage(IWebDriver driver) : base(driver) { }

        public bool IsDisplayed
        {
            get
            {
                IWebElement element = FindElementWithRetry(By.XPath("//*[@id='main-title-module']//span[text()='Activity Log']"), Driver);
                return element.Displayed;
            }
        }
        public IEnumerable<string> SelectItemsFromList(string quantity)
        {
           IReadOnlyCollection<IWebElement> raws =  Driver.FindElements(By.XPath("//table[@class='listView']//tbody//tr"));
           IEnumerable<IWebElement> selectedRaws = raws.Take(int.Parse(quantity));

            foreach (var raw in selectedRaws)
            {
                raw.Click();
            }
            return selectedRaws.Select(x => x.Text).ToList();
        }

        public void ClickActionButton()
        {
            IWebElement element = FindElementWithRetry(By.XPath("(//div[@class='inline-elt']/button)[1]"), Driver);
            element.Click();
        }
        public void DeleteFromList()
        {
            IWebElement element = FindElementWithRetry(By.XPath("//div[text()='Delete']"), Driver);
            element.Click();
            IAlert confirmationAlert = Driver.SwitchTo().Alert();
            confirmationAlert.Accept();
        }

        public bool VerifyResult(IEnumerable<string> removedItems)
        {
           Thread.Sleep(1000);
           var raws = Driver.FindElements(By.XPath("//table[@class='listView']//tbody//tr"));
           List<string> resultPage = raws.Select(x => x.Text).ToList();
           return removedItems.All(x => !resultPage.Contains(x));
        }
    }
}