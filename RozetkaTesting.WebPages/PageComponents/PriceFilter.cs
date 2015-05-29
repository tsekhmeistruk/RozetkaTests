using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages.PageComponents
{
    public class PriceFilter
    {
        #region String Attribute Values of Controls

        private string _priceMinValueId = "price[min]";
        private string _priceMaxValueId = "price[max]";
        private string _submitPriceId = "submitprice";

        private string _priceValueXPath = "//div[@class='g-price-uah']";

        #endregion

        #region Controls

        private TextField TextField_MinPriceValue()
        {
            return TextField.ById(_priceMinValueId);
        }

        private TextField TextField_MaxPriceValue()
        {
            return TextField.ById(_priceMaxValueId);
        }

        private Button Button_SubmitPrice()
        {
            return Button.ById(_submitPriceId);
        }

        #endregion

        #region PriceFilter Functionality

        /// <summary>
        /// Sets the range of price values.
        /// </summary>
        public void SetPriceFilter(out int minValue, out int maxValue)
        {
            GetRandomRange(out minValue, out maxValue);
            BaseControl.Driver.Refresh();
            BaseControl.Driver.ExecuteJavaScript("document.getElementById('price[min]').value = " + minValue + ";");
            TextField_MaxPriceValue().ClearAndType(maxValue.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Presses button 'OK' for submitting range of price.
        /// </summary>
        public void SubmitPriceFilter()
        {
            Button_SubmitPrice().Click();
        }

        /// <summary>
        /// Checks the price of products are in the range.
        /// </summary>
        /// <param name="minPriceValue">Min value of the range.</param>
        /// <param name="maxPriceValue">Max value of the range.</param>
        /// <returns>True if the price exists in the range.</returns>
        public bool IsPriceInRange(int minPriceValue, int maxPriceValue)
        {
            IEnumerable<string> prices = GetListOfPrices();
            foreach (var price in prices)
            {
                if (int.Parse(price) > maxPriceValue || int.Parse(price) < minPriceValue)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Private Methods

        private void GetPriceRange(out int minValue, out int maxValue)
        {
            TextField_MinPriceValue().ClearAndType("_");
            TextField_MaxPriceValue().ClearAndType("");
            minValue = int.Parse(TextField_MinPriceValue().GetValue());
            maxValue = int.Parse(TextField_MaxPriceValue().GetValue());
        }

        private void GetRandomRange(out int minValue, out int maxValue)
        {
            int min, max;
            var rnd = new Random();
            GetPriceRange(out min, out max);
            minValue = rnd.Next(min, max / 2);
            maxValue = rnd.Next(minValue, max);
        }

        private IEnumerable<string> GetListOfPrices()
        {
            var elementsWithPrice = BaseControl.Driver.FindElements(By.XPath(_priceValueXPath));
            return elementsWithPrice.Select(webElement => Regex.Replace(webElement.Text, @"[^\d]", "")).ToList();
        }
        #endregion
    }
}
