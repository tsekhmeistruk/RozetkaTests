using System;
using OpenQA.Selenium;
using RozetkaTesting.Framework.Core;

namespace RozetkaTesting.WebPages
{
    /// <summary>
    /// Provides base functionality of Pages.
    /// </summary>
    public abstract class BasePage
    {
        #region Protected Fields

        protected readonly Driver Driver;
        protected string PageTitle;
        protected Uri PageUri;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes BasePage class.
        /// </summary>
        /// <param name="browser">Instance of <see cref="Driver"/> class.</param>
        protected BasePage(Driver browser)
        {
            Driver = browser;
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
        /// Opens page URL.
        /// </summary>
        public void Open()
        {
            Driver.Navigate(PageUri);
            Verify();
        }

        /// <summary>
        /// Gets the title of current page..
        /// </summary>
        /// <returns>Title text.</returns>
        public string GetTitle()
        {
            return Driver.Title;
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
        /// Initializes data.
        /// </summary>
        protected void InitializeData()
        {
            Initialize();
        }

        #endregion

        #region Private Methods

        private bool HasTitle()
        {
            return PageTitle == Driver.Title;
        }

        #endregion
    }
}
