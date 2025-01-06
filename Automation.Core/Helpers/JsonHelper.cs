using System.ComponentModel.Design.Serialization;
using Newtonsoft.Json;

namespace Automation.Core.Helpers
{
    public class JsonHelper
    {

        public static T GetJsonValue<T>(string key)
        {
            // Determine the project directory
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = new DirectoryInfo(currentDirectory)?.Parent?.Parent?.Parent?.FullName;

            // Construct the full file path
            string relativePath = ConfigurationHelper.GetValue<string>("testdatajsonfilepath");
            string filePath = Path.Combine(projectDirectory, relativePath);

            // Read and deserialize the JSON file
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

