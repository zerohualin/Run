using System;
using HybridCLR.Editor;
using UnityEditor.Compilation;
using UnityEngine;

namespace ET
{
    public static class AFKBuildHelper
    {
        public static CodeOptimization codeOptimization = CodeOptimization.Debug;
        public static CodeMode CodeMode = CodeMode.Client;

        public static void BuildCodeAndCopyHot()
        {
            // if (Define.EnableCodes)
            // {
            //     throw new Exception("now in ENABLE_CODES mode, do not need Build!");
            // }
            // BuildHelper.EnableCodes(false);

            // GlobalConfig globalConfig = new GlobalConfig();
            // globalConfig.CodeMode = CodeMode;
            // BuildAssembliesHelper2.BuildModel(codeOptimization, globalConfig);
            // BuildAssembliesHelper2.BuildHotfix(codeOptimization, globalConfig);
            
            // BuildHelper.EnableCodes(true);
        }
    }
}