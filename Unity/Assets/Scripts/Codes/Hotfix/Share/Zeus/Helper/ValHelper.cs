// using Sirenix.Utilities;

namespace ET
{
    public static class ValHelper
    {
        public static float ToFloat(string Val)
        {
            bool t = float.TryParse(Val, out float f);
            if (t)
                return f;
            if(string.IsNullOrEmpty(Val))
                return 1;
            Log.Error($"这不是一个合法的 float {Val}");
            return 1;
        }
        
        public static int ToInt(string Val)
        {
            bool t = int.TryParse(Val, out int f);
            if (t)
                return f;
            if(string.IsNullOrEmpty(Val))
                return 0;
            Log.Error($"这不是一个合法的 int {Val}");
            return -1;
        }
    }
}