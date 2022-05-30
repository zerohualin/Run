using System.Linq;
using System.Web.Hosting;
using Cfg.zerg;
using FairyGUI;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class CameraRaycastViewComponentUpdateSystem: UpdateSystem<CameraRayCastViewComponent>
    {
        public override void Update(CameraRayCastViewComponent self)
        {
            if (Input.GetMouseButtonDown(1))
            {
                var ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray2, out RaycastHit hit2))
                {
                    if (hit2.collider)
                    {
                        var enemyCom = self.DomainScene().GetComponent<EnemyComponent>();
                        var mainEnemy = enemyCom.Children.First().Value;
                        if (mainEnemy.GetComponent<EnemyFishAiComponent>() != null)
                            mainEnemy.RemoveComponent<EnemyFishAiComponent>();
                        mainEnemy.GetComponent<EnemyMoveComponent>().MoveTo(new Vector3(hit2.point.x, 0, hit2.point.z));
                    }
                }
            }

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