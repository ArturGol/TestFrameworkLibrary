using FluentAssertions;
using TechTalk.SpecFlow;
using TestFrameworkLibrary;
using TestProjectUI.Pages;
using TestProjectUI.Pages.Contacts;
using TestProjectUI.Pages.Home;

namespace TestProjectUI.PageSteps
{
    [Binding]
    public class CommonSteps: BaseTest
    {
        private readonly WebDriverFactory _driverFactory;
        private HomePage _homePage;
        private ContactsPage _contactsPage;
        public CommonSteps()
        {
            _driverFactory = new WebDriverFactory();
        }

        [Given(@"I open the '([^']*)' browser")]
        public void GivenIOpenBrowser(string browser)
        {
            Driver = _driverFactory.Create(browser);
        }

        [Given(@"I navigate to the login page as '([^']*)'")]
        public void GivenINavigateToLoginPageAs(string user)
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Open();
            _homePage = loginPage.LogInto(user);
            bool isLogged = _homePage.IsLogged;

            isLogged.Should().BeTrue();
        }

        [Given(@"I navigate to '([^']*)' from the header")]
        public void GivenINavigateOverOnHeader(string menuButton)
        {
            _homePage.HeaderSection.HoverOverHeaderMenu(menuButton);
        }

        [Given(@"I click on '([^']*)' in the header")]
        public void GivenIClickOnHeader(string menuButton)
        {
             _homePage.HeaderSection.ClickHeaderMenuButton(menuButton);
        }
      
    }
}
