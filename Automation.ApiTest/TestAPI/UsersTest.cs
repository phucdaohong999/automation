using System.Net;
using Automation.ApiTest.Model;
using Automation.Core.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;

namespace Automation.ApiTest.TestAPI
{
    [TestClass]
    public class UsersTest : BaseTest
    {
        [TestMethod]
        public void Verify_List_Users()
        {
            // Test case 1: verify correct page number and data list is not empty

            // Step 1: Generate a random page number.
            var randomPage = new Random().Next(1, 3);

            // Step 2: Send a GET request to the users API for the random page.
            string getPath = JsonHelper.GetJsonValue<string>("getPath");
            var request = ApiHelper.GetUsers(getPath, randomPage);
            RestResponse response = client.Execute(request);

            // Step 3: Validate the response status and content.
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseData = JsonConvert.DeserializeObject<ListUsersModel>(response.Content);

            // Step 4: Verify the page number and ensure the data list is not empty.
            responseData.page.Should().Be(randomPage);
            responseData.data.Should().HaveCountGreaterThan(0);
        }

        [TestMethod]
        public void Verify_Create_User()
        {
            // Test case 2: create new user and verify server response
            // for new user matches the request data

            // Step 1: Prepare the request body with user details.
            var requestBody = new CreatedUserModel
            {
                name = "Alice",
                job = "Developer"
            };

            // Step 2: Create a POST request to the users API with the request body.
            string postPath = JsonHelper.GetJsonValue<string>("postPath");
            var request = ApiHelper.CreateUser(postPath, requestBody);

            // Step 3: Execute the request and capture the response.
            RestResponse response = client.Execute(request);

            // Step 4: Validate the response status and content.
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var responseData = JsonConvert.DeserializeObject<CreatedUserModel>(response.Content);

            // Step 5: Verify the name and job in the response match the request data.
            responseData.name.Should().Be(requestBody.name);
            responseData.job.Should().Be(requestBody.job);
        }
    }
}

