using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages.PageComponents
{
    public class HeaderComponent: IHeaderComponent
    {
        #region Private Fields

        private string _inputSearch;
        private string _buttonSearch;
        private string _linkTextCart;

        #endregion

        #region Constructor

        public HeaderComponent()
        {
            Initialize();
        }

        #endregion

        #region Controls

        private Link Link_Cart()
        {
            return Link.ByText(_linkTextCart);
        }

        private TextField Input_Search()
        {
            return TextField.ByLocator(By.XPath(_inputSearch));
        }

        private Button Button_Search()
        {
            return Button.ByXPath(_buttonSearch);
        }

        #endregion

        #region IHeaderComponent Implementation

        /// <summary>
        /// Opens cart as pop-up window.
        /// </summary>
        public void OpenCart()
        {
            Link_Cart().Click();
        }

        /// <summary>
        /// Clear and type search phrase into search field.
        /// </summary>
        /// <param name="searchPhrase"></param>
        public void InputSearchPhrase(string searchPhrase)
        {
            Input_Search().ClearAndType(searchPhrase);
        }

        /// <summary>
        /// Submits searching.
        /// </summary>
        public void Search()
        {
            Button_Search().Click();
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            _linkTextCart = "Корзина";
            _inputSearch = "//input[@class='header-search-input-text passive']";
            _buttonSearch = "//button[@class='btn-link-i'][text()='Найти']";
        }

        #endregion
    }
}
