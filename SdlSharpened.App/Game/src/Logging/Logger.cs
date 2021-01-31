using System;

namespace SdlSharpened.App
{
    public class Logger
    {
        private readonly LogLevel _defaultLogLevel = LogLevel.Info;

        /// <summary>
        ///   Logs at the default log level.
        /// </summary>
        /// <param name="text"></param>
        public void Log(string text)
        {
            Log(_defaultLogLevel, text);
        }

        /// <summary>
        ///   Logs at the default log level.
        /// </summary>
        /// <param name="text"></param>
        public void Crit(string text)
        {
            Log(LogLevel.Crit, $"[CRIT] -- {text}");
        }

        /// <summary>
        ///   Logs at the default log level.
        /// </summary>
        /// <param name="text"></param>
        public void Error(string text)
        {
            Log(LogLevel.Error, $"[ERROR] - {text}");
        }

        /// <summary>
        ///   Logs at the default log level.
        /// </summary>
        /// <param name="text"></param>
        public void Warn(string text)
        {
            Log(LogLevel.Warn, $"[WARN] -- {text}");
        }

        /// <summary>
        ///   Logs at the default log level.
        /// </summary>
        /// <param name="text"></param>
        public void Info(string text)
        {
            Log(LogLevel.Info, $"[INFO] -- {text}");
        }

        /// <summary>
        ///   Logs at the default log level.
        /// </summary>
        /// <param name="text"></param>
        public void Trace(string text)
        {
            Log(LogLevel.Trace, $"[TRACE] - {text}");
        }

        private void Log(LogLevel logLevel, string text)
        {
            // Get the set of console colors associated with the log level.
            var colors = logLevel.GetConsoleColors();

            // Set console colors.
            Console.BackgroundColor = colors.Background;
            Console.ForegroundColor = colors.Foreground;

            // Write text to console.
            Console.WriteLine(text);

            // Set console colors back to default after.
            colors = _defaultLogLevel.GetConsoleColors();
            Console.BackgroundColor = colors.Background;
            Console.ForegroundColor = colors.Foreground;
        }
    }
}
