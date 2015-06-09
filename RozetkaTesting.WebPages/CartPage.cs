using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.HtmlControls;
using RozetkaTesting.WebPages.PageComponents;

namespace RozetkaTesting.WebPages
{
    public class CartPage : BasePage
    {
        #region Private Fields

        private string _emptyCart;
        private string _cartItemsXpath;
        private string _totalCostXpath;
        private string _labelEmptyCartXpath;

        private List<ProductCartItem> _productCartItems;
        private List<ProductCartItem> ProductCartItems
        {
            get
            {
                return _productCartItems ?? (_productCartItems = GetProductItems());
            }
        }

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

        /// <summary>
        /// Gets total cost of all products in the cart.
        /// </summary>
        /// <returns>Price of products in the cart.</returns>
        public int GetTotalCost()
        {
            var x = Regex.Replace(Label_TotalCost().GetText(), @"[^\d]", "");
            return int.Parse(x);
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

        #region Controls

        private Label Label_EmptyCart()
        {
            return Label.ByXPath(_labelEmptyCartXpath);
        }

        private Label Label_TotalCost()
        {
            return Label.ByXPath(_totalCostXpath);
        }

        #endregion

        #region Override Methods

        protected override void Initialize()
        {
            PageUri = new Uri("https://my.rozetka.com.ua/cart/");
            PageTitle = "ROZETKA — Корзина";

            _emptyCart = "Корзина пуста";
            _cartItemsXpath = "//div[@class='clearfix cart-i active']";
            _totalCostXpath = "//span[@class='cart-total-uah']/span[@name='cost']";
            _labelEmptyCartXpath = "//h2[text()='Корзина пуста']";
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

        private List<ProductCartItem> GetProductItems()
        {
            var productItems = new List<ProductCartItem>();
            for (int i = 1; i <= GetCartItemsCount(); i++)
            {
                productItems.Add(new ProductCartItem(i));
            }
            return productItems;
        }

        private int GetCartItemsCount()
        {
            return Driver.FindElements(By.XPath(_cartItemsXpath)).Count;
        }

        #endregion


    }
}
