using System;
using System.Collections.Generic;
using RozetkaTesting.Framework.Core;

namespace RozetkaTesting.Framework.Helpers
{
    public static class ConfigHelper
    {
        /// <summary>
        /// Gets name of browser.
        /// </summary>
        /// <returns>Browser name.</returns>
        public static string GetBrowserName()
        {
            return GetValueFromConfig(ConfigKey.Type);
        }

        /// <summary>
        /// Gets default waiting time.
        /// </summary>
        /// <returns>The value of default waiting time.</returns>
        public static string GetDefaultWaitTime()
        {
            return GetValueFromConfig(ConfigKey.DefaultWait);
        }

        /// <summary>
        /// Gets implicit waiting time.
        /// </summary>
        /// <returns>The value of implicit waiting time.</returns>
        public static string GetImplicitWaitTime()
        {
            return GetValueFromConfig(ConfigKey.ImplicitWait);
        }

        private static string GetValueFromConfig(ConfigKey configProperty)
        {
            Dictionary<string, string> config =
                JsonHelper.Deserialize("../../../RozetkaTesting.PageObjectFramework/External/DriverConfig.json");

            string value;
            string key;

            switch (configProperty)
            {
                case ConfigKey.Type:
                    key = "type";
                    break;

                case ConfigKey.DefaultWait:
                    key = "default-wait";
                    break;

                case ConfigKey.ImplicitWait:
                    key = "implicit-wait";
                    break;

                default:
                    key = String.Empty;
                    break;
            }

            config.TryGetValue(key, out value);
            return value;
        }
    }
}
