using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RozetkaTesting.Framework.DataModels;

namespace RozetkaTesting.Framework.Helpers
{
    public static class JsonHelper
    {
        public static HashSet<T> Deserializer<T>(string path)
        {
            using (var stremReader = new StreamReader(path))
            {
                string jsonString = stremReader.ReadToEnd();
                var json = (JsonConvert.DeserializeObject<HashSet<T>>(jsonString));
                return json;
            }
        }

        public static HashSet<FirstLevelItem> GetMenuItems()
        {
            return Deserializer<FirstLevelItem>("../../../RozetkaTesting.PageObjectFramework/External/AllCatalogueItems.json");
        }
    }
}
