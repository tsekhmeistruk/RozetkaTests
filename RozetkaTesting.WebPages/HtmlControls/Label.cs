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

        /// <summary>
        /// Gets Label by XPath locator.
        /// </summary>
        /// <param name="locator">Label XPAth locator.</param>
        /// <returns>Label object.</returns>
        public static Label ByXPath(string locator)
        {
            return new Label(By.XPath(locator));
        }

        /// <summary>
        /// Gets Label by CSS selector.
        /// </summary>
        /// <param name="locator">CSS selector.</param>
        /// <returns>Label object.</returns>
        public static Label ByCss(string locator)
        {
            return new Label(By.CssSelector(locator));
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

        #endregion
    }
}
