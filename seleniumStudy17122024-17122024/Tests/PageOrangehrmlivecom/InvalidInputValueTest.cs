using Automation.Core.Helpers;
using PhucDH4_MockProject.Pages;

namespace PhucDH4_MockProject.Tests.TestPageOrangehrmlivecom
{
    [TestClass]
    public class InvalidInputValueTest : BaseTest
    {
        private LoginPage loginPage;
        private AddEntitlementsPage addEntitlementPage;

        public override void SetUpPageObjects()
        {
            loginPage = new LoginPage(driver);
            addEntitlementPage = new AddEntitlementsPage(driver);
        }

        [TestMethod("Test case 1: verify error messages show when enter invalid values in all dropdowns and inputs")]
        public void VerifyErrorMessage()
        {
            // Step 1: Go to login page
            string url = ConfigurationHelper.GetValue<string>("urlfororangehrmlivecom");
            loginPage.GoToLogin(url);

            // Step 2: Type username and password
            string username = ConfigurationHelper.GetValue<string>("username");
            string password = ConfigurationHelper.GetValue<string>("password");
            loginPage.EnterUsernameAndPassword(username, password);

            // Step 3: Push Submit button
            loginPage.ClickLoginButton();

            // Step 4: Navigate to Add Entitlements page
            addEntitlementPage.ClickBtnLeave();
            addEntitlementPage.ClickBtnEntitlements();
            addEntitlementPage.ClickBtnAddEntitlements();

            // Step 5: Enter Employee name
            addEntitlementPage.EnterEmployeeName("bard");

            // Step 6: Open Leave type Dropdown
            string leaveTypeLabel = JsonHelper.GetJsonValue<string>("leaveTypeLabel");
            addEntitlementPage.SelectDropdown(leaveTypeLabel);

            // Step 7: Select CAS Option Of Leave type Dropdown
            string dropdownOption = JsonHelper.GetJsonValue<string>("dropdownUSMatternityOption");
            addEntitlementPage.SelectNonBlankOptionOfDropdown(dropdownOption, leaveTypeLabel);

            // Step 8: Open Leave type Dropdown
            addEntitlementPage.SelectDropdown(leaveTypeLabel);

            // Step 9: Select Blank Option Of Leave type Dropdown
            addEntitlementPage.SelectBlankOptionOfDropdown(leaveTypeLabel);

            // Step 10: Open Leave Period Dropdown
            string leavePeriodLabel = JsonHelper.GetJsonValue<string>("leavePeriodLabel");
            addEntitlementPage.SelectDropdown(leavePeriodLabel);

            // Step 11: Select Blank Option Of Leave Period Dropdown
            addEntitlementPage.SelectBlankOptionOfDropdown(leavePeriodLabel);

            // Step 12: Enter Entitlement
            addEntitlementPage.EnterEntitlement("aa");

            // Step 13: Verify error messages are showing

            string employeeNameLabel = JsonHelper.GetJsonValue<string>("employeeNameLabel");
            string entitlementLabel = JsonHelper.GetJsonValue<string>("entitlementLabel");
            string invalidErrorMessage = JsonHelper.GetJsonValue<string>("invalidErrorMessage");
            string requiredErrorMessage = JsonHelper.GetJsonValue<string>("requiredErrorMessage");
            string entitlementErrorMessage = JsonHelper.GetJsonValue<string>("entitlementErrorMessage");

            string employeeNameError = addEntitlementPage.GetErrorText(employeeNameLabel);
            string leaveTypeError = addEntitlementPage.GetErrorText(leaveTypeLabel);
            string leavePeriodError = addEntitlementPage.GetErrorText(leavePeriodLabel);
            string entitlementError = addEntitlementPage.GetErrorText(entitlementLabel);

            Assert.AreEqual(employeeNameError, invalidErrorMessage);
            Assert.AreEqual(leaveTypeError, requiredErrorMessage);
            Assert.AreEqual(leavePeriodError, requiredErrorMessage);
            Assert.AreEqual(entitlementError, entitlementErrorMessage);
        }
    }
}
