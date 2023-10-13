using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

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
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

                IWebElement element = wait.Until(_driver =>
                {
                    try
                    {
                       IWebElement elementFound =  _driver.FindElement(By.XPath("//*[@id='main-title-module']//span[text()='Contacts']"));

                       return elementFound;
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }

                });

                return element != null ? element.Displayed && Driver.Url.Contains("Contacts") : false;
            }
        }
    }
}