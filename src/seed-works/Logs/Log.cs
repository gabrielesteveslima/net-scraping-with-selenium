namespace SibSample.SeedWorks.Logs
{
    using System;

    /// <summary>
    ///     An optional static entry point for logging that can be easily referenced
    ///     by different parts of an application. To configure the <see cref="Log" />
    ///     set the Logger static property to a logger instance.
    /// </summary>
    public static class Log
    {
        private static ILogging _logger = Logging.Instance;

        /// <summary>
        ///     The globally-shared logger.
        /// </summary>
        /// <exception cref="ArgumentNullException">When <paramref name="value" /> is <code>null</code></exception>
        public static ILogging Logger
        {
            get => _logger;
            set => _logger = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static void Error(object message)
        {
            Logger.Error(message);
        }

        public static void Warning(object message)
        {
            Logger.Warning(message);
        }

        public static void LogInformation(object message)
        {
            Logger.Information(message);
        }
    }
}