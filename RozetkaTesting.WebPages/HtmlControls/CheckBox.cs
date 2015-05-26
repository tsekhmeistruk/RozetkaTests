using System;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// Provides functionality of Checkbox control and methods for interaction with that.
    /// </summary>
    class Checkbox: BaseControl
    {
        #region Constructors

        /// <summary>
        /// The Constructor which uses 'By' locator.
        /// </summary>
        /// <param name="controlDescription"> checkbox locator.</param>
        public Checkbox(By controlDescription) : base(controlDescription)
        {
        }

        /// <summary>
        /// The Constructor which uses an object of IWebElement.
        /// </summary>
        /// <param name="webElement"> IWebElement of checkbox.</param>
        public Checkbox(IWebElement webElement) : base(webElement)
        {
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Find checkbox by locator.
        /// </summary>
        /// <param name="locator">Checkbox locator.</param>
        /// <returns>Checkbox control</returns>
        public static Checkbox ByLocator(By locator)
        {
            return new Checkbox(locator);
        }

        /// <summary>
        /// Gets checkbox by value of previous label.
        /// </summary>
        /// <param name="label">Label value.</param>
        /// <returns>CheckBox object.</returns>
        public static Checkbox ByLabel(string label)
        {
            return new Checkbox(By.XPath(String.Format("//label[*='{0}']/input[@type='checkbox']", label)));
        }

        /// <summary>
        /// Gets Checkbox by specific parameter Id and title which belongs to this checkbox.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static Checkbox ByIdAndTitle(string id, string title)
        {
            return new Checkbox(By.XPath(String.Format("//*[@id='{0}']/a//i[text()='{1}']/../..", id, title)));
        }

        #endregion

        #region Checkbox Functionality

        /// <summary>
        /// Returns true if the checkbox is checked.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return GetWebElement().Selected;
            }
        }

        /// <summary>
        /// Sets checkbox state to checked.
        /// </summary>
        public void Check()
        {
            Check(true);
        }

        /// <summary>
        /// Sets checkbox state to unchecked.
        /// </summary>
        public void Uncheck()
        {
            Check(false);
        }

        /// <summary>
        /// Sets checkbox state.
        /// </summary>
        /// <param name="select">Checkbox state.</param>
        public void Check(bool select)
        {
            if (IsSelected != select)
            {
                Click();
            }
        }

        #endregion
    }
}
