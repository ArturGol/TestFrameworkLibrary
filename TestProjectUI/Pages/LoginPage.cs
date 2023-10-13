using OpenQA.Selenium;
using TestProjectUI.Pages.Home;

namespace TestProjectUI.Pages
{
    public class LoginPage: BasePage
    {
        private string _url = "https://demo.1crmcloud.com";
        private IWebElement _userNameInput => Driver.FindElement(By.Id("login_user"));
        private IWebElement _userPssswordInput => Driver.FindElement(By.Id("login_pass"));
        private IWebElement _userLoginButton => Driver.FindElement(By.Id("login_button"));
        public LoginPage(IWebDriver driver) : base(driver) { }

     

        public HomePage LogInto(string admin)
        {
            _userNameInput.Clear();
            _userNameInput.SendKeys("admin");

            _userPssswordInput.Clear();
            _userPssswordInput.SendKeys("admin");

            _userLoginButton.Click();

            return new HomePage(Driver);
        }
        public void Open()
        {
            Driver.Navigate().GoToUrl(_url);
        }
    }
}