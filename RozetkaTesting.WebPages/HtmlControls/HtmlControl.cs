using System;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// Represents generic control where exact type is not known or relevant.
    /// </summary>
    class HtmlControl: BaseControl
    {
        #region Constructors

        /// <summary>
        /// The Constructor which uses 'By' locator.
        /// </summary>
        /// <param name="controlDescription">element locator.</param>
        public HtmlControl(By controlDescription) : base(controlDescription)
        {
        }

        /// <summary>
        /// The Constructor which uses an object of IWebElement.
        /// </summary>
        /// <param name="webElement">IWebElement of control.</param>
        public HtmlControl(IWebElement webElement) : base(webElement)
        {
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Finds an element by text.
        /// </summary>
        /// <param name="controlText">Text value to search element.</param>
        /// <returns>Html control by specific text.</returns>
        public static HtmlControl ByText(string controlText)
        {
            return new HtmlControl(By.XPath(String.Format("//*[text()='{0}']", controlText)));
        }

        /// <summary>
        /// Gets an Html control by locator.
        /// </summary>
        /// <param name="locator">Html control locator</param>
        /// <returns>Html control.</returns>
        public static HtmlControl ByLocator(By locator)
        {
            return new HtmlControl(locator);
        }

        #endregion
    }
}
