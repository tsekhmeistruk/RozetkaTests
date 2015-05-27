using System;
using System.Collections.Generic;
using System.Globalization;
using OpenQA.Selenium;
using RozetkaTesting.Framework.Core;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software
{
    public sealed class OperationSystemsPage: BasePage
    {
        #region String Values of Tag's Attributes on the Page

        /*----------Price filter----------*/
        private string _priceMinValueId = "price[min]";
        private string _priceMaxValueId = "price[max]";
        private string _submitPriceId = "submitprice";

        /*----------Type of user filter----------*/
        private string _typeOfUserId = "sort_52802";
        private string _titleUsers = "Для домашних и корпоративных пользователей";
        private string _titleBuilders = "Для сборщиков систем (ОЕМ)";

        /*----------Version of software filter----------*/
        private string _versionParameterId = "sort_26284";
        private string _titleWin7 = "Windows 7";
        private string _titleWin8 = "Windows 8";
        private string _titleWin81 = "Windows 8.1";

        /*----------System's capacity----------*/
        private string _bitId = "sort_26013";
        private string _title32bit = "32-разрядные";
        private string _title64bit = "64-разрядные";
        private string _title32and64bit = "32- и 64-разрядные";

        /*----------Type of Product----------*/
        private string _productTypeId = "sort_60842";
        private string _titleBoxType = "Коробочная версия";
        private string _titleOemType = "ОЕМ версия (для сборщиков систем)";
        private string _titleCorporateType = "Корпоративная лицензия";
        private string _titleElectronicKeyType = "Электронный ключ";

        /*----------Application's language----------*/
        private string _languageId = "sort_24795";
        private string _titleEnglish = "Английский";
        private string _titleMultilingual = "Многоязычный";
        private string _titleRussian = "Русский";
        private string _titleUkrainian = "Украинский";

        /*----------Products list----------*/
        private string _priceValueXPath = "//div[@class='g-price-uah']";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes new instance of <see cref="OperationSystemsPage"/> class.
        /// </summary>
        /// <param name="browser">Instance of <see cref="Driver"/> class.</param>
        public OperationSystemsPage(Driver browser) : base(browser)
        {
        }

        #endregion

        #region Page controls

        /*-----'Price' controls-----*/

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

        /*-----'Type of users' controls-----*/

        private Checkbox Checkbox_HomeUsers()
        {
            return Checkbox.ByIdAndTitle(_typeOfUserId, _titleUsers);
        }

        private Checkbox Checkbox_SystemBuilders()
        {
            return Checkbox.ByIdAndTitle(_typeOfUserId, _titleBuilders);
        }

        /*-----'Version of software' controls-----*/

        private Checkbox Checkbox_Windows7()
        {
            return Checkbox.ByIdAndTitle(_versionParameterId, _titleWin7);
        }

        private Checkbox Checkbox_Windows8()
        {
            return Checkbox.ByIdAndTitle(_versionParameterId, _titleWin8);
        }

        private Checkbox Checkbox_Windows81()
        {
            return Checkbox.ByIdAndTitle(_versionParameterId, _titleWin81);
        }

        /*-----'System's capacity' controls-----*/

        private Checkbox Checkbox_32bit()
        {
            return Checkbox.ByIdAndTitle(_bitId, _title32bit);
        }

        private Checkbox Checkbox_64bit()
        {
            return Checkbox.ByIdAndTitle(_bitId, _title64bit);
        }

        private Checkbox Checkbox_32and64bit()
        {
            return Checkbox.ByIdAndTitle(_bitId, _title32and64bit);
        }

        /*-----'Type of Product' controls-----*/

        private Checkbox Checkbox_BoxType()
        {
            return Checkbox.ByIdAndTitle(_productTypeId, _titleBoxType);
        }

        private Checkbox Checkbox_OemType()
        {
            return Checkbox.ByIdAndTitle(_productTypeId, _titleOemType);
        }

        private Checkbox Checkbox_CorporateType()
        {
            return Checkbox.ByIdAndTitle(_productTypeId, _titleCorporateType);
        }

        private Checkbox Checkbox_ElectronicKeyType()
        {
            return Checkbox.ByIdAndTitle(_productTypeId, _titleElectronicKeyType);
        }

        /*-----'Application's language' controls-----*/

        private Checkbox Checkbox_English()
        {
            return Checkbox.ByIdAndTitle(_languageId, _titleEnglish);
        }

        private Checkbox Checkbox_Multilingual()
        {
            return Checkbox.ByIdAndTitle(_languageId, _titleMultilingual);
        }

        private Checkbox Checkbox_Russian()
        {
            return Checkbox.ByIdAndTitle(_languageId, _titleRussian);
        }

        private Checkbox Checkbox_Ukrainian()
        {
            return Checkbox.ByIdAndTitle(_languageId, _titleUkrainian);
        }

        /*-----List of products-----*/

        private Label Label_PriceOfProducts()
        {
            //return Label.ByLocator(By.XPath(_priceValueXPath));
            return Label.ByLocator(By.XPath(_priceValueXPath));
        }

        #endregion

        #region Filter's functionality

        /*-----Price-----*/

        /// <summary>
        /// Sets the range of price values.
        /// </summary>
        public void SetPriceFilter(out int minValue, out int maxValue)
        {
            GetRandomRange(out minValue, out maxValue);
            Browser.Refresh();
            Browser.ExecuteJavaScript("document.getElementById('price[min]').value = " + minValue + ";");
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
        /// <returns></returns>
        public bool IsPriceInRange(int minPriceValue, int maxPriceValue)
        {
            List<string> prices = Label_PriceOfProducts().GetTexts();
            foreach (var price in prices)
            {
                if (int.Parse(price) > maxPriceValue || int.Parse(price) < minPriceValue)
                {
                    return false;
                }
            }
            return true;
        }

        /*-----Type of users-----*/

        /// <summary>
        /// Checks 'Home users' checkbox.
        /// </summary>
        public void CheckHomeUsers()
        {
            Checkbox_HomeUsers().Check();
        }

        #endregion

        //TODO Implement other functionality on this page.

        #region Override Methods

        /// <summary>
        /// Initializes all necessary members such as: URL, Title etc.
        /// </summary>
        protected override void Initialize()
        {
            PageUri = new Uri("http://soft.rozetka.com.ua/os/c80063/");

            PageTitle = "Операционные системы - Интернет магазин Rozetka.ua | " +
                        "Операционная система windows в Киеве, Одессе, Харькове, " +
                        "Донецке: цена, отзывы, продажа, купить оптом windows 7";
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
            minValue = rnd.Next(min, max/2);
            maxValue = rnd.Next(minValue, max);
        }

        #endregion
    }
}
