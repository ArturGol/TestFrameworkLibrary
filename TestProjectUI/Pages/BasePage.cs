using OpenQA.Selenium;

namespace TestProjectUI.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; set; }
    }
}
