using System.Web.Hosting;
using Cfg.zerg;
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
            var AreaPreviewComponent = self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>();

            if (AreaPreviewComponent.Card == null)
                return;

            if (Stage.isTouchOnUI)
            {
                AreaPreviewComponent.DestoryPreviewBuilding();
                return;
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider)
                {
                    var Area = AreaPreviewComponent.UpdatePreviewBuilding(hit.point.x, hit.point.z);

                    if (Input.GetMouseButtonDown(0))
                    {
                        AreaPreviewComponent.TryUseCard();
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        AreaPreviewComponent.CancelUse();
                    }
                }
            }
        }
    }
}