using Automation.Core.Helpers;
using FluentAssert;
using PhucDH4_MockProject.Pages;

namespace PhucDH4_MockProject.Tests.TestPagePracticetestautomationcom
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private LoginSuccessPage loginSuccessPage;

        public override void SetUpPageObjects()
        {
            loginPage = new LoginPage(driver);
            loginSuccessPage = new LoginSuccessPage(driver);
        }

        [TestMethod("Test case 1: Log In test with correct username and password")]
        public void Verify_Positive_LoginTest()
        {
            // Step 1: Open page
            string url = ConfigurationHelper.GetValue<string>("urlforpracticetestautomationcom");
            loginPage.GoToLogin(url);

            // Step 2: Enter username and password
            string username = ConfigurationHelper.GetValue<string>("usernameforragepracticetestautomationcom");
            string password = ConfigurationHelper.GetValue<string>("passwordforragepracticetestautomationcom");
            loginPage.EnterUsernameAndPassword(username, password);

            // Step 3: Push Submit button
            loginPage.ClickSubmitButton();

            // Step 4: Verify new page URL contains practicetestautomation.com / logged -in-successfully /
            driver.Url.ShouldContain("practicetestautomation.com/logged-in-successfully/");

            // Step 5: Verify new page contains expected text('Congratulations' or 'successfully logged in')
            bool loginSuccessMessage = loginSuccessPage.VerifyLoggedInMessage("Logged In Successfully");
            loginSuccessMessage.ShouldBeTrue();

            // Step 6: Verify button Log out is displayed on the new page
            bool isLogoutButtonDisplay = loginSuccessPage.VerifyLogOutButtonExist();
            isLogoutButtonDisplay.ShouldBeTrue();
            
        }
    }
}

