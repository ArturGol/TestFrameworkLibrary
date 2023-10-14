using OpenQA.Selenium;

namespace TestProjectUI.Pages.Contacts
{
    public class ContactsPageLeftBar : BasePage
    {
        public ContactsPageLeftBar(IWebDriver driver): base(driver) { }

        public void ClickMenuButton(string menuButton)
        {
            Driver.FindElement(By.XPath(GetXpathForButton(menuButton))).Click();
        }

        private string GetXpathForButton(string name)
        {
            return $"//a[@class='sidebar-item-link-basic']//span[text()='{name}']/..";
        }
    }
}