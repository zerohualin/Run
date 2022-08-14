using System;
using YooAssetEx;

namespace ET
{
    public class FGUI_CheckForResUpdateComponent 
    {
             private static FGUI_CheckForResUpdate forResUpdate;

        public static void Init(Action finishAct)
        {
            FUIEntry.LoadPackage_MonoOnly("CheckForResUpdate");

            FGUI_CheckForResUpdateBinder.BindAll();
            forResUpdate = FGUI_CheckForResUpdate.CreateInstance();
            forResUpdate.MakeFullScreen();
            forResUpdate.ProgressBarDownload.max = 1;
            forResUpdate.ProgressBarDownload.value = 0;

            FUIManager_MonoOnly.AddUI(nameof(FGUI_CheckForResUpdate), forResUpdate);

            YooAssetProxy.InitHostCallbacks((onStateChanged) =>
            {
                forResUpdate.TextProgress.text = onStateChanged.CurrentStates.ToString();

                if (onStateChanged.CurrentStates == EPatchStates.PatchDone)
                {
                    forResUpdate.TextProgress.text = "资源下载完毕，正在加载核心逻辑。。。";
                    if (finishAct != null)
                        finishAct();

                    Release();
                    return;
                }
            }, (onProcessUpdated) =>
            {
                string currentSizeMB = (onProcessUpdated.CurrentDownloadSizeBytes / 1048576f).ToString("f1");
                string totalSizeMB = (onProcessUpdated.TotalDownloadSizeBytes / 1048576f).ToString("f1");
                string text =
                    $"资源下载中：{onProcessUpdated.CurrentDownloadCount}/{onProcessUpdated.TotalDownloadCount} {currentSizeMB}MB/{totalSizeMB}MB";

                forResUpdate.TextProgress.text = text;
                forResUpdate.ProgressBarDownload.visible = true;
                forResUpdate.ProgressBarDownload.value = onProcessUpdated.CurrentDownloadSizeBytes * 1.0f /
                    onProcessUpdated.TotalDownloadSizeBytes * 100;
            });
        }

        public static void Release()
        {
            FUIManager_MonoOnly.RemoveUI(nameof(FGUI_CheckForResUpdate));
            FUIEntry.RemovePackage_MonoOnly("CheckForResUpdate");
        }

        public static async ETTask<VersionState> GetVersionFromServer()
        {
            forResUpdate.TextProgress.text = "版本检查中";
            forResUpdate.ProgressBarDownload.visible = false;
            string AccountServerUrl = "asdfasdf";
            string versionResultJson = await MonoOnlyHttpHelper.Request($"http://{AccountServerUrl}version");
            // var VersionResult = JsonHelper.FromJson(versionResultJson);
            // if ((int) VersionResult["code"] == 0)
            // {
            //     int BigVersion = (int) VersionResult["data"]["big"];
            //     if (BigVersion > 111)
            //     {
            //         return VersionState.NeedNewClient;
            //     }
            //
            //     YooAssetProxy.GameVerion = (int) VersionResult["data"]["small"];
            //     return VersionState.Success;
            // }
            // else
            // {
            //     return VersionState.GetVersionFail;
            // }
            await ETTask.CompletedTask;
            return VersionState.Success;
        }
    }
}
