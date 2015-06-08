using System;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages
{
    public class CartPage : BasePage
    {
        #region Private Fields

        private string _cartItemsXpath;
        private string _labelEmptyCartXpath;
        private string _emptyCart;

        #endregion

        #region CartPage Functionality

        /// <summary>
        /// Gets the number of products in the Cart.
        /// </summary>
        /// <returns>Number of products.</returns>
        public int GetCount()
        {
            return GetCartItemsCount();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the new instance of the CartPage class.
        /// </summary>
        /// <param name="driver"></param>
        public CartPage(IDriver driver) : base(driver)
        {
        }

        #endregion

        private Label Label_EmptyCart()
        {
            return Label.ByXPath(_labelEmptyCartXpath);
        }

        #region Override Methods

        protected override void Initialize()
        {
            PageUri = new Uri("https://my.rozetka.com.ua/cart/");
            PageTitle = "ROZETKA — Корзина";

            _cartItemsXpath = "//div[@class='clearfix cart-i active']";
            _labelEmptyCartXpath = "//h2[text()='Корзина пуста']";
            _emptyCart = "Корзина пуста";
        }

        #endregion

        #region Private Methods

        private bool IsCartEmpty()
        {
            try
            {
                return Label_EmptyCart().GetText() != _emptyCart;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int GetCartItemsCount()
        {
            return Driver.FindElements(By.XPath(_cartItemsXpath)).Count;
        }

        #endregion


    }
}
