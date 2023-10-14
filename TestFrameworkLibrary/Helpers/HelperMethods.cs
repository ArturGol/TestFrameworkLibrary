using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using TestFrameworkLibrary.Enums;

namespace TestFrameworkLibrary.Helpers
{
    public static class HelperMethods
    {
        public static IWebElement CustomAction(By selector, CustomActions action, IWebDriver driver, double seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement element = wait.Until(d => d.FindElement(selector));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript(GetAction(action), element);

            return element;
        }

        public static IWebElement FindElementWithRetry(By selector, IWebDriver driver,  int maxRetries = 5)
        {
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    IWebElement element = driver.FindElement(selector);

                    if (element.Displayed)
                    {
                        return element;
                    }
                }
                catch (NoSuchElementException)
                {
                    // Element not found 
                }
                catch (StaleElementReferenceException)
                {
                    // Element not stable
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
                retryCount++;
            }

            // Element not found
            return null;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsWithRetry(By selector, IWebDriver driver, int maxRetries = 5)
        {
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> elements = driver.FindElements(selector);

                    if (elements.Any())
                    {
                        return elements;
                    }
                }
                catch (NoSuchElementException)
                {
                    // Element not found 
                }
                catch (StaleElementReferenceException)
                {
                    // Element not stable
                }


                Thread.Sleep(TimeSpan.FromSeconds(1));
                retryCount++;
            }

            // Element not found
            return null;
        }

        private static string GetAction(CustomActions action)
        {
            switch (action)
            {
                case CustomActions.Click:
                    return "arguments[0].click();";
                case CustomActions.ScrollUp:
                    return "window.scrollTo(0, 0);";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
