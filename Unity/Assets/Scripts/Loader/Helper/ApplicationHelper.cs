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
            if (platform == RuntimePlatform.Android)
                return RuntimePlatform.Android.ToString();
            if (platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor)
                return "StandaloneWindows64";
            if (platform == RuntimePlatform.OSXPlayer || platform == RuntimePlatform.OSXEditor)
                return "StandaloneOSX";
            return "StandaloneOSX";
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