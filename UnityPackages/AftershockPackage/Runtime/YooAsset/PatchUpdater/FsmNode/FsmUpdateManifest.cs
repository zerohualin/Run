using ET;
using UnityEngine;
using YooAsset;

namespace YooAssetEx
{
    public class FsmUpdateManifest : IFsmNode
    {
        public string Name { private set; get; } = nameof(FsmUpdateManifest);

        void IFsmNode.OnEnter()
        {
            PatchEventDispatcher.SendPatchStepsChangeMsg(EPatchStates.UpdateManifest);
            UpdateManifest().Coroutine();
        }

        void IFsmNode.OnUpdate()
        {
        }

        void IFsmNode.OnExit()
        {
        }

        private async ETTask UpdateManifest()
        {
            // 更新补丁清单
            ETTask etTask = ETTask.Create();
            
            // var operation = YooAssetProxy.NowPackage.UpdatePackageManifestAsync(PatchUpdater.ResourceVersion.ToString(),true, 30);
            // operation.Completed += _ => { etTask.SetResult(); };
            //
            // await etTask;
            //
            // if (operation.Status == EOperationStatus.Succeed)
            // {
            //     FsmManager.Transition(nameof(FsmCreateDownloader));
            // }
            // else
            // {
            //     Debug.LogWarning(operation.Error);
            //     PatchEventDispatcher.SendPatchManifestUpdateFailedMsg();
            // }
        }
    }
}