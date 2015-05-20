using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RozetkaTesting.Framework.SeleniumApiWrapper;

namespace RozetkaTesting.WebPages
{
    public abstract class PageBase
    {
        #region Protected Fields

        protected readonly Uri PageUri;
        protected readonly Browser Browser;

        #endregion

        #region Constructor

        protected PageBase(Uri pageUri, Browser browser)
        {
            Browser = browser;
            PageUri = pageUri;
            PageFactory.InitElements(Browser, this);
        }

        #endregion

        #region Public and Protected Methods

        /// <summary>
        /// Open URL.
        /// </summary>
        public void Open()
        {
            Browser.Navigate(PageUri);
        }

        /// <summary>
        /// Get the title.
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
    }
}
