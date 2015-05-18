using NUnit.Framework;
using RozetkaTesting.Framework.SeleniumApiWrapper;

namespace RozetkaTesting.Tests
{
    [SetUpFixture]
    public class OneTimeSetup
    {
        public static Browser Browser;

        [SetUp]
        public void RunBeforeTests()
        {
            Browser = new Browser();
        }

        [TearDown]
        public void RunAfterTests()
        {
            Browser.Quit();
        }
    }
}
