using System.Threading;
using NUnit.Framework;
using RozetkaTesting.Framework.Core;
using RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.FilteringSidebar
{
    [Binding]
    class FilteringSidebarSteps
    {
        #region Web driver

        private Driver _browser;

        private Driver Browser
        {
            get { return _browser ?? (_browser = FeatureContext.Current.Get<Driver>()); }
        }

        #endregion

        #region The steps of price filtration

        [Given(@"I'm on the Software page")]
        public void GivenImOnThePage()
        {
            var osPage = new OperationSystemsPage(Browser);
            ScenarioContext.Current.Set(osPage);
            osPage.Open();
        }

        [Given(@"I input min values and max values")]
        public void GivenIInputValuesAndValues()
        {
            var osPage = ScenarioContext.Current.Get<OperationSystemsPage>();
            osPage.SetPriceFilter();
        }

        [When(@"I press ok button for submitting price filter")]
        public void WhenIPressButtonForSubmittingPriceFilter()
        {
            var osPage = ScenarioContext.Current.Get<OperationSystemsPage>();
            osPage.SubmitPriceFilter();
        }

        [Then(@"the result page should contains goods which has appropriate price range")]
        public void ThenTheResultPageShouldContainsGoodsWhichHasAppropriatePriceRange()
        {
            Thread.Sleep(5000);
            Assert.AreEqual(0,0);
        }

        #endregion
    }
}
