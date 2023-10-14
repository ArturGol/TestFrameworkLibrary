using OpenQA.Selenium;
using TestFrameworkLibrary.Services;
using TestProjectUI.Pages.Home;

namespace TestProjectUI.Pages
{
    public class LoginPage: BasePage
    {
        private IWebElement _userNameInput => Driver.FindElement(By.Id("login_user"));
        private IWebElement _userPssswordInput => Driver.FindElement(By.Id("login_pass"));
        private IWebElement _userLoginButton => Driver.FindElement(By.Id("login_button"));
        public LoginPage(IWebDriver driver) : base(driver) { }

        public HomePage LogInto(string user)
        {
            _userNameInput.Clear();
            _userNameInput.SendKeys(AppSettingService.GetSettingValue($"{user}Name"));

            _userPssswordInput.Clear();
            _userPssswordInput.SendKeys(AppSettingService.GetSettingValue($"{user}Pass"));

            _userLoginButton.Click();

            return new HomePage(Driver);
        }
        public void Open()
        {
            Driver.Navigate().GoToUrl(AppSettingService.GetSettingValue("BaseUrl"));
        }
    }
}