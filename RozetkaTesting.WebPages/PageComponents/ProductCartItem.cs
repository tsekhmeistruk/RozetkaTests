using System;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages.PageComponents
{
    public class ProductCartItem
    {
        #region Private Fields

        private readonly int _index;
        private string _labelPriceXpath;
        private string _linkRemoveItem;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of ProductCartItem class.
        /// </summary>
        /// <param name="index"></param>
        public ProductCartItem(int index)
        {
            _index = index;
            Initialize();
        }

        #endregion

        #region Controls

        private Label Label_Price()
        {
            return Label.ByXPath(_labelPriceXpath);
        }

        private Link Link_RemoveItem()
        {
            return Link.ByXpath(_linkRemoveItem);
        }

        #endregion

        #region ProductCartItem Functionality

        /// <summary>
        /// Remove current product from the cart.
        /// </summary>
        public void RemoveCurrentItem()
        {
            Link_RemoveItem().Click();
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            _labelPriceXpath = String.Format("( //*[@class='cart-uah cart-sum-uah']/span[@name='sum'])[{0}]", _index);
            _linkRemoveItem = String.Format("(//*[@name='delete'])[{0}]", _index);
        }

        #endregion
    }
}
