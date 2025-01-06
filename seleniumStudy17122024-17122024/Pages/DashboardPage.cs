using Automation.WebDriver;
using OpenQA.Selenium;

namespace PhucDH4_MockProject.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver _driver) : base(_driver)
        {
        }

        //Web Element
        private IWebElement chartTimeAtWork => driver.FindElementByXpath("//div[@class='emp-attendance-chart']");

        //Method
        public bool VerifyChartTimeExist()
        {
            return chartTimeAtWork.Displayed;
        }
    }
}

