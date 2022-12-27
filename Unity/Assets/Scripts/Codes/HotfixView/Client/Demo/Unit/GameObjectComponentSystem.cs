using System;
using UnityEngine;

namespace ET.Client
{
    public static class GameObjectComponentSystem
    {
        [ObjectSystem]
        public class DestroySystem: DestroySystem<GameObjectComponent>
        {
            protected override void Destroy(GameObjectComponent self)
            {
                UnityEngine.Object.Destroy(self.GameObject);
            }
        }

        public static void SetObj(this GameObjectComponent self, GameObject obj)
        {
            self.GameObject = obj;
            GameObject.DontDestroyOnLoad(obj);
        }
    }
}