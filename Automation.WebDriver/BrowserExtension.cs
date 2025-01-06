using OpenQA.Selenium;

namespace Automation.WebDriver
{
    public static class BrowserExtension
    {
        public static void Go(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElementByXpath(this IWebDriver driver,string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        public static IList<IWebElement> FindElementsByXpath(this IWebDriver driver, string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }
    }
}

