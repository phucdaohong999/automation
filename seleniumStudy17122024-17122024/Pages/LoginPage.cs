using Automation.WebDriver;
using OpenQA.Selenium;

namespace PhucDH4_MockProject.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
        }

        //Web Element
        private IWebElement inputUsername => driver.FindElementByXpath("//input[@name = 'username']");
        private IWebElement inputPassword => driver.FindElementByXpath("//input[@name = 'password']");
        private IWebElement btnLogin => driver.FindElementByXpath("//button[contains(., 'Login')]");
        private IWebElement btnSubmit => driver.FindElementByXpath("//button[@id = 'submit']");
        private IWebElement errorMessage => driver.FindElementByXpath("//div[@id = 'error']");
        private IList<IWebElement> radioButtonList => driver.FindElementsByXpath("//input[@type = 'radio']");
        private IWebElement radioButton => driver.FindElementByXpath("//input[@value = 'user']");

        //Method
        [Obsolete]
        public string GetRadioButton()
        {
            return radioButton.GetAttribute("value");
        }

        public IList<IWebElement> GetRadioButtonList()
        {
            return radioButtonList;
        }

        public void EnterUsername(string username)
        {
            inputUsername.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            inputPassword.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            btnLogin.Click();
        }

        public void ClickSubmitButton()
        {
            btnSubmit.Click();
        }

        public void EnterUsernameAndPassword(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
        }

        public void GoToLogin(string url)
        {
            driver.Go(url);
        }

        public bool VerifyErrorMessageExist()
        {
            return errorMessage.Displayed;
        }

        public bool VerifyCorrectErrorMessage(string inputErrorMessage)
        {
            return errorMessage.Text == inputErrorMessage;
        }
    }
}

