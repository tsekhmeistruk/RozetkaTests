using RozetkaTesting.Framework.Core;
using RozetkaTesting.Integrations;
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
            FeatureContext.Current.Set((IDriver)new Driver());
            WebPages.HtmlControls.BaseControl.Driver = FeatureContext.Current.Get<IDriver>();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            FeatureContext.Current.Get<IDriver>().Quit();
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
