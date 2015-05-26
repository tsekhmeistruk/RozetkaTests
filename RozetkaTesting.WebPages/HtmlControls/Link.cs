using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// Provides functionality of Link control and methods for interaction with that.
    /// </summary>
    class Link: BaseControl
    {
        #region Constructors

        /// <summary>
        /// The Constructor which uses 'By' locator.
        /// </summary>
        /// <param name="controlDescription"> link locator.</param>
        public Link(By controlDescription) : base(controlDescription)
        {
        }

        /// <summary>
        /// The Constructor which uses an object of IWebElement.
        /// </summary>
        /// <param name="webElement"> IWebElement of link.</param>
        public Link(IWebElement webElement) : base(webElement)
        {
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Get link by id.
        /// </summary>
        /// <param name="id">Link id.</param>
        /// <returns>Link control.</returns>
        public static Link ById(string id)
        {
            return new Link(By.CssSelector("a#" + id));
        }

        /// <summary>
        /// Gets a link by locator.
        /// </summary>
        /// <param name="locator">Link locator.</param>
        /// <returns>Link control.</returns>
        public static Link ByLocator(By locator)
        {
            return new Link(locator);
        }

        /// <summary>
        /// Gets a link by partial text.
        /// </summary>
        /// <param name="text">Partial text of link.</param>
        /// <returns>Link control.</returns>
        public static Link ByPartialText(string text)
        {
            return new Link(By.PartialLinkText(text));
        }

        /// <summary>
        /// Gets a link by text.
        /// </summary>
        /// <param name="text">Link text.</param>
        /// <returns>Link control.</returns>
        public static Link ByText(string text)
        {
            return new Link(By.LinkText(text));
        }

        #endregion
    }
}
