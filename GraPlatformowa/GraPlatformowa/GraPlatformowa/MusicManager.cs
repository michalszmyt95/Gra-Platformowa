using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraPlatformowa
{
    class MusicManager
    {
        List<SoundEffectInstance> AllMusic = new List<SoundEffectInstance>();


        public MusicManager(ref List<SoundEffectInstance> AllMusic)
        {
            this.AllMusic = AllMusic;
            foreach (var music in this.AllMusic)
            {
                music.IsLooped = true;
            }
        }

        List<SoundEffectInstance> isPlaying = new List<SoundEffectInstance>();
        
        public void Play(ref SoundEffectInstance music)
        {
            music.Volume = 0.60f;
            foreach (var currentMusic in isPlaying)
            {
                if (currentMusic == music)
                    return;
            }

            if (music.State == SoundState.Stopped)
            {
                music.Play();
            }

            isPlaying.Add(music);
        }
        // Zatrzymuje wszystkie piosenki i puszcza tę pojedynczą:
        public void PlayOnlyThis(ref SoundEffectInstance music) 
        {
            foreach (var currentMusic in isPlaying)
            {
                if (currentMusic == music)
                    return;
            }
            StopAllMusic();
            this.Play(ref music);
            isPlaying.Add(music);
        }

        public void Stop(SoundEffectInstance music)
        {
            music.Stop();
        }

        public void StopAllMusic()
        {
            foreach (SoundEffectInstance music in isPlaying)
            {
                music.Stop();
            }
            isPlaying.Clear();
        }

        public List<SoundEffectInstance> IsPlaying()
        {
            return this.isPlaying;
        }

        public List<SoundEffectInstance> GetMusicList()
        {
            return this.AllMusic;
        }
    }
}
