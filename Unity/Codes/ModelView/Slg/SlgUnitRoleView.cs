using UnityEngine;

namespace ET
{
    public class SlgUnitRoleView : Entity, IDestroy, IAwake
    {
        public GameObject Obj;
        public Renderer Renderer;
        public Renderer TeamRenderer;
        public TextMesh ActionText;
        public TextMesh ActText;
        public TextMesh HPText;
    }
}
