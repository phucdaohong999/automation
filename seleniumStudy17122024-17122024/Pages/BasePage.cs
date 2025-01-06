using OpenQA.Selenium;

namespace PhucDH4_MockProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

    }
}

