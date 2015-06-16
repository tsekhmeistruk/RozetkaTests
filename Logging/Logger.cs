using System.IO;
using log4net;
using log4net.Config;

namespace Logging
{
    internal class Logger: ILogger
    {
        private readonly ILog _logger;

        public Logger(ILog logger)
        {
            _logger = logger;
            LoadConfig();
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        private void LoadConfig()
        {
            var configFile = new FileInfo("LoggerConfig.xml");
            XmlConfigurator.Configure(configFile);
        }
    }
}
