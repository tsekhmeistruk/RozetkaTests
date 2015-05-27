using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// Provides functionality of RadioButton control and methods for interaction with that.
    /// </summary>
    class RadioButton: BaseControl
    {
        #region Constructors

        /// <summary>
        /// The Constructor which uses 'By' locator.
        /// </summary>
        /// <param name="controlDescription">RadioButton locator.</param>
        public RadioButton(By controlDescription)
            : base(controlDescription)
        {
        }

        /// <summary>
        /// The Constructor which uses an object of IWebElement.
        /// </summary>
        /// <param name="webElement">IWebElement of RadioButton.</param>
        public RadioButton(IWebElement webElement)
            : base(webElement)
        {
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Gets a RadioButton using a locator.
        /// </summary>
        /// <param name="locator">RadioButton locator.</param>
        /// <returns>Radio Button Object.</returns>
        public static RadioButton ByLocator(By locator)
        {
            return new RadioButton(locator);
        } 

        #endregion
    }
}
