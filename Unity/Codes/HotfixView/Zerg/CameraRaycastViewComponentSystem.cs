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
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider)
                    {
                        var pos = hit.collider.transform.position;
                        self.DomainScene().GetComponent<GridGroundComponent>().AddBuild((int)pos.x, (int)pos.z);
                    }
                }
            }
        }
    }
}