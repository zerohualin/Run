using System;
using System.Collections.Generic;
using System.IO;
using HybridCLR.Editor;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;
using YooAsset.Editor;

namespace ET
{
    public static class YooBuildHelper
    {
        static string VersionName = "";
        private static string PlatName = "";
        static string ProductName = "";
        public static BuildTarget BT;
        public static EBuildMode EBuildMode;

        public static string BuildFolder = "../Release/{0}/{1}/";

        public static void BuildFormCammond()
        {
            VersionName = GetShellCmdArg("VersionName");
            PlatName = GetShellCmdArg("PlatName");
            ProductName = GetShellCmdArg("ProductName");
            Build();
        }

        public static void Build_Dev_MacOS()
        {
            VersionName = "Dev";
            PlatName = GetPlatName();
            ProductName = "FromSky";
            Build();
        }

        public static void Build_Release_Android()
        {
            VersionName = "Release";
            PlatName = "Android";
            ProductName = "FromSky.apk";
            Build();
        }

        public static void Build()
        {
            BuildTarget buildTarget = GetBuildTargetByName(PlatName);

            string fold = string.Format(BuildFolder, VersionName, PlatName);
            if (!Directory.Exists(fold))
            {
                Directory.CreateDirectory(fold);
            }

            SetICon(VersionName);

            AssetDatabase.Refresh();

            string[] levels = GetLevelsFromBuildSettings();
            Log.Info("Unity: 开始 Build Client");

            BuildOptions buildOptions = BuildOptions.AllowDebugging | BuildOptions.ConnectWithProfiler |
                    BuildOptions.AutoRunPlayer | BuildOptions.Development |
                    BuildOptions.EnableDeepProfilingSupport;

            buildOptions = BuildOptions.None;
            BuildPipeline.BuildPlayer(levels, $"{fold}/{ProductName}", buildTarget, buildOptions);

            Log.Info("Unity: 完成 Build Client");
        }

        public static void SetICon(string VersionName)
        {
            var texture =
                    (Texture2D)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Pictures/AppIcon/AppIcon-{VersionName}.png", typeof (Texture2D));
            var texs = new[] { texture, texture, texture, texture, texture, texture, texture, texture };
            PlayerSettings.SetIcons(NamedBuildTarget.Standalone, texs, IconKind.Any);
        }

        public static void SetBuildInfo(string vName)
        {
            // string path = $"Assets/Resources/BuildInfo.txt";
            // var handle = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
            // var versionJson = handle.text;
            // BuildInfo buildInfo = JsonUtility.FromJson<BuildInfo>(versionJson);
            //
            // if (vName == "Dev")
            // {
            //     buildInfo.AssetUrl = "http://192.168.0.109:1234";
            // }
            //
            // if (vName == "Release")
            // {
            //     buildInfo.AssetUrl = "https://formsky.oss-cn-hangzhou.aliyuncs.com";
            // }
            //
            // var json = JsonUtility.ToJson(buildInfo);
            //
            // var filePath = Application.dataPath.Replace("Assets", path);
            // File.WriteAllText(filePath, json);
        }

        public static void SettScriptingDefineSymbols(BuildTargetGroup btg)
        {
            string[] defineSymbols = { "NET452", "THREAD_SAFE", };
            PlayerSettings.SetScriptingDefineSymbolsForGroup(btg, defineSymbols);
            switch (btg)
            {
                case BuildTargetGroup.Android:
                    EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
                    break;
                case BuildTargetGroup.Standalone:
                    EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.StandaloneWindows64);
                    break;
            }
        }

        [MenuItem("Tools/Bundle Exe")]
        public static void BundleExe()
        {
            var nowTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
            SettScriptingDefineSymbols(BuildTargetGroup.Standalone);
            // BuildScript.BuildBundles();
            AssetDatabase.Refresh();
            SettScriptingDefineSymbols(nowTarget);
        }

        [MenuItem("Tools/Bundle Apk")]
        public static void BundleApk()
        {
            var nowTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
            SettScriptingDefineSymbols(BuildTargetGroup.Android);

            AssetDatabase.Refresh();

            // BuildScript.BuildBundles();

            AssetDatabase.Refresh();
            SettScriptingDefineSymbols(nowTarget);
        }

