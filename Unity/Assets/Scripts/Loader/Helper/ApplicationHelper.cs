#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ET
{
    public class ApplicationHelper
    {
        public static void Quit()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public static string GetPlatName()
        {
            return GetPlatName(Application.platform);
        }
        
        public static string GetPlatName(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.Android:
                case RuntimePlatform.WindowsEditor:
                    return RuntimePlatform.Android.ToString();
                case RuntimePlatform.WindowsPlayer:
                    return "StandaloneWindows64";
                case RuntimePlatform.OSXPlayer:
                case RuntimePlatform.OSXEditor:
                    return "StandaloneOSX";
            }
            return "Android";
        }
#if UNITY_EDITOR
        public static string GetPlatName(BuildTarget BT)
        {
            if(BT == BuildTarget.Android)
                return GetPlatName(RuntimePlatform.Android);
            if(BT == BuildTarget.StandaloneWindows64)
                return GetPlatName(RuntimePlatform.WindowsPlayer);
            if(BT == BuildTarget.StandaloneOSX)
                return GetPlatName(RuntimePlatform.OSXPlayer);
            return GetPlatName(RuntimePlatform.WindowsPlayer);
        }
#endif
    }
}