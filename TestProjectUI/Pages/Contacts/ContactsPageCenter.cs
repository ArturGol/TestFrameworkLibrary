using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TestFrameworkLibrary.Models;
using static TestFrameworkLibrary.Helpers.HelperMethods;

namespace TestProjectUI.Pages.Contacts
{
    public class ContactsPageCenter : BasePage
    {
        public ContactsPageCenter(IWebDriver driver): base(driver) { }
        private IWebElement _firstName => Driver.FindElement(By.Id("DetailFormfirst_name-input"));
        private IWebElement _lastName => Driver.FindElement(By.Id("DetailFormlast_name-input"));
        private IWebElement _roleMenu => Driver.FindElement(By.Id("DetailFormbusiness_role-input"));
        private IWebElement _categoryMenu => Driver.FindElement(By.Id("DetailFormcategories-input"));
        private IWebElement _saveButton => Driver.FindElement(By.Id("DetailForm_save-label"));
        private IWebElement _isSaved => Driver.FindElement(By.Id("main-title-text"));
        private IWebElement _name => Driver.FindElement(By.XPath("//*[@id='_form_header']//h3"));
        private IWebElement _category => Driver.FindElement(By.XPath("//ul[@class='summary-list']//li[1]"));
        private IWebElement _role => Driver.FindElement(By.XPath("//*[@id='main-0']//div/p/following-sibling::div"));


        public bool IsCreateFormDisplay
        {
            get
            {
                IWebElement element = FindElementWithRetry(By.Id("DetailForm"), Driver);

                return element.Displayed;
            }
        }

        public bool FillForm(ContactsUser contactsUser)
        {
            FindElementWithRetry(By.Id("DetailFormfirst_name-input"), Driver);
            _firstName.Clear();
            _firstName.SendKeys(contactsUser.firstName);


            FindElementWithRetry(By.Id("DetailFormlast_name-input"), Driver);
            _lastName.Clear();
            _lastName.SendKeys(contactsUser.lastName);

            contactsUser.categories.ForEach(x =>
            {
                FindElementWithRetry(By.Id("DetailFormcategories-input"), Driver);

                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;

                executor.ExecuteScript("arguments[0].click();", _categoryMenu);

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
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            FindElementWithRetry(By.XPath("//span[@class='detailLink']/a"), Driver).Click();

            var contactsUser = wait.Until(d =>
            {
                string firstName = Driver.FindElement(By.XPath("//div[@id='_form_header']")).Text.Trim().Split(' ')[0].Trim();
                string lastName = Driver.FindElement(By.XPath("//div[@id='_form_header']")).Text.Trim().Split(' ')[1].Trim();

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
            });

            return contactsUser;
        }
    }
}