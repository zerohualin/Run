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
            var BuildingPreviewComponent = self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>();

            if (BuildingPreviewComponent.PreviewData == null)
                return;
            
            if (Stage.isTouchOnUI)
            {
                BuildingPreviewComponent.DestoryPreviewBuilding();
                return;
            }

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
                            self.DomainScene().GetComponent<GridGroundComponent>().AddBuild(Area, BuildingPreviewComponent.PreviewData);
                            self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>().ClosePreviewBuilding();
                        }
                        else
                        {
                            // Log.Error("不行啦,有东西挡住啦");
                        }
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>().ClosePreviewBuilding();
                    }
                }
            }
        }
    }
}