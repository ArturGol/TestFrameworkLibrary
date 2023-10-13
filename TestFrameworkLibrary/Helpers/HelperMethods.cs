using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFrameworkLibrary.Helpers
{
    public static class HelperMethods
    {
        public static IWebElement CustomAction(By selector, CustomActions action, IWebDriver driver, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));

            IWebElement elementFound = wait.Until(_driver =>
            {
                var element = driver.FindElement(selector);

                IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
                executor.ExecuteScript(GetAction(action), element);

                return element;
            });

            return null;
        }

        public static T WaitForElement<T>(this WebDriverWait wait, IWebDriver driver, By locator, Func<IWebElement, T> condition)
        {
            return wait.Until(d =>
            {
                IWebElement element = driver.FindElement(locator);

                if (element.Displayed)
                {
                    return condition(element);
                }

                return default(T);
            });
        }

        public enum CustomActions
        {
            Click,
            ScrollUp
        }

        public static IWebElement FindElementWithRetry(By elementS, IWebDriver driver,  int maxRetries = 5)
        {
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    var element = driver.FindElement(elementS);

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

        public static IReadOnlyCollection<IWebElement> FindElementsWithRetry(By elementS, IWebDriver driver, int maxRetries = 5)
        {
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    var elements = driver.FindElements(elementS);

                    if (elements.Any())
                    {
                        return elements.ToList();
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
