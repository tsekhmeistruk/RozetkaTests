using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RozetkaTesting.Framework.Helpers
{
    public static class JsonHelper
    {
        public static Dictionary<string, string> Deserialize(string path)
        {
            using (var stremReader = new StreamReader(path))
            {
                string jsonString = stremReader.ReadToEnd();
                var json = (JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString));
                return json;
            }
        }
    }
}
