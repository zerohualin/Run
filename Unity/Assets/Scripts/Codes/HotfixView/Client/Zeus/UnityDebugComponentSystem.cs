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
        }
    }
}
