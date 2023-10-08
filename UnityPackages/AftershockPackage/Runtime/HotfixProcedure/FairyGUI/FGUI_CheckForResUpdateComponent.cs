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

            forResUpdate.ProgressBarDownload.visible = false;

            FUIManager_MonoOnly.AddUI(nameof(FGUI_CheckForResUpdate), forResUpdate);

            YooAssetProxy.InitHostCallbacks((onStateChanged) =>
            {
                forResUpdate.TextProgress.text = onStateChanged.CurrentStates.ToString();

                if (onStateChanged.CurrentStates == EPatchStates.PatchDone)
                {
                    forResUpdate.TextProgress.text = "资源下载完毕，正在加载核心逻辑。。。";
                    if (finishAct != null)
                        finishAct();
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

        public static void CheckVersion()
        {
            forResUpdate.TextProgress.text = "版本检查中";
            forResUpdate.ProgressBarDownload.visible = false;
        }

        public static void Release()
        {
            FUIManager_MonoOnly.RemoveUI(nameof(FGUI_CheckForResUpdate));
            FUIEntry.RemovePackage_MonoOnly("CheckForResUpdate");
        }
    }
}
