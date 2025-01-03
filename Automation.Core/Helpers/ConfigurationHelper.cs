using System.Configuration;
using Newtonsoft.Json;

namespace Automation.Core.Helpers
{
    public static class ConfigurationHelper
    {
        public static T GetValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value is null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

    }
}

