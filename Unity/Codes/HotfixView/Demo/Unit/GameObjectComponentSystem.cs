using System;
using UnityEngine;

namespace ET
{
    public static class GameObjectComponentSystem
    {
        public class GameObjectComponentAwakeSystem: AwakeSystem<GameObjectComponent, string>
        {
            public override void Awake(GameObjectComponent self, string name)
            {
                self.Name = name;
                self.GameObject = AddressableComponent.Instance.LoadAssetByPath<GameObject>($"Assets/Bundles/ZeusDemos/Prefabs/{self.Name}.prefab");
                self.GameObject = GameObject.Instantiate(self.GameObject);
            }
        }

        [ObjectSystem]
        public class DestroySystem: DestroySystem<GameObjectComponent>
        {
            public override void Destroy(GameObjectComponent self)
            {
                UnityEngine.Object.Destroy(self.GameObject);
            }
        }
    }
}