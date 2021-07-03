﻿namespace AncientMysteries
{
    public static class Rand
    {
        private static readonly Random rand = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Bool() =>
        (rand.Next() & 1) == 0;

        /// <summary>
        /// Negative value if random generated number is odd
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RandomNegative(this float value) =>
        (rand.Next() & 1) == 0
            ? value
            : -value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FloatRN(float min, float max) => Rando.Float(min, max).RandomNegative();
    }
}
