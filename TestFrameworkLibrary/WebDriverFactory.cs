using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkLibrary
{
    public class WebDriverFactory
    {
        public IWebDriver Create(string browserType)
        {
            switch (browserType)
            {
                case "Chrome":

                    var driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    return driver;
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
    }
}

