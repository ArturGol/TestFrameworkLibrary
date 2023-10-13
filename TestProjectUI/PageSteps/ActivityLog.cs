using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using TechTalk.SpecFlow;
using TestProjectUI.Pages;
using static TestFrameworkLibrary.Helpers.HelperMethods;

namespace TestProjectUI.PageSteps
{
    public class ActivityLog: BasePage
    {
        public ActivityLog(IWebDriver driver) : base(driver) { }

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

           var selectedRaws = raws.Take(3);

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