using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RozetkaTesting.Framework.Core;

namespace RozetkaTesting.WebPages
{
    /// <summary>
    /// Provides base functionality of Pages.
    /// </summary>
    public abstract class BasePage
    {
        #region Protected Fields

        protected readonly Driver Browser;
        protected string PageTitle;
        protected Uri PageUri;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes BasePage class.
        /// </summary>
        /// <param name="browser">Instance of <see cref="Browser"/> class.</param>
        protected BasePage(Driver browser)
        {
            Browser = browser;
            PageFactory.InitElements(Browser, this);
            InitializeData();
        }

        #endregion

        #region Abstaract Methods

        /// <summary>
        /// Initializes all necessary members such as: URL, Title etc.
        /// </summary>
        protected abstract void Initialize();

        #endregion

        #region Public and Protected Methods

        /// <summary>
        /// Initializes data.
        /// </summary>
        public void InitializeData()
        {
            Initialize();
        }

        /// <summary>
        /// Opens page URL.
        /// </summary>
        public void Open()
        {
            Browser.Navigate(PageUri);
            Verify();
        }

        /// <summary>
        /// Verifies page.
        /// </summary>
        protected virtual void Verify()
        {
            if (!HasTitle())
            {
                throw new NoSuchElementException( "Current page is not valid or Title has been changed." );
            }
        } 

        /// <summary>
        /// Gets the title of current page..
        /// </summary>
        /// <returns>Title text.</returns>
        public string GetTitle()
        {
            return Browser.Title;
        }

        /// <summary>
        /// Sends keys to the input element on the page.
        /// </summary>
        /// <param name="input">The input element.</param>
        /// <param name="value">The value.</param>
        protected void SendKeys(IWebElement input, string value)
        {
            input.Clear();
            input.SendKeys(value);
        }

        #endregion

        #region Private Methods

        private bool HasTitle()
        {
            return PageTitle == Browser.Title;
        }

        #endregion
    }
}
