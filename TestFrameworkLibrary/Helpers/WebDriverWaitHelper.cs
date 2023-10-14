using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestFrameworkLibrary.Helpers
{
    public static class WebDriverWaitHelper
    {
        public static IWebElement WaitFor(IWebDriver driver, By by, double seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(d => d.FindElement(by));
        }

        public static ReadOnlyCollection<IWebElement> WaitForElements(IWebDriver driver, By by, double seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(d => driver.FindElements(by));
        }
    }
}
