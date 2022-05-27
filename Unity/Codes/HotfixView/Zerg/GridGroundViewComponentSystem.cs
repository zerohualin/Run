using UnityEngine;

namespace ET
{
    public class GridGroundViewComponentAwakeSystem: AwakeSystem<GridGroundViewComponent>
    {
        public override void Awake(GridGroundViewComponent self)
        {
            var groundCom = self.GetParent<GridGroundComponent>();
            
            GameObject GroundsObj = new GameObject("Grounds");
            string path = "Assets/Bundles/Zerg/Prefabs/GoundNode.prefab";
            var groundObj = AddressableComponent.Instance.LoadAssetByPath<GameObject>(path);
            
            GameObject FogsObj = new GameObject("Fogs");
            string fogPath = "Assets/Bundles/Zerg/Prefabs/FogNode.prefab";
            
            var fogObj = AddressableComponent.Instance.LoadAssetByPath<GameObject>(fogPath);
            for (int x = 0; x < groundCom.GridData.Length; x++)
            {
                for (int y = 0; y < groundCom.GridData.Length; y++)
                {
                    var node = groundCom.GridData[x][y];
                    var ground = GameObject.Instantiate(groundObj, GroundsObj.transform);
                    var fog = GameObject.Instantiate(fogObj, FogsObj.transform);
                    node.AddComponent<GridNodeViewComponent, GameObject, GameObject>(ground, fog);
                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
                }
            }
        }
    }
}