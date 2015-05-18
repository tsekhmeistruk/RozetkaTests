using System;
using RozetkaTesting.Framework.SeleniumApiWrapper;

namespace RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software
{
    public class SoftwarePage: PageBase
    {
        public string Title =
            "Программное обеспечение - Интернет магазин Rozetka.ua | Лицензионное по в Киеве, Одессе, Харькове, Донецке: цена, отзывы, продажа, купить оптом лицензионные программы";
        
        public SoftwarePage(Uri pageUri, Browser browser) : base(pageUri, browser)
        {
        }

    }
}
