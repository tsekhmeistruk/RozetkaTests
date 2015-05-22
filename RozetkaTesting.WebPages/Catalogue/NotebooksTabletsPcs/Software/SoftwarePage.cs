using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RozetkaTesting.Framework.SeleniumApiWrapper;

namespace RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software
{
    public class SoftwarePage: PageBase
    {
        #region IWebElements

        [FindsBy(How = How.CssSelector, Using = "a.paginator-catalog-l-link")] 
        private IList<IWebElement> _paginators;

        #endregion

        #region Constructor

        public SoftwarePage(Browser browser) : base(browser)
        {
            PageUri = new Uri("http://soft.rozetka.com.ua/");
            PageTitle = "Программное обеспечение - Интернет магазин Rozetka.ua | Лицензионное по в Киеве, Одессе, Харькове, Донецке: цена, отзывы, продажа, купить оптом лицензионные программы";
        }

        #endregion

        #region SoftwarePage functionality

        //TODO 

        #endregion
    }
}
