using OpenQA.Selenium;
using System;
using static TestFrameworkLibrary.Helpers.HelperMethods;

namespace TestProjectUI.Pages.Home
{
    public class HomePageHeader : BasePage
    {
        public HomePageHeader(IWebDriver driver) : base(driver) { }
        private By _salesMarketingButton => By.Id("grouptab-1");
        private By _reportsSettingsButton => By.Id("grouptab-5");

        public void HoverOverHeaderMenu(string menuButton)
        {
            FindElementWithRetry(GetHoverHeaderSelector(menuButton), Driver).Click();
        }

        public void ClickHeaderMenuButton(string menuButton)
        {
            FindElementWithRetry(GetHeaderMenuButton(menuButton), Driver).Click();
        }

        private By GetHoverHeaderSelector(string headerMenuNuttonName)
        {
            switch (headerMenuNuttonName)
            {
                case "Sales & Marketing":
                    return _salesMarketingButton;

                case "Reports & Settings":
                    return _reportsSettingsButton;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private By GetHeaderMenuButton(string headerMenuNuttonName)
        {
            switch (headerMenuNuttonName)
            {
                case "Contacts":
                    return By.XPath("//a[@href='index.php?module=Contacts&action=index']");

                case "Reports":
                    return By.XPath("//a[@href='index.php?module=Reports&action=index']");

                case "Activity log":
                    return By.XPath("//a[@href='index.php?module=ActivityLog&action=index']");

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}