using System.Configuration;

namespace TestFrameworkLibrary.Services
{
    public static class AppSettingService
    {
        public static string GetSettingValue(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}
