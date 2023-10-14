using OpenQA.Selenium;
using TestFrameworkLibrary.Helpers;

namespace TestProjectUI.Pages.Contacts
{
    public class ContactsPage: BasePage
    {
        public ContactsPage(IWebDriver driver) : base(driver) { }

        public ContactsPageLeftBar LeftBarSection => new ContactsPageLeftBar(Driver);

        public ContactsPageCenter CenterSection => new ContactsPageCenter(Driver);

        public bool IsDisplay
        {
            get
            {
                IWebElement element = WebDriverWaitHelper.WaitFor(Driver, By.XPath("//*[@id='main-title-module']//span[text()='Contacts']"));

                return element != null ? element.Displayed && Driver.Url.Contains("Contacts") : false;
            }
        }
    }
}