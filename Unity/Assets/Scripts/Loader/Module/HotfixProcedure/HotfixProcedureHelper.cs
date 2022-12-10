
using UnityEngine;
using YooAsset;

namespace ET
{
    public enum VersionState
    {
        Success,
        GetVersionFail,
        NeedNewClient,
    }
    
    public static class HotfixProcedureHelper
    {

        public static async ETTask OnEnter()
        {
            FUIEntry.Init();
            FGUI_CheckForResUpdateComponent.Init(() => { });
            await ETTask.CompletedTask;
        }
        
        public static async ETTask RequestVersion(YooAssets.EPlayMode mode)
        {
            VersionState state = await FGUI_CheckForResUpdateComponent.GetVersionFromServer();
            if (state == VersionState.Success)
            {
                await YooAssetProxy.StartYooAssetEngine(mode);
            }

            if (state == VersionState.GetVersionFail)
            {
                FGUI_CheckWindowComponent.Init(() =>
                {
                    ApplicationHelper.Quit();
                }, () =>
                    {
                        RequestVersion(mode).Coroutine();
                    }, 
                    "获取最新资源版本失败!", "退出", "重试");
            }

            if (state == VersionState.NeedNewClient)
            {
                FGUI_CheckWindowComponent.Init(() => { ApplicationHelper.Quit(); }, () =>
                    {
                        string downloadUrl = "AssetURl";
                        Application.OpenURL(downloadUrl);
                        ApplicationHelper.Quit();
                    },
                    "当前客户端需要更新。\n是否前往下载最新客户端？",
                    "不要", "好的");
            }
        }
        
    }
}
