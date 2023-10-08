using System.Collections.Generic;
using UnityEngine.SceneManagement;
using YooAsset;

namespace ET
{
    public static class YooResourcePackageProxy
    {
        public static ETTask<AssetOperationHandle> LoadAssetETAsync<T>(this AssetsPackage package, string path) where T : UnityEngine.Object
        {
            ETTask<AssetOperationHandle> result = ETTask<AssetOperationHandle>.Create();
            AssetOperationHandle assetOperationHandle = package.LoadAssetAsync<T>(path);
            assetOperationHandle.Completed += handle => { result.SetResult(handle); };
            return result;
        }

        public static ETTask<SubAssetsOperationHandle> LoadSubAssetsAsync<T>(this AssetsPackage package, string mainAssetPath, string subAssetName)
                where T : UnityEngine.Object
        {
            ETTask<SubAssetsOperationHandle> result = ETTask<SubAssetsOperationHandle>.Create();
            SubAssetsOperationHandle subAssetsOperationHandle = package.LoadSubAssetsAsync<T>(mainAssetPath);
            subAssetsOperationHandle.Completed += handle => { result.SetResult(handle); };
            return result;
        }
        
        public static ETTask<SceneOperationHandle> LoadSceneETAsync(this AssetsPackage package, string scenePath, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            ETTask<SceneOperationHandle> result = ETTask<SceneOperationHandle>.Create();
            SceneOperationHandle sceneOperationHandle = package.LoadSceneAsync(scenePath, loadSceneMode, true);
            sceneOperationHandle.Completed += handle => { result.SetResult(sceneOperationHandle); };
            return result;
        }
        
        public static ETTask<RawFileOperationHandle> GetRawFileAsync(this AssetsPackage package, string path)
        {
            ETTask<RawFileOperationHandle> result = ETTask<RawFileOperationHandle>.Create();
            RawFileOperationHandle rawFileOperation = package.LoadRawFileAsync(path);
            rawFileOperation.Completed += handle => { result.SetResult(rawFileOperation); };
            return result;
        }
        
        public static List<string> GetAssetPathsByTag(this AssetsPackage package, string tag)
        {
            AssetInfo[] assetInfos = package.GetAssetInfos(tag);
            List<string> result = new List<string>(16);
            foreach (var assetInfo in assetInfos)
            {
                result.Add(assetInfo.Address);
            }
            return result;
        }
    }
}
