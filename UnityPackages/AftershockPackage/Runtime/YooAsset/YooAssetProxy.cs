using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using YooAssetEx;
using YooAsset;

namespace ET
{
    public static class YooAssetProxy
    {
        public static AssetsPackage Default
        {
            get
            {
                return YooAssets.GetAssetsPackage("DefaultPackage");
            }
        }
        
        public static AssetsPackage Zeus
        {
            get
            {
                return YooAssets.GetAssetsPackage("Zeus");
            }
        }

        private static AssetsPackage nowPackage;
        public static AssetsPackage NowPackage
        {
            get
            {
                return nowPackage;
            }
            set
            {
                nowPackage = value;
            }
        }
        
        public static string LaunchDownloadUrl = "";
        public static string BundleMainUrl = "";
        public static Dictionary<string, string> BundleVersionDic;

        #region Extension

        public static T GetAsset<T>(this AssetOperationHandle assetOperationHandle)
                where T : UnityEngine.Object
        {
            return assetOperationHandle.AssetObject as T;
        }

        public static T GetSubAsset<T>(this SubAssetsOperationHandle assetOperationHandle, string subAssetName)
                where T : UnityEngine.Object
        {
            return assetOperationHandle.GetSubAssetObject<T>(subAssetName);
        }

        public static byte[] GetRawFileData(this RawFileOperationHandle rawFileOperation)
        {
            return rawFileOperation.GetRawFileData();
        }

        public static string GetRawFileText(this RawFileOperationHandle rawFileOperation)
        {
            return rawFileOperation.GetRawFileText();
        }

        #endregion

        #region API
        
        public static ETTask<AssetOperationHandle> LoadAssetAsync<T>(string path) where T : UnityEngine.Object
        {
            ETTask<AssetOperationHandle> result = ETTask<AssetOperationHandle>.Create();
            AssetOperationHandle assetOperationHandle = YooAssets.LoadAssetAsync<T>(path);
            assetOperationHandle.Completed += handle => { result.SetResult(handle); };
            return result;
        }

        public static ETTask<SubAssetsOperationHandle> LoadSubAssetsAsync<T>(string mainAssetPath, string subAssetName)
            where T : UnityEngine.Object
        {
            ETTask<SubAssetsOperationHandle> result = ETTask<SubAssetsOperationHandle>.Create();
            SubAssetsOperationHandle subAssetsOperationHandle = YooAssets.LoadSubAssetsAsync<T>(mainAssetPath);
            subAssetsOperationHandle.Completed += handle => { result.SetResult(handle); };
            return result;
        }

        public static ETTask<SceneOperationHandle> LoadSceneAsync(string scenePath,
            LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            ETTask<SceneOperationHandle> result = ETTask<SceneOperationHandle>.Create();
            SceneOperationHandle sceneOperationHandle = YooAssets.LoadSceneAsync(scenePath, loadSceneMode, true);
            sceneOperationHandle.Completed += handle => { result.SetResult(sceneOperationHandle); };
            return result;
        }

        // public static ETTask<RawFileOperationHandle> GetRawFileAsync(string path)
        // {
        //     ETTask<RawFileOperationHandle> result = ETTask<RawFileOperationHandle>.Create();
        //     RawFileOperationHandle rawFileOperation = YooAssets.LoadRawFileAsync(path);
        //     rawFileOperation.Completed += handle => { result.SetResult(rawFileOperation); };
        //     return result;
        // }

        public static List<string> GetAssetPathsByTag(string tag)
        {
            AssetInfo[] assetInfos = YooAssets.GetAssetInfos(tag);
            List<string> result = new List<string>(16);
            foreach (var assetInfo in assetInfos)
            {
                result.Add(assetInfo.Address);
            }

            return result;
        }
        
        public static void InitHostCallbacks(Action<PatchEventMessageDefine.PatchStatesChange> onStateUpdate,
        Action<PatchEventMessageDefine.DownloadProgressUpdate> onDownLoadProgressUpdate)
        {
            PatchUpdater.InitCallback(onStateUpdate, onDownLoadProgressUpdate);
        }

        public static async ETTask StartYooAssetEngine(EPlayMode playMode)
        {
            // 初始化资源系统
            YooAssets.Initialize();

            var defaultPackage = await UpdatePackage(playMode, "DefaultPackage");

            var zeusPackage = await UpdatePackage(playMode, "Zeus");
            
            Log.Info("FINISH All Package");
        }

        public static async ETTask<AssetsPackage> UpdatePackage(EPlayMode playMode, string packageName)
        {
            // // 创建默认的资源包
            // var package = YooAssets.CreatePackage(packageName);
            //
            // YooAssets.SetDefaultPackage(package);
            // NowPackage = package;
            //
            // ETTask etTask = ETTask.Create();
            //
            // // 编辑器下的模拟模式
            // if (playMode == EPlayMode.EditorSimulateMode)
            // {
            //     var initParameters = new EditorSimulateModeParameters();
            //     initParameters.SimulateManifestFilePath = EditorSimulateModeHelper.SimulateBuild(packageName);
            //     package.InitializeAsync(initParameters).Completed += _ => { etTask.SetResult(); };
            // }
            //
            // // 单机运行模式
            // if (playMode == EPlayMode.OfflinePlayMode)
            // {
            //     var initParameters = new OfflinePlayModeParameters();
            //     package.InitializeAsync(initParameters).Completed += _ => { etTask.SetResult(); };
            // }
            //
            // // 联机运行模式
            // if (playMode == EPlayMode.HostPlayMode)
            // {
            //     var initParameters = new HostPlayModeParameters();
            //     initParameters.QueryServices = new QueryStreamingAssetsFileServices();
            //     initParameters.DecryptionServices = null;
            //     initParameters.DefaultHostServer = GetHostServerURL();
            //     initParameters.FallbackHostServer = GetHostServerURL();
            //
            //     string GetHostServerURL()
            //     {
            //         string platName = ApplicationHelper.GetPlatName();
            //         string bundleVersion = BundleVersionDic[$"{packageName}BundleVersion"];
            //         return $"{BundleMainUrl}/{platName}/{packageName}/{bundleVersion}";
            //     }
            //
            //     Log.Info($"YooAsset ServerURL : {initParameters.DefaultHostServer}");
            //
            //     // 如果是资源热更模式，则需要等待热更完毕后再Invoke回调
            //     package.InitializeAsync(initParameters).Completed += _ =>
            //     {
            //         // 运行补丁流程
            //         PatchUpdater.Run(etTask);
            //     };
            // }
            //
            // await etTask;
            //
            // return package;
            return null;
        }

        #endregion
    }
}