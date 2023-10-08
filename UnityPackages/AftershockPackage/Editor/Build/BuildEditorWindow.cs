#if UNITY_EDITOR

using System.IO;
using ET;
using HybridCLR.Editor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using YooAsset.Editor;

public class BuildEditorWindow: OdinEditorWindow
{
    public BuildTarget BuildTarget;

    public int VersionCode = 0;

    private void CheckFolder()
    {
    }

    protected override void OnEnable()
    {
        BuildTarget activePlatform = BuildTarget.StandaloneWindows64;
#if UNITY_ANDROID
			activePlatform = BuildTarget.Android;
#elif UNITY_IOS
			activePlatform = PlatformType.IOS;
#elif UNITY_STANDALONE_WIN
        activePlatform = BuildTarget.StandaloneWindows64;
#elif UNITY_STANDALONE_OSX
			activePlatform = BuildTarget.StandaloneOSX;
#else
			activePlatform = PlatformType.None;
#endif
        BuildTarget = activePlatform;
    }

    [MenuItem("Build/OpenWindow")]
    private static void OpenWindow()
    {
        var window = GetWindow<BuildEditorWindow>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 200);
    }

    [Button("YooBuild", ButtonSizes.Large)]
    private void YooBuild()
    {
        YooBuildHelper.BT = BuildTarget;
        YooBuildHelper.EBuildMode = EBuildMode.ForceRebuild;
        YooBuildHelper.BuildYooAssetInternel();
    }

    [Button("BuildCodeAndCopyHot", ButtonSizes.Gigantic)]
    private void Compile()
    {
        AFKBuildHelper.BuildCodeAndCopyHot();
    }

    [Button("YooUpdate", ButtonSizes.Gigantic)]
    private void YooUpdate()
    {
        YooBuildHelper.AutoUpdate(BuildTarget, this.VersionCode);
    }

    [Button("SyncYoo2Oss", ButtonSizes.Gigantic)]
    private void SyncYoo2Oss()
    {
        // ShellHelper.Run($"sh Sync/SyncYooHttpServerToOss.sh", MonoConstValue.ShellPath);
        ShellHelper.Run($"sh Sync/SyncYooResultToOss.sh", MonoConstValue.ShellPath);
    }
    
    [Button("SyncApk2Oss", ButtonSizes.Gigantic)]
    private void SyncApk2Oss()
    {
        ShellHelper.Run($"sh CopyApk.sh", MonoConstValue.ShellPath);
        ShellHelper.Run($"sh SyncYooResultToOss.sh", MonoConstValue.ShellPath);
    }
}
#endif