using OpenQA.Selenium;
using TestFrameworkLibrary.Helpers;

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
                IWebElement element = WebDriverWaitHelper.WaitFor(Driver, By.Id("dashboard_columns"));

                return element != null ? element.Displayed && Driver.Url.Contains("Home") : false;
            }
          
        }
    }
}