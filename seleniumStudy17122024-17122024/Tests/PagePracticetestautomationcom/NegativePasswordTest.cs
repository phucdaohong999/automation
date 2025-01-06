using Automation.Core.Helpers;
using FluentAssert;
using PhucDH4_MockProject.Pages;

namespace PhucDH4_MockProject.Tests.TestPagePracticetestautomationcom
{
    [TestClass]
    public class NegativePasswordTest : BaseTest
    {
        private LoginPage loginPage;

        public override void SetUpPageObjects()
        {
            loginPage = new LoginPage(driver);
        }

        [TestMethod("Test case 3: Test login with wrong password")]
        public void Verify_Negative_Password()
        {
            // Step 1: Open page
            string url = ConfigurationHelper.GetValue<string>("urlforpracticetestautomationcom");
            loginPage.GoToLogin(url);

            // Step 2: Enter correct username and incorrect password
            string username = ConfigurationHelper.GetValue<string>("usernameforragepracticetestautomationcom");

            string wrongPassword = ConfigurationHelper.GetValue<string>("wrongpasswordforragepracticetestautomationcom");
            string password = wrongPassword + new Random().Next(1000, 9999 + 1);
            loginPage.EnterUsernameAndPassword(username, password);

            // Step 3: Push Submit button
            loginPage.ClickSubmitButton();

            // Step 4: Verify error message is displayed
            bool isErrorMessageDisplay = loginPage.VerifyErrorMessageExist();
            isErrorMessageDisplay.ShouldBeTrue();

            // Step 5: Verify error message text is Your password is invalid!
            bool isCorrectErrorMessage = loginPage.VerifyCorrectErrorMessage("Your password is invalid!");
            isCorrectErrorMessage.ShouldBeTrue();
        }
    }
}

