using System;
using System.Linq;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// Provides base methods for each control type.
    /// </summary>
    public abstract class BaseControl
    {
        #region Fields

        // Driver that is initialized and assigned in SpecFlowFeatureSteps.BeforeFeature().
        public static IDriver Driver;
        private readonly IWebElement _webElement;
        private readonly By _description;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that uses an element reference.
        /// </summary>
        /// <param name="controlDescription">The element reference.</param>
        protected BaseControl(By controlDescription)
        {
            if (controlDescription == null)
            {
                throw new ArgumentNullException("controlDescription",
                    @"Element reference for control base was not provided.");
            }
            _description = controlDescription;
        }

        /// <summary>
        /// Constructor that uses an IWebElement object to represent the element.
        /// </summary>
        /// <param name="webElement">The IWebElement object for the element.</param>
        protected BaseControl(IWebElement webElement)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement", @"Element reference for control base was not provided.");
            }
            _webElement = webElement;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets web element.
        /// </summary>
        /// <returns>The <see cref="IWebElement"/> object.</returns>
        public IWebElement GetWebElement()
        {
            return _webElement ?? GetWebElement(_description);
        }

        /// <summary>
        /// Gets web element.
        /// </summary>
        /// <param name="description">By locator.</param>
        /// <returns>The <see cref="IWebElement"/> object.</returns>
        public IWebElement GetWebElement(By description)
        {
            IWebElement webElement;
            if (!TryGetWebElement(description, out webElement))
            {
                throw new Exception(String.Format("Element {0} not found", _description));
            }
            return webElement;
        }

        /// <summary>
        /// Checks an element is on the Page.
        /// </summary>
        public bool Exists()
        {
            if (_webElement != null)
            {
                return true;
            }

            IWebElement webElement;
            return TryGetWebElement(out webElement);
        }

        /// <summary>
        /// Allows to perform click on element.
        /// </summary>
        public void Click()
        {
            IWebElement element = GetWebElement();
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Failed to click on {0} element. Error: {1}", _description, e));
            }
        }

        #endregion

        #region Private Methods

        private bool TryGetWebElement(By description, out IWebElement webElement)
        {
            webElement = Driver.FindElements(description).FirstOrDefault();
            if (webElement != null)
            {
                return true;
            }
            return false;
        }

        private bool TryGetWebElement(out IWebElement webElement)
        {
            webElement = _webElement;
            if (webElement != null)
            {
                return true;
            }
            else
            {
                return TryGetWebElement(_description, out webElement);
            }
        }

        #endregion
    }
}
