using YooAsset;

namespace ET
{
    public static class YooAssetInitHelper
    {
        private static EPlayMode mode = EPlayMode.HostPlayMode;

        public static async ETTask Start()
        {
#if UNITY_EDITOR
            mode = EPlayMode.EditorSimulateMode;
#else
            mode = EPlayMode.OfflinePlayMode;
#endif
            //mode = EPlayMode.OfflinePlayMode;
            if (mode == EPlayMode.EditorSimulateMode || mode == EPlayMode.OfflinePlayMode)
            {
                await YooAssetProxy.StartYooAssetEngine(mode);
            }
        }

        public static EPlayMode GetMode()
        {
            return mode;
        }

        public static bool IsEditor()
        {
            return mode == EPlayMode.EditorSimulateMode;
        }
    }
}