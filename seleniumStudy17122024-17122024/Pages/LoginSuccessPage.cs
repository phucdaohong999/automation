using Automation.WebDriver;
using OpenQA.Selenium;

namespace PhucDH4_MockProject.Pages
{
    public class LoginSuccessPage : BasePage
    {
        public LoginSuccessPage(IWebDriver _driver) : base(_driver)
        {
        }

        //Web Element
        private IWebElement loggedTitlePage => driver.FindElementByXpath("//h1[@class = 'post-title']");
        private IWebElement btnLogOut => driver.FindElementByXpath("//a[text() = 'Log out']");

        //Method
        public bool VerifyLoggedInMessage(string loggedInMessage)
        {
            return loggedTitlePage.Text == loggedInMessage;
        }

        public bool VerifyLogOutButtonExist()
        {
            return btnLogOut.Displayed;
        }
    }
}

