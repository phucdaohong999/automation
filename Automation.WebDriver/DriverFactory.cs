using System;
using OpenQA.Selenium;
using Automation.WebDriver;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Automation.Core.Helpers;

namespace Automation.WebDriver
{
    public static class DriverFactory
    {
        public static IWebDriver InitDriver(string browserType, int timeout)
        {
            IWebDriver driver;

            switch (browserType)
            {
                case "CHROME":
                    driver = new ChromeDriver();
                    break;
                case "FIREFOX":
                    driver = new FirefoxDriver();
                    break;
                case "EDGE":
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new Exception("There is no such driver");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}

