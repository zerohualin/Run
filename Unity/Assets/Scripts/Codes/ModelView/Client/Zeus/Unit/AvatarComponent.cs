using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class AvatarComponent: Entity, IAwake, IDestroy, IUpdate
    {
        public GameObject RoleObj;
        public int RoleId = 0;
    }
}