using NUnit.Framework;
using RozetkaTesting.Tests.SpecFlow;
using RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.FilteringSidebar
{
    [Binding]
    class FilteringSidebarSteps
    {
        #region The steps of price filtration

        [Given(@"I am on the Software page")]
        public void GivenImOnThePage()
        {
            PageFactory.Get<OperationSystemsPage>().Open();
        }

        [Given(@"I input random min values and max values into 'price filter form' from range of possible values")]
        public void GivenIInputValuesAndValues()
        {
            int minValue;
            int maxValue;
            PageFactory.Get<OperationSystemsPage>().SetPriceFilter(out minValue, out maxValue);
            ScenarioContext.Current.Set<int>(minValue, "priceMinValue");
            ScenarioContext.Current.Set<int>(maxValue, "priceMaxValue");
        }

        [When(@"I press ok button for submitting price filter")]
        public void WhenIPressButtonForSubmittingPriceFilter()
        {
            PageFactory.Get<OperationSystemsPage>().SubmitPriceFilter();
        }

        [Then(@"The result page should contains goods which has appropriate price range")]
        public void ThenTheResultPageShouldContainsGoodsWhichHasAppropriatePriceRange()
        {
            var priceMinValue = ScenarioContext.Current.Get<int>("priceMinValue");
            var priceMaxValue = ScenarioContext.Current.Get<int>("priceMaxValue");
            Assert.IsTrue(PageFactory.Get<OperationSystemsPage>().IsPriceInRange(priceMinValue, priceMaxValue));
        }

        #endregion
    }
}
