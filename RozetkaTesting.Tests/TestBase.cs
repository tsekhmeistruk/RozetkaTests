using NUnit.Framework;
using RozetkaTesting.Framework.SeleniumApiWrapper;

namespace RozetkaTesting.Tests
{
    public abstract class TestBase
    {
        public Browser Browser;

        [TestFixtureSetUp]
        public void Init()
        {
            this.Browser = OneTimeSetup.Browser;
        }
    }
}
