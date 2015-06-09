using System.Text.RegularExpressions;

namespace RozetkaTesting.WebPages.Helpers
{
    public static class Parser
    {
        /// <summary>
        /// Parse String value to Int32 value.
        /// </summary>
        /// <param name="rawValue"></param>
        /// <returns>The Value in Int32 format.</returns>
        public static int ParseInt(string rawValue)
        {
            return int.Parse(Regex.Replace(rawValue, @"[^\d]", ""));
        }
    }
}
