using System;
using System.Collections.Generic;
using System.Text;

namespace SdlSharpened.App
{
    public class Sound
    {
        private MusicTrack _musicTrack;
        private SoundEffect _soundEffect;

        public Sound()
        {
            _musicTrack = new MusicTrack("./sound/arena_main.mp3");
            _soundEffect = new SoundEffect("./sound/shit.wav");
        }
    }
}
