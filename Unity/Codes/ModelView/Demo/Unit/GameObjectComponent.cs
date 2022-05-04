using UnityEngine;

namespace ET
{
    public class GameObjectComponent: Entity, IAwake, IDestroy, IAwake<string>
    {
        public string Name;
        public GameObject GameObject { get; set; }
    }
}