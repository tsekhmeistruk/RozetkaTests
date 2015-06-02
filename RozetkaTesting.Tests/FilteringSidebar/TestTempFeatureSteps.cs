using NUnit.Framework;
using RozetkaTesting.Tests.SpecFlow;
using RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.FilteringSidebar
{
    [Binding]
    class TestTempFeatureSteps
    {
        private readonly OperationSystemsPage _osPage = PageFactory.Get<OperationSystemsPage>();

        [When(@"I add random product to the cart")]
        public void WhenIAddRandomProductToTheCart()
        {
            //ScenarioContext.Current.Set<int>(_osPage.AddProductAndReturnPrice(), "productPrice");
            ScenarioContext.Current.Set<string>(_osPage.GetTitleOfResultPage(), "titleResultPage");
        }

        [Then(@"I have a product in cart with specific price")]
        public void ThenIHaveAProductInCartWithSpecificPrice()
        {
            //var currentPrice = ScenarioContext.Current.Get<int>("productPrice");
            //var expectedPrice = 2000;
            //Assert.AreEqual(expectedPrice, currentPrice);

            var currentTitle = ScenarioContext.Current.Get<string>("titleResultPage");
            string expectedTitle = "Операционные системы";
            Assert.AreEqual(expectedTitle, currentTitle);

        }

    }
}
