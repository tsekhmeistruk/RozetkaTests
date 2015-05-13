using System;
using RozetkaTesting.Framework;
using RozetkaTesting.Framework.SeleniumApiWrapper;

namespace RozetkaTesting.WebPages
{
    public abstract class PageBase
    {
        #region Protected Fields

        protected readonly Uri UriAbsolute;

        #endregion

        #region Constructor

        protected PageBase(string relativeUriPath)
        {
            UriAbsolute = new Uri(Settings.UrlBase + relativeUriPath);
        }

        #endregion

        #region Public Methods

        public void Open()
        {
            Browser.Navigate(UriAbsolute);
        }

        public string GetTitle()
        {
            return Browser.Title;
        }

        #endregion
    }
}
