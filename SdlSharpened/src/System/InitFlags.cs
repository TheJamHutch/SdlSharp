using SDL2;

namespace SdlSharpened
{
    public enum InitFlags
    {
        Timer = (int)SDL.SDL_INIT_TIMER,
        Audio = (int)SDL.SDL_INIT_AUDIO,
        Video = (int)SDL.SDL_INIT_VIDEO,
        Joystick = (int)SDL.SDL_INIT_JOYSTICK,
        Haptic = (int)SDL.SDL_INIT_HAPTIC,
        GameController = (int)SDL.SDL_INIT_GAMECONTROLLER,
        Events = (int)SDL.SDL_INIT_EVENTS,
        Everything = (int)SDL.SDL_INIT_EVERYTHING,
        NoParachute = (int)SDL.SDL_INIT_NOPARACHUTE
    }
}
