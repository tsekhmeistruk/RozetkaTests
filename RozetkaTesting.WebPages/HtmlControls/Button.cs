using System;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// Provides functionality of Button control and methods for interaction with that.
    /// </summary>
    class Button: BaseControl
    {
        #region Constructors

        /// <summary>
        /// The Constructor which uses 'By' locator.
        /// </summary>
        /// <param name="controlDescription"> button locator.</param>
        public Button(By controlDescription) : base(controlDescription)
        {
        }

        /// <summary>
        /// The Constructor which uses an object of IWebElement.
        /// </summary>
        /// <param name="webElement"> IWebElement of button.</param>
        public Button(IWebElement webElement) : base(webElement)
        {
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Gets a Button by Text.
        /// </summary>
        /// <param name="text">The text of button.</param>
        /// <returns>The Button control.</returns>
        public static Button ByText(string text)
        {
            return new Button(By.XPath(String.Format("//button[text()='{0}']", text)));
        }

        /// <summary>
        /// Gets a Button by Id.
        /// </summary>
        /// <param name="id">The Id of the button.</param>
        /// <returns>The Button control.</returns>
        public static Button ById(string id)
        {
            return new Button(By.CssSelector(String.Format("button#{0}", id)));
        }

        #endregion
    }
}
