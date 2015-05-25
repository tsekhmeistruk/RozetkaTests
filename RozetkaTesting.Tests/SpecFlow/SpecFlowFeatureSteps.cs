using RozetkaTesting.Framework.Core;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.SpecFlow
{
    [Binding]
    public sealed class SpecFlowFeatureSteps
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeFeature]
        public static void BeforeFeature()
        {
            FeatureContext.Current.Set(new Driver());
            WebPages.HtmlControls.BaseControl.Driver = FeatureContext.Current.Get<Driver>();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            FeatureContext.Current.Get<Driver>().Quit();
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
