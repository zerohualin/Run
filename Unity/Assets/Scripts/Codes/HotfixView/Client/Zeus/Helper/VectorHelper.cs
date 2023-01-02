using UnityEngine;

namespace ET
{
    public static class VectorHelper
    {
        public static Vector2 ToV2(this Vector3 v3)
        {
            return new Vector2(v3.x, v3.y);
        }

        public static Vector3 ToV3(this Vector2 v2)
        {
            return new Vector3(v2.x, v2.y, 0);
        }
    }
}