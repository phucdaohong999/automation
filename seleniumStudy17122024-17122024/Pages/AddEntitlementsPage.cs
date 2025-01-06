using Automation.WebDriver;
using OpenQA.Selenium;

namespace PhucDH4_MockProject.Pages
{
    public class AddEntitlementsPage : BasePage
    {
        public AddEntitlementsPage(IWebDriver _driver) : base(_driver)
        {
        }

        //Web Element
        private IWebElement btnLeave => driver.FindElementByXpath("//a[@class='oxd-main-menu-item']//span[text() = 'Leave']");
        private IWebElement btnEntitlements => driver.FindElementByXpath("//li//span[contains(text(),'Entitlements')]");
        private IWebElement btnAddEntitlements => driver.FindElementByXpath("//a[text()='Add Entitlements']");
        private IWebElement employeeNameInput => driver.FindElementByXpath("//label[text()='Employee Name']//parent::div//following-sibling::div//input");

        private IWebElement dropdown(string dropDownLabel) => driver.FindElementByXpath($"//label[text()='{dropDownLabel}']//..//following-sibling::div");
        private IWebElement nonBlankOptionOfDropdown(string option, string dropDownLabel) => driver.FindElementByXpath($"//label[text()='{dropDownLabel}']//..//following-sibling::div//span[text()='{option}']");
        private IWebElement blankOptionDropdown(string dropDownLabel) => driver.FindElementByXpath($"//label[text()='{dropDownLabel}']//..//following-sibling::div//div[text() = '-- Select --']");

        private IWebElement entitlementInput => driver.FindElementByXpath("//label[text()='Entitlement']/../following-sibling::div//input");
        private IWebElement error(string name) => driver.FindElementByXpath($"//label[text() ='{name}']//..//following-sibling::div//following-sibling::span");


        // Methods
        public void ClickBtnLeave()
        {
            btnLeave.Click();
        }

        public void ClickBtnEntitlements()
        {
            btnEntitlements.Click();
        }

        public void ClickBtnAddEntitlements()
        {
            btnAddEntitlements.Click();
        }

        public void EnterEmployeeName(string name)
        {
            employeeNameInput.SendKeys(name);
        }

        public void SelectDropdown(string dropDownLabel)
        {
            dropdown(dropDownLabel).Click();
            Thread.Sleep(1000);
        }

        public void SelectBlankOptionOfDropdown(string dropDownLabel)
        {
            blankOptionDropdown(dropDownLabel).Click();
        }

        public void SelectNonBlankOptionOfDropdown(string option, string dropDownLabel)
        {
            nonBlankOptionOfDropdown(option,dropDownLabel).Click();
        }

        public void EnterEntitlement(string entitlement)
        {
            entitlementInput.SendKeys(entitlement);
        }

        public string GetErrorText(string name)
        {
            return error(name).Text;
        }

    }
}

