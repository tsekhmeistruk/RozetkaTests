using System;
using System.Collections.Generic;
using NUnit.Framework;
using RozetkaTesting.Framework.DataModels;
using RozetkaTesting.Framework.Helpers;
using RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software;

namespace RozetkaTesting.Tests
{
    [TestFixture]
    public class Temp : TestBase
    {
        private SoftwarePage _softwarePage;

        [TestFixtureSetUp]
        public void Initialize()
        {
            Uri uri = GetUri();
            if (uri == null || uri == new Uri("error"))
            {
                throw new ArgumentNullException();
            }
            _softwarePage = new SoftwarePage(uri, Browser);
        }

        [Test]
        public void CheckMainPageTitle()
        {
            _softwarePage.Open();
            Assert.AreEqual(_softwarePage.GetTitle(), _softwarePage.Title);
        }

        private Uri GetUri()
        {
            HashSet<FirstLevelItem> menuItems = JsonHelper.GetMenuItems();
            string url = null;
            foreach (FirstLevelItem firstLevelItem in menuItems)
            {
                foreach (SecondLevelItem secondLevelItem in firstLevelItem.subItems)
                {
                    if (secondLevelItem.subTopic == "Программное обеспечение")
                    {
                        url = secondLevelItem.subUrl;
                    }
                }
            }

            return new Uri(url) != null ? new Uri(url) : new Uri("error");
        }
    }
}