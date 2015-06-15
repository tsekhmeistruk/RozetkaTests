using System;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.Helpers;

namespace RozetkaTesting.WebPages
{
    /// <summary>
    /// Provides base functionality of Pages.
    /// </summary>
    public abstract class BasePage
    {
        #region Protected Fields

        protected readonly IDriver Driver;
        protected string PageTitle;
        protected Uri PageUri;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes BasePage class.
        /// </summary>
        /// <param name="driver">Implementation of <see cref="IDriver"/>.</param>
        protected BasePage(IDriver driver)
        {
            Driver = driver;
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
            Driver.WaitForPageLoaded();
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
        /// Checks for login.
        /// </summary>
        /// <returns>True if user is sign in.</returns>
        public bool IsLogin()
        {
            return (Driver.FindElements(By.Id("header_user_menu")).Count == 1);
        }

        /// <summary>
        /// Logout from the site.
        /// </summary>
        public void LogOut()
        {
            Driver.Navigate(UrlBuilder.Get("my", "signout", false));
        }

        /// <summary>
        /// Verifies page.
        /// </summary>
        public virtual void Verify()
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
