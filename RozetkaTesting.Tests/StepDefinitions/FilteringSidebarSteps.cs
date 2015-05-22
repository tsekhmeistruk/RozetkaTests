using System.Threading;
using NUnit.Framework;
using RozetkaTesting.Framework.SeleniumApiWrapper;
using RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.StepDefinitions
{
    [Binding]
    class FilteringSidebarSteps
    {
        #region Web driver

        private Browser _browser;

        private Browser Browser
        {
            get { return _browser ?? (_browser = FeatureContext.Current.Get<Browser>()); }
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
            osPage.SubmitPriceBtn();
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
