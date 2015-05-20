using System;
using NUnit.Framework;
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
            if (uri == null)
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
            var uri = new Uri("http://soft.rozetka.com.ua", UriKind.Absolute);
            return uri;
        }
    }
}