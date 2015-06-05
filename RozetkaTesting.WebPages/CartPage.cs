using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages
{
    public class CartPage : BasePage
    {
        #region Private Fields

        private string _labelEmptyCart;

        #endregion

        #region CartPage Functionality



        #endregion

        #region Constructor

        public CartPage(IDriver driver) : base(driver)
        {
        }

        #endregion

        private Label Label_EmptyCart()
        {
            return Label.ByXPath(_labelEmptyCart);
        }

        #region Override Methods

        protected override void Initialize()
        {
            PageUri = new Uri("https://my.rozetka.com.ua/cart/");
            PageTitle = "ROZETKA — Корзина";

            _labelEmptyCart = "//h2[text()='Корзина пуста']";
        }

        #endregion

        #region Private Methods

        private bool IsCartEmpty()
        {
            try
            {
                return Label_EmptyCart().GetText() != "Корзина пуста";
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int GetCartItemsCount()
        {
            return Driver.FindElements(By.XPath("//*[@class='g-i-tile g-i-tile-catalog']")).Count;
        }

        #endregion


    }
}
