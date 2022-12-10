using YooAsset;

namespace ET
{
    public static class YooAssetInitHelper
    {
        static YooAssets.EPlayMode mode = YooAssets.EPlayMode.OfflinePlayMode;

        public static async ETTask Start()
        {
#if UNITY_EDITOR
            mode = YooAssets.EPlayMode.EditorSimulateMode;
#endif
            
            if (mode == YooAssets.EPlayMode.EditorSimulateMode || mode == YooAssets.EPlayMode.OfflinePlayMode)
            {
                await YooAssetProxy.StartYooAssetEngine(mode);
            }
        }

        public static YooAssets.EPlayMode GetMode()
        {
            return mode;
        }
    }
}