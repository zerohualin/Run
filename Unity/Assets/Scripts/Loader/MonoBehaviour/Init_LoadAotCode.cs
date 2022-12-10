// --------------------------
// 作者：烟雨迷离半世殇
// 邮箱：1778139321@qq.com
// 日期：2022年7月10日, 星期日
// --------------------------

using System;
using System.Collections.Generic;
using HybridCLR;
using Sirenix.Serialization;
using UnityEngine;
using YooAsset;

namespace ET
{
    public partial class Init
    {
        // 加载热更层代码
        private async ETTask LoadAotCode()
        {
            try
            {
                var DllNameList = await YooAssetProxy.GetRawFileAsync("Config_DLLNameListForAOT");
                byte[] config = DllNameList.LoadFileData();
                DLLNameListForAOT dllNameListForAOT =
                        SerializationUtility.DeserializeValue<DLLNameListForAOT>(config, DataFormat.JSON);
            
                List<RawFileOperation> rawFileOperations = new List<RawFileOperation>();
                foreach (var aotDll in dllNameListForAOT.DLLNameList_ForABLoad)
                {
                    // Debug.Log($"添加{aotDll}");
                    RawFileOperation RawFileOperation = await YooAssetProxy.GetRawFileAsync(aotDll);
                    if (RawFileOperation == null)
                    {
                        // Log.Error($"这个不存在 {aotDll}");
                    }
                    else
                    {
                        var bytes = RawFileOperation.GetRawBytes();
                        if (bytes != null)
                        {
                            // Debug.Log($"加载AOT补充元数据 {aotDll}");
                            LoadMetadataForAOTAssembly(bytes);
                        }
                        else
                        {
                            // Debug.Log($"AOT资源加载失败！");
                        }
                    }
                }
                
                static unsafe void LoadMetadataForAOTAssembly(byte[] dllBytes)
                {
                    fixed (byte* ptr = dllBytes)
                    {
#if !UNITY_EDITOR
                // 加载assembly对应的dll，会自动为它hook。一旦aot泛型函数的native函数不存在，用解释器版本代码
                int err = RuntimeApi.LoadMetadataForAOTAssembly((IntPtr)ptr, dllBytes.Length);
                Debug.Log("LoadMetadataForAOTAssembly. ret:" + err);
#endif
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}