using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.Helpers;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages.PageComponents
{
    /// <summary>
    /// Provides functionality of page part which display specific category of products.
    /// For example: Notebooks, SSD, Operation systems etc. 
    /// </summary>
    public class ResultPageComponent: IResultPageComponent
    {
        #region Private Fields and Properties

        private readonly IDriver _driver;
        private string _titleResultPageCss;
        private string _catalogueItem;
        private string _idCartPopUp;

        private List<ProductItem> _productItems;
        private List<ProductItem> ProductItems
        {
            get
            {
                return _productItems ?? (_productItems = GetProductItems());
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of ResultPageComponent which uses IDriver object.
        /// </summary>
        /// <param name="driver">Instance of <see cref="IDriver"/>.</param>
        public ResultPageComponent(IDriver driver)
        {
            _driver = driver;
            Initialize();
        }

        #endregion

        #region Controls

        private Label Label_TitleResultPage()
        {
            return Label.ByCss(_titleResultPageCss);
        }

        #endregion

        #region ResultPage Functionality

        /// <summary>
        /// Gets the title of the result page.
        /// </summary>
        /// <returns>Text of the title on the result page.</returns>
        //TODO Expand this method by overloads with next input parameters: product name | product price 
        public string GetTitleOfResultPage()
        {
            return Label_TitleResultPage().GetText();
        }

        /// <summary>
        /// Adds product to the cart by index and return its price.
        /// </summary>
        /// <param name="indexOfItem">Index of the item its position number of the product on the current page.</param>
        /// <returns>Price value of the product which was been added.</returns>
        public string AddProductToCartAndReturnPrice(int indexOfItem)
        {
            var price = ProductItems.Where(p => p.GetIndex() == indexOfItem)
                    .Select(x => Regex.Replace(x.GetPrice(), @"[^\d]", ""))
                    .FirstOrDefault();

            ProductItems[indexOfItem - 1].AddToCart();
            WaitUntilCartPopUpIsAppear();
            return price;
        }

        /// <summary>
        /// Adds random product from result page to the cart and return its price.
        /// </summary>
        /// <returns>Price value of the product which was been added.</returns>
        public string AddProductToCartAndReturnPrice()
        {
            var indexOfItem = RandomHelper.GetRandomValue(1, GetNumberOfProductItems());
            return AddProductToCartAndReturnPrice(indexOfItem);
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            _titleResultPageCss = "#title_page .c-cols-inner-l > h1";
            _idCartPopUp = "cart-popup";
            _catalogueItem = "//div[@class='g-i-tile g-i-tile-catalog']";
        }

        private List<ProductItem> GetProductItems()
        {
            var productItems = new List<ProductItem>();
            for (int i = 1; i <= GetNumberOfProductItems(); i++)
            {
                productItems.Add(new ProductItem(i));
            }
            return productItems;
        }

        private int GetNumberOfProductItems()
        {
            return _driver.FindElements(By.XPath(_catalogueItem)).Count;
        }

        private void WaitUntilCartPopUpIsAppear()
        {
            _driver.WaitUntilElementPresent(By.Id(_idCartPopUp));
        }

        #endregion
    }
}
