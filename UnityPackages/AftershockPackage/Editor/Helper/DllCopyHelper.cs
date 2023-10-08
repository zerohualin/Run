using System.IO;
using ET;
using HybridCLR.Editor.Commands;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;
using SerializationUtility = Sirenix.Serialization.SerializationUtility;

namespace HybridCLR.Editor
{
    public class DllCopyHelper
    {
        private const string FromPath = "../Unity/Assets/BundleYoo";
        private const string ToPath = "../SubGame";
        
        [MenuItem("HybridCLR/AotCopyToRes")]
        public static void DllCopyToRes()
        {
            var projDir = Path.GetDirectoryName(Application.dataPath);
            var dstPath = $"{projDir}/HybridCLRData/AssembliesPostIl2CppStrip/{EditorUserBuildSettings.activeBuildTarget}";
            
            var text = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/BundleYoo/AotDll/AOTDllList.json");
            AOTDllList dllNameListForAOT = SerializationUtility.DeserializeValue<AOTDllList>(text.bytes, DataFormat.JSON);
            
            foreach (var dllName in dllNameListForAOT.DLLNameList)
            {
                string targetDllFullName = $"{dstPath}/{dllName}";
                if (File.Exists(targetDllFullName))
                {
                    File.Copy($"{targetDllFullName}", $"Assets/BundleYoo/AotDll/{dllName}.bytes", true);
                }
                else
                {
                    Debug.LogError($"Not found aot dll {targetDllFullName}");
                }
            }
        }

        [MenuItem("HybridCLR/GenerateET/LinkXml", priority = 100)]
        public static void GenerateLinkXml()
        {
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            CompileDllCommand.CompileDll(target);
            LinkGeneratorCommand.GenerateLinkXml(target);
        }
        
        [MenuItem("HybridCLR/GenerateET/MethodBridge", priority = 101)]
        public static void GenerateMethodBridge()
        {
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            MethodBridgeGeneratorCommand.GenerateMethodBridge(target);
        }
        
        [MenuItem("HybridCLR/GenerateET/AOTGenericReference", priority = 102)]
        public static void CompileAndGenerateAOTGenericReference()
        {
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            AOTReferenceGeneratorCommand.GenerateAOTGenericReference(target);
        }
        
        [MenuItem("HybridCLR/GenerateET/ReversePInvokeWrapper", priority = 103)]
        public static void CompileAndGenerateReversePInvokeWrapper()
        {
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            ReversePInvokeWrapperGeneratorCommand.GenerateReversePInvokeWrapper(target);
        }
        
        [MenuItem("HybridCLR/GenerateET/Il2CppDef", priority = 104)]
        public static void GenerateIl2CppDef()
        {
            Il2CppDefGeneratorCommand.GenerateIl2CppDef();
        }
        
        [MenuItem("HybridCLR/GenerateET/AOTDlls", priority = 105)]
        public static void GenerateStripedAOTDlls()
        {
            StripAOTDllCommand.GenerateStripedAOTDlls(EditorUserBuildSettings.activeBuildTarget, EditorUserBuildSettings.selectedBuildTargetGroup);
        }
        
        [MenuItem("HybridCLR/GenerateET/All", priority = 200)]
        public static void GenerateAll()
        {
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            CompileDllCommand.CompileDll(target);
            
            AFKBuildHelper.BuildCodeAndCopyHot();
            
            Il2CppDefGeneratorCommand.GenerateIl2CppDef();

            // 这几个生成依赖HotUpdateDlls
            LinkGeneratorCommand.GenerateLinkXml(target);

            // 生成裁剪后的aot dll
            StripAOTDllCommand.GenerateStripedAOTDlls(target, EditorUserBuildSettings.selectedBuildTargetGroup);

            // 桥接函数生成依赖于AOT dll，必须保证已经build过，生成AOT dll
            MethodBridgeGeneratorCommand.GenerateMethodBridge(target);
            ReversePInvokeWrapperGeneratorCommand.GenerateReversePInvokeWrapper(target);
            AOTReferenceGeneratorCommand.GenerateAOTGenericReference(target);
            StripAOTDllCommand.GenerateStripedAOTDlls(EditorUserBuildSettings.activeBuildTarget, EditorUserBuildSettings.selectedBuildTargetGroup);
        }
    }
}