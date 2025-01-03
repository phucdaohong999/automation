using Newtonsoft.Json;

namespace Automation.Core.Helpers
{
    public class JsonHelper
	{

        public static T GetJsonValue<T>(string key)
        {
            string filePath = ConfigurationHelper.GetValue<string>("testdatajsonfilepath");
            string fileContent = File.ReadAllText(filePath);

            var jsonData = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileContent);

            // Get value by key
            if (jsonData.TryGetValue(key, out string value))
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            else
            {
                return default(T);
            }
        }

    }
}

