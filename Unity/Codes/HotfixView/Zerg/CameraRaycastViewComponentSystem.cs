using FairyGUI;
using UnityEngine;

namespace ET
{
    public class CameraRaycastViewComponentSystem
    {
    }

    [ObjectSystem]
    public class CameraRaycastViewComponentUpdateSystem: UpdateSystem<CameraRayCastViewComponent>
    {
        public override void Update(CameraRayCastViewComponent self)
        {
            // if (Stage.isTouchOnUI)
            // {
            //     return;
            // }
            
            var BuildingPreviewComponent = self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<BuildingPreviewComponent>();

            if (BuildingPreviewComponent.PreviewBuildingData == null)
                return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider)
                {
                    var pos = hit.collider.transform.position;
                    int posX = (int)pos.x;
                    int posZ = (int)pos.z;

                    BuildingPreviewComponent.UpdatePreviewBuilding(posX, posZ);

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (BuildingPreviewComponent.CanBuild)
                        {
                            Log.Debug("可以建造了哦");
                            self.DomainScene().GetComponent<GridGroundComponent>().AddBuild(posX, posZ, BuildingPreviewComponent.PreviewBuildingData);
                            self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<BuildingPreviewComponent>().ClosePreviewBuilding();
                        }
                        else
                        {
                            Log.Error("不行啦,有东西挡住啦");
                        }
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<BuildingPreviewComponent>().ClosePreviewBuilding();
                    }
                }
            }
        }
    }
}