using System;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// Provides functionality of TextField control and methods for interaction with that.
    /// </summary>
    class TextField: BaseControl
    {
        #region Constructors

        /// <summary>
        /// The Constructor which uses 'By' locator.
        /// </summary>
        /// <param name="controlDescription">TextField locator.</param>
        public TextField(By controlDescription)
            : base(controlDescription)
        {
        }

        /// <summary>
        /// The Constructor which uses an object of IWebElement.
        /// </summary>
        /// <param name="webElement">IWebElement of TextField.</param>
        public TextField(IWebElement webElement)
            : base(webElement)
        {
        } 

        #endregion

        #region Static Methods

        /// <summary>
        /// Gets text field by locator.
        /// </summary>
        /// <param name="locator">TextField locator.</param>
        /// <returns>TextField control.</returns>
        public static TextField ByLocator(By locator)
        {
            return new TextField(locator);
        }

        /// <summary>
        /// Gets TextField by Id.
        /// </summary>
        /// <param name="id">The Id of TextField.</param>
        /// <returns>TextField control.</returns>
        public static TextField ById(string id)
        {
            return new TextField(By.XPath(String.Format("//input[@id='{0}']", id)));
        }

        /// <summary>
        /// Gets text value.
        /// </summary>
        public string GetValue()
        {
            return GetWebElement().GetAttribute("value");
        }

        #endregion

        #region TextField Functionality

        /// <summary>
        /// Clears TextField and type specific value.
        /// </summary>
        /// <param name="value">The text for typing.</param>
        public void ClearAndType(string value)
        {
            IWebElement textFieldElement = GetWebElement();
            textFieldElement.Clear();
            textFieldElement.SendKeys(value);
        }

        #endregion
    }
}
