namespace SibSample.SeedWorks.Logs
{
    using System;

    public class Logging : ILogging
    {
        public static readonly ILogging Instance = new Logging();

        public string TimeStamp => DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
        public string Application => "SibSampleApi";
        public LogLevel Level { get; set; }
        public string Type { get; set; }

        /// <summary>
        ///     Create Logging level Error
        /// </summary>
        /// <param name="exception"></param>
        /// <exception cref="Exception"></exception>
        public void Error(object exception)
        {
            Serilog.Log.Error("{{ \"Headers\": {@Logging}, \"Message\": {@Message} }}",
                new Logging {Level = LogLevel.Error},
                exception);
        }

        /// <summary>
        ///     Create Logging level Warning
        /// </summary>
        /// <param name="message"></param>
        public void Warning(object message)
        {
            Serilog.Log.Warning("{{ \"Headers\": {@Logging}, \"Message\": {@Message} }}",
                new Logging {Level = LogLevel.Warning}, message);
        }

        /// <summary>
        ///     Create Logging level Information
        /// </summary>
        /// <param name="message"></param>
        public void Information(object message)
        {
            Serilog.Log.Information("{{ \"Headers\": {@Logging}, \"Message\": {@Message} }}",
                new Logging {Level = LogLevel.Information}, message);
        }
    }
}