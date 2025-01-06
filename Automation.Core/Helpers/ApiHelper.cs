using RestSharp;
namespace Automation.Core.Helpers

{
    public static class ApiHelper
    {
        // Method for GET request
        public static RestRequest GetUsers(string getPath, int page)
        {
            var request = new RestRequest($"{getPath}{page}", Method.Get);
            return request;
        }

        // Method for POST request
        public static RestRequest CreateUser(string postPath, object requestBody)
        {
            var request = new RestRequest($"{postPath}", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(requestBody);
            return request;
        }
    }
}


