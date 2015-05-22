using RozetkaTesting.Framework.SeleniumApiWrapper;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.StepDefinitions
{
    [Binding]
    public sealed class SpecFlowFeatureSteps
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeFeature]
        public static void BeforeFeature()
        {
            FeatureContext.Current.Set(new Browser());
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            FeatureContext.Current.Get<Browser>().Quit();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
