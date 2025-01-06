using Automation.Core.Helpers;
using RestSharp;

namespace Automation.ApiTest.TestAPI
{
	[TestClass]
	public class BaseTest
	{
		protected RestClient client;
        [TestInitialize]
		public void SetupRestClient()
		{
            client = new RestClient(ConfigurationHelper.GetValue<string>("urlforreqresin"));
        }
    }
}

