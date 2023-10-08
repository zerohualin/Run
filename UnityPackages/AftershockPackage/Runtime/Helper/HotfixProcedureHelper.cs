using System.Collections.Generic;
using System.Threading.Tasks;
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
        public static string LauchDownLoadUrl;
        static TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

        public static async ETTask Start()
        {
            FUIEntry.Init();

            FGUI_CheckForResUpdateComponent.Init(() => { });

            await RequestVersion();
            
            FGUI_CheckForResUpdateComponent.Release();

            tcs = new TaskCompletionSource<bool>();
            await tcs.Task;
        }

        public static void SetFinish()
        {
            tcs.SetResult(true);
        }
        
        public partial class HttpGetConfigResponse: ProtoObject
        {
            [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
            public Dictionary<string, string> KV { get; set; }
        }

        public static async ETTask<VersionState> GetVersionFromServer()
        {
            string versionResultJson = await CoroutineHelper.HttpGet($"{MonoConstValue.MainUrl}/GetConfig");
            
            if (versionResultJson == "")
                return VersionState.GetVersionFail;
            
            // var response = JsonHelper.FromJson<HttpGetConfigResponse>(versionResultJson);
            //
            // bool t = response.KV.TryGetValue("LaunchDownloadUrl", out YooAssetProxy.LaunchDownloadUrl);
            // if (!t)
            //     Log.Error("Get LaunchDownloadUrl Fail 。");
            //
            // t = response.KV.TryGetValue("LaunchVersion", out string LaunchVersion);
            // if (!t)
            //     Log.Error("Get LaunchVersion Fail 。");
            //
            // if (LaunchVersion != Application.version)
            // {
            //     return VersionState.NeedNewClient;
            // }
            //
            // t = response.KV.TryGetValue("BundleMainUrl", out YooAssetProxy.BundleMainUrl);
            // if (!t)
            //     Log.Error("Get BundleMainUrl Fail 。");
            //
            // YooAssetProxy.BundleVersionDic = new Dictionary<string, string>();
            // foreach (var VARIABLE in  response.KV)
            // {
            //     if(VARIABLE.Key.Contains("BundleVersion"))
            //         YooAssetProxy.BundleVersionDic.Add(VARIABLE.Key, VARIABLE.Value);
            // }
            return VersionState.Success;
        }

        public static async ETTask RequestVersion()
        {
            VersionState state = await GetVersionFromServer();

            switch (state)
            {
                case VersionState.GetVersionFail:
                    FGUI_CheckWindowComponent.Init(() => { ApplicationHelper.Quit(); }, () => { RequestVersion().Coroutine(); },
                        "获取最新资源版本失败!", "退出", "重试");
                    break;
                case VersionState.Success:
                    await YooAssetProxy.StartYooAssetEngine(EPlayMode.HostPlayMode);
                    break;
                case VersionState.NeedNewClient:
                    FGUI_CheckWindowComponent.Init(() => { ApplicationHelper.Quit(); }, () =>
                        {
                            Application.OpenURL(LauchDownLoadUrl);
                            ApplicationHelper.Quit();
                        },
                        "当前客户端需要更新。\n是否前往下载最新客户端？",
                        "不要", "好的");
                    break;
            }
        }
    }
}