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
            FeatureContext.Current.Set(DriverFactory.GetDriver());
            WebPages.HtmlControls.BaseControl.Driver = FeatureContext.Current.Get<IDriver>();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            FeatureContext.Current.Get<IDriver>().Quit();
        }
    }
}
