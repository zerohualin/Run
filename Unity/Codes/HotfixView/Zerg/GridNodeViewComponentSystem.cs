using UnityEngine;

namespace ET
{
    public class GridNodeViewComponentAwakeSystem: AwakeSystem<GridNodeViewComponent, GameObject, GameObject>
    {
        public override void Awake(GridNodeViewComponent self, GameObject GroundStateObj, GameObject VisionObj)
        {
            self.GroundStateObj = GroundStateObj;
            self.VisionObj = VisionObj;
            var node = self.GetParent<GridNode>();
            
            self.GroundStateObj.transform.position = new Vector3(node.x, 0, node.y);
            self.GroundStateObj.transform.localScale = Vector3.one * 0.96f;
            
            self.VisionObj.transform.position = new Vector3(node.x, 5, node.y);
        }
    }
}