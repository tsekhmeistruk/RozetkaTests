using RozetkaTesting.WebPages;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.SpecFlow
{
    [Binding]
    public sealed class CommonSteps
    {
        [StepDefinition(@"I am on the ""(.*)"" page")]
        public void GivenIAmOnThePage(string pageName)
        {
            BasePage page = PageFactory.Get(pageName);
            page.Open();
        }

        [StepDefinition(@"the ""(.*)"" page is loaded")]
        public void WhenThePageIsLoaded(string pageName)
        {
            PageFactory.Get(pageName).Verify();
        }

    }
}
