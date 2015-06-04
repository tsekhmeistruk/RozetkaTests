using RozetkaTesting.Integrations;

namespace RozetkaTesting.Framework.Core
{
    public static class DriverFactory
    {
        private static IDriver _driver;

        public static IDriver GetDriver()
        {
            return _driver ?? (_driver = new Driver());
        }
    }
}
