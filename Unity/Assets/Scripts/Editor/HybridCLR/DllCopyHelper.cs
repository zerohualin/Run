using System.Collections.Generic;
using System.IO;
using ET;
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
        
        [MenuItem("HybridCLR/DllCopyToRes")]
        public static void DllCopyToRes()
        {
            var projDir = Path.GetDirectoryName(Application.dataPath);
            var dstPath = $"{projDir}/HybridCLRData/AssembliesPostIl2CppStrip/{EditorUserBuildSettings.activeBuildTarget}";

            DLLNameListForAOT dllNameListForAOT = SerializationUtility.DeserializeValue<DLLNameListForAOT>( AssetDatabase
                    .LoadAssetAtPath<TextAsset>("Assets/BundleYoo/OtherNativeRes/DLLNameListForAOT.json").bytes, DataFormat.JSON);
            
            foreach (var dllName in dllNameListForAOT.DLLNameList_Raw)
            {
                string targetDllFullName = $"{dstPath}/{dllName}";
                if (File.Exists(targetDllFullName))
                {
                    File.Copy($"{targetDllFullName}", $"Assets/BundleYoo/AotDll/{dllName}.bytes", true);
                }
            }
        }


        [MenuItem("HybridCLR/HotfixToRes")]
        public static void HotfixToRes()
        {
            var projDir = Path.GetDirectoryName(Application.dataPath);
            var dstPath = $"{projDir}/HybridCLRData/HotFixDlls/{EditorUserBuildSettings.activeBuildTarget}";
            File.Copy($"{dstPath}/Unity.Codes.dll", $"Assets/Bundles/Code/Unity.Codes.dll.bytes", true);
            File.Copy($"{dstPath}/Unity.Codes.pdb", $"Assets/Bundles/Code/Unity.Codes.pdb.bytes", true);
        }
    }
}