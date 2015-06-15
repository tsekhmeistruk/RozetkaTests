using System;

namespace RozetkaTesting.WebPages.Attributes
{
    /// <summary>
    /// Used to define Page Object and provide a way to lookup pages by name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class PageAttribute : Attribute
    {
        /// <summary>
        /// Used to define Page Object and provide a way to lookup pages by name.
        /// </summary>
        /// <param name="pageName">A natural name being represented by the Page Object</param>
        public PageAttribute(string pageName)
        {
            PageName = pageName;
        }

        /// <summary>
        /// Gets a name representing by the Page Object.
        /// </summary>
        public string PageName { get; private set; }
    }
}

