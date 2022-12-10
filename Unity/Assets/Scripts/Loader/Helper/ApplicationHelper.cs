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
            if (Application.platform == RuntimePlatform.Android)
                return RuntimePlatform.Android.ToString();
            return "StandaloneOSX";
        }
    }
}