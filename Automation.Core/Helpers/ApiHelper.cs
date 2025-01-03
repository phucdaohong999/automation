using RestSharp;
namespace Automation.Core.Helpers

{
    public static class ApiHelper
    {
        private static RestClient client;

        // Method for GET request
        public static RestRequest GetUsers(int page)
        {
            var request = new RestRequest($"/api/users?page={page}", Method.Get);
            return request;
        }

        // Method for POST request
        public static RestRequest CreateUser(object requestBody)
        {
            var request = new RestRequest($"/api/users", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(requestBody);
            return request;
        }
    }
}


