using System;
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

        #endregion

        #region Constructor

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

        private void Initialize()
        {
            _labelPriceXPath = String.Format("(//div[@class='g-price-uah'])[{0}]", _index);
            _buttonBuyXPath = String.Format("(//button[@name='topurchasesfromcatalog'])[{0}]", _index);
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

        #endregion
    }
}
