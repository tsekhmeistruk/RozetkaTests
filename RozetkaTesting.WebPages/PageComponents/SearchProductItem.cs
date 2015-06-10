using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages.PageComponents
{
    public class SearchProductItem
    {
        #region Private Fields

        private readonly int _index;
        private string _labelPriceXPath;
        private string _buttonBuyXPath;
        private string _linkTitle;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of SearchProductItem which uses index of item parameter.
        /// </summary>
        /// <param name="index">Index of the item in the list of items.</param>
        public SearchProductItem(int index)
        {
            _index = index;
            Initialize();
        }

        #endregion

        #region Controls

        private Label Label_Price()
        {
            return Label.ByXPath(_labelPriceXPath);
        }

        private Button Button_Buy()
        {
            return Button.ByXPath(_buttonBuyXPath);
        }

        private Link Link_Title()
        {
            return Link.ByLocator(By.XPath(_linkTitle));
        }

        #endregion

        #region SearchProductItem Functionality

        /// <summary>
        /// Add current product to the cart.
        /// </summary>
        public void AddToCart()
        {
            Button_Buy().Click();
        }

        /// <summary>
        /// Get price of product.
        /// </summary>
        /// <returns>Price of the product.</returns>
        public string GetPrice()
        {
            return Label_Price().GetText();
        }

        /// <summary>
        /// Gets the index of item.
        /// </summary>
        /// <returns>Number in order.</returns>
        public int GetIndex()
        {
            return _index;
        }

        /// <summary>
        /// Gets text of link.
        /// </summary>
        /// <returns>Text of link.</returns>
        public string GetProductTitle()
        {
            return Link_Title().GetText();
        }

        /// <summary>
        /// Opens current product item.
        /// </summary>
        public void OpenItem()
        {
            Link_Title().Click();
        }

        #endregion

        #region Privte Methods

        private void Initialize()
        {
            _labelPriceXPath = String.Format("(//div[@class='g-price-uah'])[{0}]", _index);
            _buttonBuyXPath =
                String.Format("(//div[@class='g-i-list available clearfix']//button[@class='btn-link-i'])[{0}]", _index);
            _linkTitle = String.Format("(//*[@class='g-i-list-title'])[{0}]/a", _index);
        }

        #endregion
    }
}
