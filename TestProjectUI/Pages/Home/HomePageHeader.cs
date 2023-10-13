using OpenQA.Selenium;
using System;
using static TestFrameworkLibrary.Helpers.HelperMethods;

namespace TestProjectUI.Pages.Home
{
    public class HomePageHeader : BasePage
    {
        public HomePageHeader(IWebDriver driver) : base(driver) { }
        private IWebElement _salesMarketingButton => Driver.FindElement(By.Id("grouptab-1"));
        private IWebElement _reportsSettingsButton => Driver.FindElement(By.Id("grouptab-5"));
        private IWebElement _contactButton => Driver.FindElement(By.XPath("//a[@href='index.php?module=Contacts&action=index']"));
        private IWebElement _reportButton => Driver.FindElement(By.XPath("//a[@href='index.php?module=Reports&action=index']"));

        public void HoverOverHeaderMenu(string menuButton)
        {
            FindElementWithRetry(GetHoverHeaderSelector(menuButton), Driver);

            Driver.FindElement(GetHoverHeaderSelector(menuButton)).Click();
        }

        public void ClickHeaderMenuButton(string menuButton)
        {
            FindElementWithRetry(GetHeaderMenuButton(menuButton), Driver);

            Driver.FindElement(GetHeaderMenuButton(menuButton)).Click();

        }

        private By GetHoverHeaderSelector(string headerMenuNuttonName)
        {
            switch (headerMenuNuttonName)
            {
                case "Sales & Marketing":
                    return By.Id("grouptab-1");

                case "Reports & Settings":
                    return By.Id("grouptab-5");

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