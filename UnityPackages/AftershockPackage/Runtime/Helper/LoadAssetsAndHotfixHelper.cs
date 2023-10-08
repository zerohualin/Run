using System;
using YooAsset;

namespace ET
{
    public static class LoadAssetsAndHotfix
    {
        static EPlayMode mode = EPlayMode.OfflinePlayMode;

        public static async ETTask Start()
        {
            var Mode = YooAssetInitHelper.GetMode();
            if(Mode == EPlayMode.HostPlayMode)
                await HotfixProcedureHelper.Start();
        }

        public static EPlayMode GetMode()
        {
            return mode;
        }
    }
}