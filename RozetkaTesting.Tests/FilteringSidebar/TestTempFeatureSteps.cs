using System.ComponentModel;
using System.Threading;
using NUnit.Framework;
using RozetkaTesting.Tests.SpecFlow;
using RozetkaTesting.WebPages;
using RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.FilteringSidebar
{
    [Binding]
    class TestTempFeatureSteps
    {
        private OperationSystemsPage _osPage;
        private CartPage _cartPage;

        [BeforeScenario]
        private void Initialize()
        {
            _osPage = PageFactory.Get<OperationSystemsPage>();
            _cartPage = PageFactory.Get<CartPage>();
        }

        [When(@"I add random product to the cart")]
        public void WhenIAddRandomProductToTheCart()
        {
            ScenarioContext.Current.Set<int>(_osPage.AddProductAndReturnPrice(), "productPrice");
            
            
            //ScenarioContext.Current.Set<string>(_osPage.GetTitleOfResultPage(), "titleResultPage");
        }

        [Then(@"I have a product in cart with specific price")]
        public void ThenIHaveAProductInCartWithSpecificPrice()
        {
            _cartPage.Open();
            ScenarioContext.Current.Set<int>(_cartPage.GetCount(), "productCount");

            var currentCount = ScenarioContext.Current.Get<int>("productCount");

            //var currentPrice = ScenarioContext.Current.Get<int>("productPrice");
            //_osPage.OpenCart();

            //var expectedPrice = currentPrice;
            //Assert.AreEqual(expectedPrice, currentPrice);

            Assert.AreEqual(1, currentCount);


            //var currentTitle = ScenarioContext.Current.Get<string>("titleResultPage");
            //string expectedTitle = "Операционные системы";
            //Assert.AreEqual(expectedTitle, currentTitle);

        }

    }
}
