using UnityEngine;

namespace ET
{
    public static class MonoConstValue
    {
#if UNITY_EDITOR
        public const string MainUrl = "http://192.168.1.2:30300";
#elif UNITY_STANDALONE_WIN
        public static string MainUrl = "http://192.168.10.12:8899";
#else
        public static string MainUrl = "http://192.168.1.2:30300";
#endif
        public static string ShellPath = $"{Application.dataPath}/../../Sub/Tools/Shell";
    }
}