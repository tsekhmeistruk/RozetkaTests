using System;
using System.Diagnostics;
using System.Reflection;
using log4net;

namespace Logging
{
    /// <summary>
    /// Factory for creating ILogger objects.
    /// </summary>
    public static class LoggerFactory
    {

        /// <summary>
        /// Create a logger for the calling assembly.
        /// </summary>
        /// <returns>An ILogger object for the calling assembly.</returns>
        public static ILogger CreateLoggerForAssembly()
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            ILog logger = LogManager.GetLogger(callingAssembly.GetName().Name);
            return new Logger(logger);
        }

        /// <summary>
        /// Create a logger for the calling class.
        /// </summary>
        /// <returns>An ILogger object for the calling class.</returns>
        public static ILogger CreateLoggerForClass()
        {
            MethodBase method = new StackFrame(1).GetMethod();
            ILog logger = LogManager.GetLogger(method.DeclaringType.FullName);
            return new Logger(logger);
        }

        /// <summary>
        /// Create a logger for a specified type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>An ILogger object for the specified type.</returns>
        public static ILogger CreateLoggerForType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type", "A logger cannot be created for a null type.");
            }

            ILog logger = LogManager.GetLogger(type);
            return new Logger(logger);
        }
    }
}
