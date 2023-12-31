﻿using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TestProjectUI
{
    [Binding]
    public class BaseTest
    {
        public static IWebDriver Driver { get; set; }

        [AfterScenario]
        public static void CleanUpEachScenario()
        {
           if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}