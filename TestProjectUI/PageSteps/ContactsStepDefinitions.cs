using FluentAssertions;
using TechTalk.SpecFlow;
using TestFrameworkLibrary;
using TestFrameworkLibrary.Models;
using TestProjectUI.Pages.Contacts;

namespace TestProjectUI.PageSteps
{
    [Binding]
    public class ContactsStepDefinitions : BaseTest
    {
        private ContactsPage _contactsPage;
        public ContactsStepDefinitions()
        {
            _contactsPage = new ContactsPage(Driver);
        }

        [Given(@"I click the '([^']*)' button in the left sidebar")]
        public void GivenIClickButtonOnLeftBarMenu(string menuButton)
        {
            _contactsPage.LeftBarSection.ClickMenuButton(menuButton);
            _contactsPage.CenterSection.IsCreateFormDisplay.Should().BeTrue("Create form is not displayed.");
        }

        [Then(@"I verify that the contact data matches the file '([^']*)'")]
        public void ThenIVerifyDataContactIfMatchedWithFile(string fileName)
        {
            string file = DataHandler.GetFilePath(fileName);
            ContactsUser userFile = DataHandler.ParseJson<ContactsUser>(file);
            ContactsUser userWeb = _contactsPage.CenterSection.ReadDataAfterSave();
            userFile.Should().BeEquivalentTo(userWeb, "Data from contact form does do not match.");
        }

        [When(@"I create contact from the file '([^']*)'")]
        public void WhenICreateContactFromFile(string fileName)
        {
            string file = DataHandler.GetFilePath(fileName);
            ContactsUser user = DataHandler.ParseJson<ContactsUser>(file);
            bool result = _contactsPage.CenterSection.FillForm(user);
            result.Should().BeTrue("Could not save data in contact form.");
        }

        [Given(@"I should be on the Contacts page")]
        public void GivenIAmOnContactsPage()
        {
            _contactsPage.IsDisplay.Should().BeTrue("Cannot display contact page.");
        }
    }
}
