using System;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.Attributes;
using RozetkaTesting.WebPages.Helpers;

namespace RozetkaTesting.WebPages
{
    [Page("Main")]
    public class MainPage: BasePage
    {
        #region Page Component

        private readonly IHeaderComponent _header;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes new instance of the <see cref="MainPage"/> class.
        /// </summary>
        /// <param name="driver">Implementation of <see cref="IDriver"/>.</param>
        /// <param name="header">The component of the header.</param>
        public MainPage(IDriver driver, IHeaderComponent header) : base(driver)
        {
            _header = header;
        }

        #endregion

        #region Header Functionality

        /// <summary>
        /// Opens cart as pop-up window.
        /// </summary>
        public void OpenCart()
        {
            _header.OpenCart();
        }

        /// <summary>
        /// Clear input and enter the search phrase into search field.
        /// </summary>
        /// <param name="searchPhrase">The word or phrase for searching.</param>
        public void EnterSearchPhrase(string searchPhrase)
        {
            _header.InputSearchPhrase(searchPhrase);
        }

        /// <summary>
        /// Submits search.
        /// </summary>
        public void SubmitSearch()
        {
            _header.Search();
        }

        #endregion

        #region Override Methods

        protected override void Initialize()
        {
            PageTitle =
                "Интернет-магазин ROZETKA™: фототехника, видеотехника, аудиотехника, компьютеры и компьютерные комплектующие";

            PageUri = UrlBuilder.Get("", "", false);
        }

        #endregion
    }
}
