using System;

namespace SdlSharpened.App
{
    public enum LogLevel
    {
        Crit,
        Error,
        Warn,
        Info,
        Trace
    }

    public static class LogLevelEx 
    {
        public static ConsoleColorSet GetConsoleColors(this LogLevel logLevel) 
        {
            var colors = new ConsoleColorSet();

            switch (logLevel)
            {
                case LogLevel.Crit:
                    colors.Background = ConsoleColor.Red;
                    colors.Foreground = ConsoleColor.White;
                    break;
                case LogLevel.Error:
                    colors.Background = ConsoleColor.Black;
                    colors.Foreground = ConsoleColor.Red;
                    break;
                case LogLevel.Warn:
                    colors.Background = ConsoleColor.Black;
                    colors.Foreground = ConsoleColor.Yellow;
                    break;
                case LogLevel.Info:
                    colors.Background = ConsoleColor.Black;
                    colors.Foreground = ConsoleColor.White;
                    break;
                case LogLevel.Trace:
                    colors.Background = ConsoleColor.Black;
                    colors.Foreground = ConsoleColor.DarkGray;
                    break;
                default:
                    colors.Background = ConsoleColor.Black;
                    colors.Foreground = ConsoleColor.White;
                    break;
            }

            return colors;
        }
    }
}
