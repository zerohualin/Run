#if UNITY_EDITOR

using System.Diagnostics;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

public class LubanEditorWindow: OdinEditorWindow
{
    [MenuItem("Tools/Luban/Export")]
    private static void OpenWindow()
    {
        var window = GetWindow<LubanEditorWindow>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 200);
    }
    
    [Button("Luban Export", ButtonSizes.Gigantic)]
    private void LubanExport()
    {
        Process.Start(Application.dataPath + "/../../Tools/LuBan一键生成配置WIN.bat");
    }
}
#endif