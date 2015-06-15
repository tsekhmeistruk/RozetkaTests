using System;

namespace RozetkaTesting.WebPages.Helpers
{
    public static class UrlBuilder
    {
        private const string HttpProtocol = "http://";
        private const string HttpsProtocol = "https://";
        private const string BaseUrl = "rozetka.com.ua";

        public static Uri Get(string prefix, string suffix, bool isHttps)
        {
            string protocol = isHttps ? HttpsProtocol : HttpProtocol;
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = "";
            }
            else
            {
                prefix += ".";
            }

            if (string.IsNullOrEmpty(suffix))
            {
                suffix = String.Empty;
            }

            return new Uri(protocol + prefix  + BaseUrl + "/" + suffix);
        }
    }
}
