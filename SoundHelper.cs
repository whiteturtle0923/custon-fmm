using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Fargowiltas
{
    public static class SoundHelper
    {
        public static SoundStyle LegacySoundStyle(string sound, int style, float volume = 1, float pitch = 0) => new SoundStyle($"Terraria/Sounds/{sound}_{style}") { Volume = volume, Pitch = pitch };
        public static SoundStyle FargoSound(string sound, float volume = 1, float pitchVar = 0) => new SoundStyle($"Fargowiltas/Sounds/{sound}") { Volume = volume, PitchVariance = pitchVar };
    }
}
