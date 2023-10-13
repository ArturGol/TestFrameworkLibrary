using Newtonsoft.Json;
using System;
using System.IO;

namespace TestFrameworkLibrary
{
    public class DataHandler
    {
        public static T ParseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }

        public static string GetFilePath(string name)
        {
            return $"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory))}\\TestData\\{name}";
        }
    }
}
