using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace TestFrameworkLibrary
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var driver = new ChromeDriver(outPutDirectory);
                    driver.Manage().Window.Maximize();
                    return driver;
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
    }
}