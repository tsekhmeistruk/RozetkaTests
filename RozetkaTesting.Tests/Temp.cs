using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RozetkaTesting.Framework.DataModels;
using RozetkaTesting.Framework.Helpers;
using RozetkaTesting.Framework.SeleniumApiWrapper;
using RozetkaTesting.WebPages.Catalogue;

namespace RozetkaTesting.Tests
{
    [TestFixture]
    public class Temp
    {
        [Test]
        public void CheckMainPageTitle()
        {
            var page = new LeftNavBarPage("http://rozetka.com.ua");
            var jsonMenu = JsonHelper.GetMenuItems();
            page.Open();

            foreach (var item in jsonMenu)
            {
                Browser.Navigate(new Uri(item.url));        
            }
        }
    }
}
