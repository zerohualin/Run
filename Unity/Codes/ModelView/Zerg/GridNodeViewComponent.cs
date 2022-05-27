using UnityEngine;

namespace ET
{
    public class GridNodeViewComponent : Entity, IAwake<GameObject, GameObject>
    {
        public GameObject GroundStateObj;
        public GameObject VisionObj;
    }
}