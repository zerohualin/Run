#if UNITY_EDITOR

using System.Diagnostics;
using ET;
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
#if UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
        ShellHelper.Run($"sh GenLuban.sh", "../Sub/Tools/Shell/");
#elif UNITY_EDITOR_WIN
        Process.Start(Application.dataPath + "/../../Sub/Tools/LuBan一键生成配置WIN.bat");
#endif
        AssetDatabase.Refresh();
    }
    
    // [Button("公式导出", ButtonSizes.Large)]
    private void ExportFormulua()
    {
        Process.Start($"{Application.dataPath}/../../Sub/Tools/DotnetTool.bat");
        AssetDatabase.Refresh();
    }
}
#endif