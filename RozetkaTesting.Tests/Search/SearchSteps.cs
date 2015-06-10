using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RozetkaTesting.Tests.SpecFlow;
using RozetkaTesting.WebPages;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.Search
{
    [Binding]
    public sealed class SearchSteps
    {
        [Given(@"I am on the Main page")]
        public void GivenIAmOnTheMainPage()
        {
            PageFactory.Get<MainPage>().Open();
        }

        [When(@"I enter search ""(.*)""")]
        public void WhenIEnterSearch(string keyword)
        {
             PageFactory.Get<MainPage>().EnterSearchPhrase(keyword);
        }

        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {
             PageFactory.Get<MainPage>().SubmitSearch();
        }

        [When(@"the Search Result page is loaded")]
        public void WhenTheResultPageIsLoaded()
        {
            PageFactory.Get<SearchResultPage>().Verify();
        }

        [When(@"I click on the random product from the list of products on the Result page")]
        public void WhenIClickOnTheRandomProductFromTheListOfProductsOnTheResultPage()
        {
            PageFactory.Get<SearchResultPage>().OpenProductDesription();
        }

        [When(@"the page product description page is loaded")]
        public void WhenThePageWithProductDescriptionIsLoaded()
        {
            PageFactory.Get<ProductDescriptionPage>().Verify();
        }

        [Then(@"the product category name should include the ""(.*)""\.")]
        public void ThenTheProductCategoryNameShouldIncludeThe_(string keyword)
        {
            Assert.IsTrue(PageFactory.Get<ProductDescriptionPage>().HasCategory(keyword));
        }

    }
}
