using NUnit.Framework;
using RozetkaTesting.Tests.SpecFlow;
using RozetkaTesting.WebPages;
using RozetkaTesting.WebPages.Catalogue.NotebooksTabletsPcs.Software;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.Cart
{
    [Binding]
    class CartCheckingSteps
    {
        [When(@"I add random product to my cart")]
        public void WhenIAddRandomProductToMyCart()
        {
            int price = PageFactory.Get<OperationSystemsPage>().AddProductAndReturnPrice();
            ScenarioContext.Current.Set<int>(price, "price");
        }

        [Then(@"I should see the product which I have added before")]
        public void ThenIShouldSeeTheProductWhichIHaveAddedBefore()
        {
            int expectedPrice = ScenarioContext.Current.Get<int>("price");
            int cartPrice = PageFactory.Get<CartPage>().GetTotalCost();
            Assert.AreEqual(expectedPrice, cartPrice);
        }

    }
}
