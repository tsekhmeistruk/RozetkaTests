using System;
using OpenQA.Selenium;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages.PageComponents
{
    public class ProductItem
    {
        #region Private Fields

        //Number of item(product) on the Result Page.
        private readonly int _index;

        private string _labelPriceXPath;
        private string _buttonBuyXPath;
        private string _linkTitle;
        private string _linkWishList;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of ProductItem which uses index of item parameter.
        /// </summary>
        /// <param name="index"></param>
        public ProductItem(int index)
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

        #region Product Item Functionality

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

        #endregion

        #region Private Methods

        protected void Initialize()
        {
            _labelPriceXPath = String.Format("(//div[@name='goods_list']//button[@name='topurchasesfromcatalog']//..//..//..//..//..//..//..//div[@name='prices_active_element_original']//div[@class='g-price-uah'])[{0}]", _index);
            _buttonBuyXPath = String.Format("(//div[@name='goods_list']//button[@name='topurchasesfromcatalog'])[{0}]", _index);
            _linkTitle = String.Format("(//div[@name='goods_list']//div[@class='g-i-tile-i-title clearfix']/a)[{0}]", _index);
            _linkWishList = String.Format("(//div[@name='goods_list']//*[@class='g-wishlist'])[{0}]", _index);
        }

        #endregion
    }
}
