using UnityEditor;
using UnityEngine;
using YooAsset.Editor;

public static class YoAssetBuildHelper
{
    private static BuildTarget BT = BuildTarget.StandaloneWindows64;
    private static EBuildMode EBuildMode = EBuildMode.ForceRebuild;
    private static int BuildVersion = 1;
    private static string OutputAssetPath = "";
    
    public static void BuildYooAssetFromCommand()
    {
        var BuildTargetStr = ShellCmdHelper.GetArg("BuildTarget");
        if (BuildTargetStr == "Android")
            BT = BuildTarget.Android;
            
        var BuildVersionStr = ShellCmdHelper.GetArg("BuildVersion");
        int.TryParse(BuildVersionStr, out BuildVersion);

        OutputAssetPath = ShellCmdHelper.GetArg("OutputAssetPath");
            
        var EBuildModeStr = ShellCmdHelper.GetArg("EBuildMode");
        if (EBuildModeStr == EBuildMode.ForceRebuild.ToString())
            EBuildMode = EBuildMode.ForceRebuild;
        if (EBuildModeStr == EBuildMode.IncrementalBuild.ToString())
            EBuildMode = EBuildMode.IncrementalBuild;

        BuildYooAssetInternel();
    }
        
    [MenuItem("YooAsset/Build")]
    public static void BuildYooAssetInternel()
    {
        Debug.Log($"开始构建");
            
        // 构建参数
        string projectPath = EditorTools.GetProjectPath();
        string defaultOutputRoot = OutputAssetPath;
        BuildParameters buildParameters = new BuildParameters();
        buildParameters.OutputRoot = defaultOutputRoot;
        buildParameters.BuildTarget = BT;
        buildParameters.BuildMode = EBuildMode;
        buildParameters.BuildVersion = BuildVersion;
        buildParameters.BuildinTags = "buildin";
        buildParameters.VerifyBuildingResult = true;
        buildParameters.EnableAddressable = true;
        buildParameters.CopyBuildinTagFiles = true;
        buildParameters.EncryptionServices = new GameEncryption();
        buildParameters.CompressOption = ECompressOption.LZ4;

        // 执行构建
        AssetBundleBuilder builder = new AssetBundleBuilder();
        builder.Run(buildParameters);
            
        Debug.Log($"构建完成");
    }
}
