using System;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;

namespace RozetkaTesting.WebPages
{
    public class ProductDescriptionPage : BasePage
    {
        #region Constructor

        public ProductDescriptionPage(IDriver driver) : base(driver)
        {
        }

        #endregion

        #region Product DescriptionPage Functionality

        /// <summary>
        /// Checks: Is the product belong to specific category.
        /// </summary>
        /// <param name="category">The name of category.</param>
        /// <returns>True if the product belongs to the specific category.</returns>
        public bool HasCategory(string category)
        {
            var count = Driver.FindElements(
                By.XPath(String.Format("//ul[@class='clearfix breadcrumbs']/li/a[*='{0}']", category))).Count;
            return 
                Driver.FindElements(
                    By.XPath(String.Format("//ul[@class='clearfix breadcrumbs']/li/a[*='{0}']", category))).Count > 0;
        }

        public new void Verify()
        {
            if (Driver.FindElements(By.XPath("//ul[@id='tabs']/li[@name='all']")).Count == 0)
            {
                throw new Exception("It is not Product Description Page");
            }        
        }

        #endregion

        #region Override Methods

        protected override void Initialize()
        {
        }

        #endregion
    }
}
