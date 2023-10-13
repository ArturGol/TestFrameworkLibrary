using OpenQA.Selenium;
using System;
using TestProjectUI.Pages;
using TestProjectUI.Pages.Contacts;
using TestProjectUI.Pages.Reports;
using static TestFrameworkLibrary.Helpers.HelperMethods;

namespace TestProjectUI
{
    public class HeaderSectionContactPage : BasePage
    {
        public HeaderSectionContactPage(IWebDriver driver) : base(driver) { }
    }
}