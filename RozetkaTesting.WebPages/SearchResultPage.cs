using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.Helpers;
using RozetkaTesting.WebPages.PageComponents;

namespace RozetkaTesting.WebPages
{
    public class SearchResultPage: BasePage
    {
        #region Private Fields and Properties

        private List<SearchProductItem> _productItems;
        private string _productItem;

        private List<SearchProductItem> ProductItems
        {
            get { return _productItems ?? (_productItems = GetProductItems()); }
        }

        #endregion

        #region Constructor

        public SearchResultPage(IDriver driver) : base(driver)
        {
        }

        #endregion

        #region SearchResultPage Functionality

        /// <summary>
        /// Verifies for the authenticity of the page. 
        /// </summary>
        public new void Verify()
        {
            if (Driver.Title != GetTitle())
            {
                throw new Exception("It is not Search Result Page");
            }
        }

        public void OpenProductDesription(int index)
        {
            ProductItems[index].OpenItem();
        }

        public void OpenProductDesription()
        {
            var index = RandomHelper.GetRandomValue(1, GetNumberOfProductItems());
            OpenProductDesription(index);
        }

        #endregion

        #region Override Methods

        protected override void Initialize()
        {
            PageTitle = "Результаты поиска";
            _productItem = "//*[@class='g-i-list available clearfix']";
        }

        #endregion

        #region Private Methods

        private List<SearchProductItem> GetProductItems()
        {
            var productItems = new List<SearchProductItem>();
            for (int i = 1; i <= GetNumberOfProductItems(); i++)
            {
                productItems.Add(new SearchProductItem(i));
            }
            return productItems;
        }

        private int GetNumberOfProductItems()
        {
            return Driver.FindElements(By.XPath(_productItem)).Count;
        }

        #endregion
    }
}
