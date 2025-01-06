using Automation.Core.Helpers;
using FluentAssert;
using PhucDH4_MockProject.Pages;

namespace PhucDH4_MockProject.Tests.TestPagePracticetestautomationcom
{
    [TestClass]
    public class NegativeUsernameTest : BaseTest
    {
        private LoginPage loginPage;

        public override void SetUpPageObjects()
        {
            loginPage = new LoginPage(driver);
        }

        [TestMethod("Test case 2: Negative username test")]
        public void Verify_Negative_Username()
        {
            // Step 1: Open page
            string url = ConfigurationHelper.GetValue<string>("urlforpracticetestautomationcom");
            loginPage.GoToLogin(url);

            // Step 2: Type username incorrectUser into Username field with correct password
            string wrongUsername = ConfigurationHelper.GetValue<string>("wrongusernameforragepracticetestautomationcom"); ;
            string password = ConfigurationHelper.GetValue<string>("passwordforragepracticetestautomationcom"); ;
            loginPage.EnterUsernameAndPassword(wrongUsername, password);

            // Step 3: Push Submit button
            loginPage.ClickSubmitButton();

            // Step 4: Verify error message is displayed
            bool isErrorMessageDisplay = loginPage.VerifyErrorMessageExist();
            isErrorMessageDisplay.ShouldBeTrue();

            // Step 5: Verify error message text is Your username is invalid!
            bool isCorrectErrorMessage = loginPage.VerifyCorrectErrorMessage("Your username is invalid!");
            isCorrectErrorMessage.ShouldBeTrue();
        }
    }
}

