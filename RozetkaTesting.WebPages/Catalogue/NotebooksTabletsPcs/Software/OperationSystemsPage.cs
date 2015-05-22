using System;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RozetkaTesting.Framework.SeleniumApiWrapper;

namespace RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software
{
    public class OperationSystemsPage: PageBase
    {
        #region Filter's Elements

        /*----------Price filter----------*/
        private const string _priceMinValueId = "price[min]";
        private const string _priceMaxValueId = "price[max]";
        private const string _submitPriceId = "submitprice";

        [FindsBy(How = How.Id, Using = _priceMinValueId)] 
        private IWebElement _priceMinInput;

        [FindsBy(How = How.Id, Using = _priceMaxValueId)]
        private IWebElement _priceMaxInput;

        [FindsBy(How = How.Id, Using = _submitPriceId)]
        private IWebElement _priceSubmitButton;

        /*----------Type of user filter----------*/
        private const string _typeOfUserParameterId = "sort_52802";
        private const string _titleUsers = "Для домашних и корпоративных пользователей";
        private const string _titleBuilders = "Для сборщиков систем (ОЕМ)";

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _typeOfUserParameterId + "']/a//i[text()='" + _titleUsers + "']/../..")]
        private IWebElement _homeUsersCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _typeOfUserParameterId + "']/a//i[text()='" + _titleBuilders + "']/../..")]
        private IWebElement _systemBuildersCheckbox;

        /*----------Version of software filter----------*/
        private const string _versionParameterId = "sort_26284";
        private const string _titleParameterWin7 = "Windows 7";
        private const string _titleParameterWin8 = "Windows 8";
        private const string _titleParameterWin81 = "Windows 8.1";

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _versionParameterId + "']/a//i[text()='" + _titleParameterWin7 + "']/../..")]
        private IWebElement _windows7Checkbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _versionParameterId + "']/a//i[text()='" + _titleParameterWin8 + "']/../..")] 
        private IWebElement _windows8Checkbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _versionParameterId + "']/a//i[text()='" + _titleParameterWin81 + "']/../..")] 
        private IWebElement _windows81Checkbox;

        /*----------System's capacity----------*/
        private const string _bitParameterId = "sort_26013";
        private const string _titleParameter32bit = "32-разрядные";
        private const string _titleParameter64bit = "64-разрядные";
        private const string _titleParameter32and64bit = "32- и 64-разрядные";

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _bitParameterId + "']/a//i[text()='" + _titleParameter32bit + "']/../..")]
        private IWebElement _32bitCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _bitParameterId + "']/a//i[text()='" + _titleParameter64bit + "']/../..")]
        private IWebElement _64bitCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _bitParameterId + "']/a//i[text()='" + _titleParameter32and64bit + "']/../..")]
        private IWebElement _32and64Checkbox;

        /*----------Type of Product----------*/
        private const string _productTypeParameterId = "sort_60842";
        private const string _titleBoxType = "Коробочная версия";
        private const string _titleOemType = "ОЕМ версия (для сборщиков систем)";
        private const string _titleCorporateType = "Корпоративная лицензия";
        private const string _titleElectronicKeyType = "Электронный ключ";

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _productTypeParameterId + "']/a//i[text()='" + _titleBoxType + "']/../..")] 
        private IWebElement _BoxTypeChecbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _productTypeParameterId + "']/a//i[text()='" + _titleOemType + "']/../..")] 
        private IWebElement _oemTypeCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _productTypeParameterId + "']/a//i[text()='" + _titleCorporateType + "']/../..")]
        private IWebElement _corporateTypeCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _productTypeParameterId + "']/a//i[text()='" + _titleElectronicKeyType + "']/../..")]
        private IWebElement _electronicKeyTypeCheckbox;


        /*----------Application's language----------*/
        private const string _languageParameterId = "sort_24795";
        private const string _titleEnglish = "Английский";
        private const string _titleMultilingual = "Многоязычный";
        private const string _titleRussian = "Русский";
        private const string _titleUkrainian = "Украинский";

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _languageParameterId + "']/a//i[text()='" + _titleEnglish + "']/../..")]
        private IWebElement _englishChecbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _languageParameterId + "']/a//i[text()='" + _titleMultilingual + "']/../..")]
        private IWebElement _multilingualCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _languageParameterId + "']/a//i[text()='" + _titleRussian + "']/../..")] 
        private IWebElement _russianCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='" + _languageParameterId + "']/a//i[text()='" + _titleUkrainian + "']/../..")] 
        private IWebElement _ukrainianCheckbox;

        #endregion

        #region Constructor

        public OperationSystemsPage(Browser browser) : base(browser)
        {
            PageUri = new Uri("http://soft.rozetka.com.ua/os/c80063/");
            PageTitle = "Операционные системы - Интернет магазин Rozetka.ua | Операционная система windows в Киеве, Одессе, Харькове, Донецке: цена, отзывы, продажа, купить оптом windows 7";
        }

        #endregion

        #region Filter's functionality

        /*----------Price----------*/

        /// <summary>
        /// Sets the range of price values.
        /// </summary>
        public void SetPriceFilter()
        {
            int minValue;
            int maxValue;
            GetRandomRange(out minValue, out maxValue);
            Browser.Refresh();
            Browser.ExecuteJavaScript("document.getElementById('price[min]').value = " + minValue + ";");
            SendKeys(_priceMaxInput, maxValue.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Presses button 'OK' for submitting range of price.
        /// </summary>
        public void SubmitPriceBtn()
        {
            _priceSubmitButton.Click();
        }

        /// <summary>
        /// Resets price filter's values. 
        /// </summary>
        public void ResetPriceFilter()
        {
            _priceMinInput.Clear();
            _priceMaxInput.Clear();
            _priceSubmitButton.Click();
        }

        #endregion

        //TODO Implement other functionality on this page.


        private void GetPriceRange(out int minValue, out int maxValue)
        {
            _priceMinInput.SendKeys("1");
            _priceMaxInput.Clear();
            minValue = int.Parse(_priceMinInput.GetAttribute("value"));
            maxValue = int.Parse(_priceMaxInput.GetAttribute("value"));
        }

        private void GetRandomRange(out int minValue, out int maxValue)
        {
            int min, max;
            var rnd = new Random();
            GetPriceRange(out min, out max);
            minValue = rnd.Next(min, max/2);
            maxValue = rnd.Next(minValue, max);
        }
    }
}
