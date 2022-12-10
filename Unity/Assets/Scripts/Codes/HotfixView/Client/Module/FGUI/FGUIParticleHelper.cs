using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    public static class FGUIParticleHelper
    {
        public static async ETTask AddParticle(this GComponent gCom, string path)
        {
            var handle = await YooAssetProxy.LoadAssetAsync<GameObject>(path);
            GameObject pObj = handle.GetAsset<GameObject>();
            gCom.AddWrapperChild(pObj);
        }
    }
}