using System;
using HybridCLR;
using Sirenix.Serialization;
using UnityEngine;
using YooAsset;

namespace ET
{
    public class AotCodeHelper
    {
        // 加载热更层代码
        public static async ETTask LoadAotCode()
        {
            // wolong补充元数据用
            if (Define.IsEditor)
                return;

            HomologousImageMode mode = HomologousImageMode.SuperSet;
            
            var DllNameList = YooAssetProxy.Default.LoadRawFileSync("AOTDllList");
            byte[] config = DllNameList.GetRawFileData();
            Log.Info($"DLLNameListForAOT bytes length {config.Length.ToString()}");
            
            AOTDllList aOTDllList = SerializationUtility.DeserializeValue<AOTDllList>(config, DataFormat.JSON);
            
            if(aOTDllList == null)
                Log.Error("dllNameListForAOT Is Null");
            
            foreach (var aotDllName in aOTDllList.DLLNameList)
            {
                // Debug.Log($"添加{aotDll}");
                RawFileOperationHandle RawFileOperation = YooAssetProxy.Default.LoadRawFileSync($"{aotDllName}");
                if (RawFileOperation == null)
                {
                    Log.Error($"这个不存在 {aotDllName}");
                }
                else
                {
                    var bytes = RawFileOperation.GetRawFileData();
                    if (bytes != null)
                    {
                        LoadImageErrorCode err = RuntimeApi.LoadMetadataForAOTAssembly(bytes, mode);
                        Debug.Log($"LoadMetadataForAOTAssembly:{aotDllName}. mode:{mode} ret:{err}");
                    }
                }
            }
            
            Log.Info($"Finish All LoadMetadataForAOTAssembly");
        }
    }
}