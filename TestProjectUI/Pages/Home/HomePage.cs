using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProjectUI.Pages.Home
{
    public class HomePage: BasePage
    {
        public HomePage(IWebDriver driver): base(driver) { }
        public HomePageHeader HeaderSection => new HomePageHeader(Driver);

        public bool IsLogged
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

                IWebElement element = wait.Until(_driver =>
                {
                    try
                    {
                        return _driver.FindElement(By.Id("dashboard_columns"));
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }

                });

                return element != null ? element.Displayed && Driver.Url.Contains("Home") : false;
            }
        }
    }
}