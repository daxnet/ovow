using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Ovow.Framework.Sounds
{
    public sealed class Sound : Component
    {
        private readonly float volume;
        private readonly SoundEffect soundEffect;
        private SoundEffectInstance soundEffectInstance;

        public Sound(SoundEffect soundEffect, float volume = 1.0F)
        {
            this.soundEffect = soundEffect;
            this.volume = volume;
        }

        public override void Update(GameTime gameTime) { }

        public void Play()
        {
            Stop();

            soundEffectInstance = soundEffect.CreateInstance();
            soundEffectInstance.Volume = this.volume;
            soundEffectInstance.Play();
        }

        public void Stop()
        {
            if (soundEffectInstance != null &&
                !soundEffectInstance.IsDisposed)
            {
                soundEffectInstance.Stop(true);
                soundEffectInstance.Dispose();
            }
        }
    }
}