        [MenuItem("Tools/DefineSymbols")]
        public static void SettScriptingDefineSymbolsPc()
        {
            SettScriptingDefineSymbols(EditorUserBuildSettings.selectedBuildTargetGroup);
        }

        public static string[] GetLevelsFromBuildSettings()
        {
            List<string> scenes = new List<string>();
            scenes.Add("Assets/GameMain/Scenes/Entry.unity");
            scenes.Add("Assets/GameMain/Scenes/PreScene.unity");
            scenes.Add("Assets/GameMain/Scenes/MainScene.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/00_test.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/01_test.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/1.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/2.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/3.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/4.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/5.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/6.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/7.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/8.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/9.unity");
            scenes.Add("Assets/GameMain/Scenes/Battle/10.unity");
            return scenes.ToArray();
        }

        public static string GetShellCmdArg(string argName)
        {
            {
#if UNITY_EDITOR
                //在这里分析shell传入的参数， 还记得上面我们说的哪个 project-$1 这个参数吗？
                //这里遍历所有参数，找到 project开头的参数， 然后把-符号 后面的字符串返回，
                foreach (string arg in System.Environment.GetCommandLineArgs())
                {
                    if (arg.StartsWith(argName))
                    {
                        return arg.Split("="[0])[1];
                    }
                }
#endif
            }
            Debug.LogError($"这个参数未输入！ {argName}");
            return "";
        }

        public static BuildTarget GetBuildTargetByName(string plat)
        {
            BuildTarget buildTarget = BuildTarget.StandaloneOSX;
            if (plat == "MacOS")
            {
                buildTarget = BuildTarget.StandaloneOSX;
            }
            else if (plat == "Win")
            {
                buildTarget = BuildTarget.StandaloneWindows64;
            }
            else if (plat == "Android")
            {
                buildTarget = BuildTarget.Android;
            }

            return buildTarget;
        }

        public static string GetPlatName()
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                PlatName = "MacOS";
            }
            else
            {
                PlatName = "Win";
            }

            return PlatName;
        }

        public static void BuildFromCommand()
        {
            var BuildTargetStr = GetShellCmdArg("BuildTarget");
            if (BuildTargetStr == "Android")
                BT = BuildTarget.Android;
            if (BuildTargetStr == "StandaloneWindows64")
                BT = BuildTarget.StandaloneWindows64;
            
            var EBuildModeStr = GetShellCmdArg("EBuildMode");
            if (EBuildModeStr == EBuildMode.ForceRebuild.ToString())
                EBuildMode = EBuildMode.ForceRebuild;
            if (EBuildModeStr == EBuildMode.IncrementalBuild.ToString())
                EBuildMode = EBuildMode.IncrementalBuild;
            
            BuildYooAssetInternel();
        }

        public static void BuildYooAssetInternel()
        {
            Debug.Log($"开始构建");

            // 构建参数
            string projectPath = EditorTools.GetProjectPath();
            string defaultOutputRoot = $"{projectPath}/../Sub/YooResult";
            BuildParameters buildParameters = new BuildParameters();
            buildParameters.PackageName = "DefaultPackage";
            buildParameters.OutputRoot = defaultOutputRoot;
            buildParameters.BuildTarget = BT;
            buildParameters.BuildMode = EBuildMode;
            buildParameters.PackageVersion = DateTime.Now.ToString("yyyy_MMdd_HHmm_ss");
            buildParameters.VerifyBuildingResult = true;
            buildParameters.EncryptionServices = new GameEncryption();
            buildParameters.CompressOption = ECompressOption.LZ4;
            
            // 执行构建
            AssetBundleBuilder builder = new AssetBundleBuilder();
            builder.Run(buildParameters);

            // ChangeVersionFile(BT, buildParameters.PackageVersion);

            Debug.Log($"Finish!!!!!");
            Debug.Log($"Output Path： {defaultOutputRoot}");
        }

        public static void AutoUpdate(BuildTarget BuildTarget, int VersionCode = -1)
        {
            YooBuildHelper.BT = BuildTarget;
            EBuildMode = EBuildMode.IncrementalBuild;
            BuildYooAssetInternel();
        }
    }
}