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
            if (Stage.isTouchOnUI)
            {
                return;
            }

            var BuildingPreviewComponent = self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<BuildingPreviewComponent>();

            if (BuildingPreviewComponent.PreviewBuildingData == null)
                return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider)
                {
                    var Area = BuildingPreviewComponent.UpdatePreviewBuilding(hit.point.x, hit.point.z);

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (BuildingPreviewComponent.CanBuild)
                        {
                            self.DomainScene().GetComponent<GridGroundComponent>().AddBuild(Area, BuildingPreviewComponent.PreviewBuildingData);
                            self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<BuildingPreviewComponent>().ClosePreviewBuilding();
                        }
                        else
                        {
                            // Log.Error("不行啦,有东西挡住啦");
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