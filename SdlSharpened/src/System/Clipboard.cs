using SDL2;

namespace SdlSharpened
{
    public static class Clipboard
    {
        public static bool HasText() 
        {
            return (SDL.SDL_HasClipboardText() == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public static string GetText() 
        {
            return SDL.SDL_GetClipboardText();
        }

        public static void SetText(string text) 
        {
            SDL.SDL_SetClipboardText(text);
        }
    }
}
