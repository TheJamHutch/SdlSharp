using System;

namespace SdlSharpened.App
{
    public struct ConsoleColorSet
    {
        public ConsoleColor Background { get; set; }
        public ConsoleColor Foreground { get; set; }

        public ConsoleColorSet(ConsoleColor background, ConsoleColor foreground)
        {
            Background = background;
            Foreground = foreground;
        }
    }
}
