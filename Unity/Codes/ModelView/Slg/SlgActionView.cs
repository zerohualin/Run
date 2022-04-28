using UnityEngine;

namespace ET
{
    public class SlgActionView : Entity, IAwake, IDestroy, IUpdate
    {
        public GameObject Obj;
        public TextMesh TextMesh;
        public Renderer Renderer;
    }
}
