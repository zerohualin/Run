using ET.EventType;
using UnityEngine;

namespace ET.Client
{
    public static class UnityDebugComponentSystem
    {
    }
    
    [ObjectSystem]
    public class UnityDebugComponentUpdateSystem : UpdateSystem<UnityDebugComponent>
    {
        protected override void Update(UnityDebugComponent self)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneChangeHelper.SceneChangeTo(self.ClientScene(), "Login", 10001).Coroutine();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                EventSystem.Instance.Publish(self.ClientScene(), new NetDisconnect()
                {
                    Code = 100
                });
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                CodeLoader.Instance.LoadHotfix();
                EventSystem.Instance.Load();
                Log.Debug("hot reload success!");
            }
            
            if (Input.GetKeyDown(KeyCode.T))
            {
                C2M_TransferMap c2MTransferMap = new C2M_TransferMap();
                c2MTransferMap.TargetMapName = "Map2";
                self.ClientScene().GetComponent<SessionComponent>().Session.Call(c2MTransferMap).Coroutine();
            }
            
            if (Input.GetKeyDown(KeyCode.Y))
            {
                C2M_TransferMap c2MTransferMap = new C2M_TransferMap();
                c2MTransferMap.TargetMapName = "Map1";
                self.ClientScene().GetComponent<SessionComponent>().Session.Call(c2MTransferMap).Coroutine();
            }
        }
    }
}
