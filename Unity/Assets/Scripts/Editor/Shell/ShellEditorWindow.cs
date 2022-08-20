#if UNITY_EDITOR

using System.Diagnostics;
using ET;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ShellEditorWindow: OdinEditorWindow
{
    [OnValueChanged("CheckFolder")]
    public string ProjectName = "MiniGame";

    private void CheckFolder()
    {
        
    }
    
    [MenuItem("Tools/Shell")]
    private static void OpenWindow()
    {
        var window = GetWindow<ShellEditorWindow>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 200);
    }

    [Button("Unity To Sub", ButtonSizes.Gigantic)]
    private void UnityToSub()
    {
        ProcessCommandHelper.Invoke($"Sub/Unity2Sub.sh --MiniGameName={ProjectName}");
    }

    [Button("Sub To Unity", ButtonSizes.Medium)]
    private void SubToUnity()
    {
        ProcessCommandHelper.Invoke($"Sub/Sub2Unity.sh --MiniGameName={ProjectName}");
    }

    [Button("Delete", ButtonSizes.Medium)]
    private void Delete()
    {
        ProcessCommandHelper.Invoke($"Sub/Delete.sh --MiniGameName={ProjectName}");
    }
}
#endif