using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// Provides functionality of Label control and methods for interaction with that.
    /// </summary>
    class Label: BaseControl
    {
        #region Constructors

        /// <summary>
        /// The Constructor which uses 'By' locator.
        /// </summary>
        /// <param name="controlDescription">Label locator.</param>
        public Label(By controlDescription) : base(controlDescription)
        {
        }

        /// <summary>
        /// The Constructor which uses an object of IWebElement.
        /// </summary>
        /// <param name="webElement">IWebElement of Label.</param>
        public Label(IWebElement webElement) : base(webElement)
        {
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Gets Label by locator.
        /// </summary>
        /// <param name="locator">Label locator.</param>
        /// <returns>Label object.</returns>
        public static Label ByLocator(By locator)
        {
            return new Label(locator);
        }

        #endregion

        #region Label Functionality

        /// <summary>
        /// Get Label text.
        /// </summary>
        /// <returns>Text of the current Label element.</returns>
        public string GetText()
        {
            return GetWebElement().Text;
        }

        /// <summary>
        /// Gets text of labels.
        /// </summary>
        /// <returns>The list of Labels text.</returns>
        public List<string> GetTexts()
        {
            return GetWebElements().Select(webElement => Regex.Replace(webElement.Text, @"[^\d]", "")).ToList();
        }

        #endregion
    }
}
