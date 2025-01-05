using System.ComponentModel.Design.Serialization;
using Newtonsoft.Json;

namespace Automation.Core.Helpers
{
    public class JsonHelper
    {

        public static T GetJsonValue<T>(string key)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = new DirectoryInfo(currentDirectory)?.Parent?.Parent?.Parent?.FullName;
            string relativePath = ConfigurationHelper.GetValue<string>("testdatajsonfilepath");
            string filePath = Path.Combine(projectDirectory, relativePath);

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

