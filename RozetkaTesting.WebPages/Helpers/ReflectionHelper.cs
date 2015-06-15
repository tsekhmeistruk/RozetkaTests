using System;
using System.Linq;
using System.Reflection;
using RozetkaTesting.WebPages.Attributes;

namespace RozetkaTesting.WebPages.Helpers
{
    public static class ReflectionHelper
    {
        private static readonly Assembly WebPagesAssembly = Assembly.GetExecutingAssembly();

        /// <summary>
        /// Returns name of a page by its type
        /// </summary>
        public static string[] GetPageNames<T>(this T page) where T : BasePage
        {
            return GetPageNames(page.GetType());
        }

        /// <summary>
        /// Returns Type of a page class by its name if it exists
        /// </summary>
        /// <param name="pageName">The name of page.</param>
        /// <param name="pageType">The type of page.</param>
        /// <returns>True if page is founded.</returns>
        private static bool TryGetPageType(string pageName, out Type pageType)
        {
            pageType = WebPagesAssembly.GetTypes().FirstOrDefault(type => GetPageNames(type).Contains(pageName));
            return pageType != null;
        }

        /// <summary>
        /// Returns Type of a page class by its name
        /// </summary>
        /// <param name="pageName">Page Name</param>
        /// <returns>The Type of the page.</returns>
        public static Type GetPageType(string pageName)
        {
            Type pageType;
            if (TryGetPageType(pageName, out pageType))
            {
                return pageType;
            }

            throw new Exception(pageName);
        }

        private static string[] GetPageNames(Type type)
        {
            return Attribute.GetCustomAttributes(type, typeof(PageAttribute)).Select(e => ((PageAttribute)e).PageName).ToArray();
        }
    }
}
