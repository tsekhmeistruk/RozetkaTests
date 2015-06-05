using System;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software
{
    public sealed class OperationSystemsPage: BasePage
    {
        #region String Values of Tag's Attributes on the Page

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

        #endregion

        #region Page Components

        private readonly IPriceFilterComponent _priceFilterComponent;
        private readonly IResultPageComponent _resultPageComponent;
        private readonly IHeaderComponent _header;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes new instance of <see cref="OperationSystemsPage"/> class.
        /// </summary>
        /// <param name="driver">Implementation of <see cref="IDriver"/>.</param>
        /// <param name="priceFilterComponent">The component of the price filtering.</param>
        /// <param name="resultPageComponent">The component of the result page.</param>
        /// <param name="header">The component of the header.</param>
        public OperationSystemsPage(IDriver driver, 
                                    IPriceFilterComponent priceFilterComponent,
                                    IResultPageComponent resultPageComponent, 
                                    IHeaderComponent header) 
                                    :base(driver)
        {
            _priceFilterComponent = priceFilterComponent;
            _resultPageComponent = resultPageComponent;
            _header = header;
        }

        #endregion

        #region Page controls

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

        #endregion

        #region Filter's functionality

        /*-----Price-----*/

        /// <summary>
        /// Sets the range of price values.
        /// </summary>
        public void SetPriceFilter(out int minValue, out int maxValue)
        {
            _priceFilterComponent.SetPriceFilter(out minValue, out maxValue);
        }

        /// <summary>
        /// Presses button 'OK' for submitting range of price.
        /// </summary>
        public void SubmitPriceFilter()
        {
            _priceFilterComponent.SubmitPriceFilter();
        }

        /// <summary>
        /// Checks the price of products are in the range.
        /// </summary>
        /// <param name="minPriceValue">Min value of the range.</param>
        /// <param name="maxPriceValue">Max value of the range.</param>
        /// <returns></returns>
        public bool IsPriceInRange(int minPriceValue, int maxPriceValue)
        {
            return _priceFilterComponent.IsPriceInRange(minPriceValue, maxPriceValue);
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

        #region PageResult functionality

        /// <summary>
        /// Adds random product from result page to the cart and return its price.
        /// </summary>
        /// <returns>Price value of the product which was been added.</returns>
        public int AddProductAndReturnPrice()
        {
            return int.Parse(_resultPageComponent.AddProductToCartAndReturnPrice());
        }

        /// <summary>
        /// Adds product from result page to the cart by index and return its price.
        /// </summary>
        /// <param name="indexOfItem">Index of the item.</param>
        /// <returns>Price value of the product which was been added.</returns>
        public int AddProductAndReturnPrice(int indexOfItem)
        {
            return int.Parse(_resultPageComponent.AddProductToCartAndReturnPrice());
        }

        /// <summary>
        /// Gets the title of the result page.
        /// </summary>
        /// <returns>Text of the title on the result page.</returns>
        public string GetTitleOfResultPage()
        {
            return _resultPageComponent.GetTitleOfResultPage();
        }

        #endregion

        #region Header Functionality

        /// <summary>
        /// Opens cart as pop-up window.
        /// </summary>
        public void OpenCart()
        {
            _header.OpenCart();
        }

        #endregion

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
    }
}
