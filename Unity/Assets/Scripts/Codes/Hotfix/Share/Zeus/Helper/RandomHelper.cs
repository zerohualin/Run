using System;

namespace ET
{
    public static class RandomHelper
    {
        public static long NextLong(long x, long y)
        {
            Random random = new Random();
            return random.Next((int)(x), (int)(y));
        }
    }
}