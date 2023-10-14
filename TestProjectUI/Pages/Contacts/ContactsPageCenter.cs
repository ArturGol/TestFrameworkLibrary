using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Threading;
using TestFrameworkLibrary.Helpers;
using TestFrameworkLibrary.Models;
using static TestFrameworkLibrary.Helpers.HelperMethods;

namespace TestProjectUI.Pages.Contacts
{
    public class ContactsPageCenter : BasePage
    {
        public ContactsPageCenter(IWebDriver driver): base(driver) { }
        private IWebElement _roleMenu => Driver.FindElement(By.Id("DetailFormbusiness_role-input"));
        private IWebElement _saveButton => Driver.FindElement(By.Id("DetailForm_save-label"));
        private IWebElement _isSaved => Driver.FindElement(By.Id("main-title-text"));
        private IWebElement _category => Driver.FindElement(By.XPath("//ul[@class='summary-list']//li[1]"));
        private IWebElement _role => Driver.FindElement(By.XPath("//*[@id='main-0']//div/p/following-sibling::div"));

        public bool IsCreateFormDisplay
        {
            get
            {
                IWebElement element = FindElementWithRetry(By.Id("DetailForm"), Driver);

                return element != null && element.Displayed;
            }
        }

        public bool FillForm(ContactsUser contactsUser)
        {
            IWebElement firstName =  FindElementWithRetry(By.Id("DetailFormfirst_name-input"), Driver);
            if(firstName != null)
            {
                firstName.Clear();
                firstName.SendKeys(contactsUser.firstName);
            }
            else
            {
                return false;
            }

            IWebElement lastName = FindElementWithRetry(By.Id("DetailFormlast_name-input"), Driver);
            lastName.Clear();
            lastName.SendKeys(contactsUser.lastName);

            Thread.Sleep(1000);

            contactsUser.categories.ForEach(x =>
            {
                IWebElement categoryMenu = FindElementWithRetry(By.Id("DetailFormcategories-input"), Driver);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", categoryMenu);
                Thread.Sleep(1000);
                var actions = new Actions(Driver);
                actions.MoveToElement(Driver.FindElement(By.XPath($"//*[@id='DetailFormcategories-input-search-list']//div[text()='{x}']"))).Build().Perform();
                Thread.Sleep(1000);
                executor.ExecuteScript("arguments[0].click();", Driver.FindElement(By.XPath($"//*[@id='DetailFormcategories-input-search-list']//div[text()='{x}']")));
                Thread.Sleep(1000);
            });

            var action = new Actions(Driver);
            action.MoveToElement(_roleMenu).Build().Perform();
            _roleMenu.Click();
            action.MoveToElement(Driver.FindElement(By.Id($"DetailFormbusiness_role-input"))).Build().Perform();
            Driver.FindElement(By.XPath($"//div[text()='{contactsUser.role}']")).Click();
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, 0);");
            _saveButton.Click();
            return _isSaved.Displayed;
        }

        public ContactsUser ReadDataAfterSave()
        {
            FindElementWithRetry(By.XPath("//span[@class='detailLink']/a"), Driver).Click();
            IWebElement nameElement = WebDriverWaitHelper.WaitFor(Driver, By.XPath("//div[@id='_form_header']"));
            string[] name = nameElement.Text.Trim().Split(' ');
            string firstName = name[0].Trim();
            string lastName = name[1].Trim();
            IWebElement pElement = Driver.FindElement(By.CssSelector("ul.summary-list p.form-label"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            string text = (string)jsExecutor.ExecuteScript("return arguments[0].lastChild.textContent;", pElement);
            string names = _category.Text.Replace(text, String.Empty);
            string[] categories = names.Trim().Replace(",", "").Split(' ');
            string role = _role.Text.Trim();

            return new ContactsUser()
            {
                firstName = firstName,
                lastName = lastName,
                categories = categories.ToList(),
                role = role
            };
        }
    }
}