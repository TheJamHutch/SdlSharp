using System;
using SDL2;

namespace SdlSharpened
{
    public class Mixer
    {
        public Mixer()
        {
            SDL_mixer.Mix_OpenAudio(44100, SDL_mixer.MIX_DEFAULT_FORMAT, 2, 4096);
        }

        ~Mixer() 
        {
            SDL_mixer.Mix_Quit();
        }

        public void PlayMusic(MusicTrack music) 
        {
            SDL_mixer.Mix_PlayMusic(music.Pointer, 0);
        }

        public void PlaySoundEffect(SoundEffect effect) 
        {
            SDL_mixer.Mix_PlayChannel(-1, effect.Pointer, 0);
        }
    }
}