using System;

namespace DSA___A2___Part_Soution
{
    internal class SplitMix64
    {
        private ulong state;

        public SplitMix64()
        {
            state = (ulong)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public ulong Next(ulong min, ulong max)
        {
            ulong z = state + 0x9E3779B97F4A7C15UL;
            state = z;

            z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
            z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
            z = z ^ (z >> 31);

            ulong range = max - min + 1;
            z = z % range + min;
            return z;
        }
    }
}
