using System;

namespace ET
{
    public class Pow
    {
        public float Value;
        public Pow(float v)
        {
            this.Value = v;
        }
        public static float operator*(float p1, Pow p2)
        {
            float result = (float)Math.Pow(p1,  p2.Value);
            return result;
        }
        public static float operator*(int p1, Pow p2)
        {
            float result = (float)Math.Pow(p1,  p2.Value);
            return result;
        }
    }
}