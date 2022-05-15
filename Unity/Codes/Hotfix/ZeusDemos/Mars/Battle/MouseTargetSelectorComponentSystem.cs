using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class MouseTargetSelectorComponentAwakeSystem : AwakeSystem<MouseTargetSelectorComponent>
    {
        public override void Awake(MouseTargetSelectorComponent self)
        {
            //此处填写Awake逻辑
            self.MainCamera = Camera.main;
            self.TargetLayerInfo = LayerMask.GetMask("Map", "Unit");
        }
    }

    [ObjectSystem]
    public class MouseTargetSelectorComponentUpdateSystem : UpdateSystem<MouseTargetSelectorComponent>
    {
        public override void Update(MouseTargetSelectorComponent self)
        {
            self.ResetTargetInfo();

            if (self.MainCamera == null)
            {
                self.TrySetCamera();
            }

            //此处填写Update逻辑
            if (Physics.Raycast(self.MainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, 1000))
            {
                UnitComponent unitComponent = self.DomainScene().GetComponent<RoomManagerComponent>().GetBattleRoom().GetComponent<UnitComponent>();
                self.TargetHitPoint = hitInfo.point;
                self.TargetGameObject = hitInfo.transform.gameObject;

                MonoBridge monoBridge = hitInfo.transform.GetComponent<MonoBridge>();
                if (monoBridge == null)
                {
                    return;
                }
                
                Unit unit = unitComponent.Get(monoBridge.BelongToUnitId);
                if (unit != null)
                {
                    self.TargetUnit = unit;
                }
            }
        }
    }

    [ObjectSystem]
    public class
            MouseTargetSelectorComponentFixedUpdateSystem : LateUpdateSystem<MouseTargetSelectorComponent>
    {
        public override void LateUpdate(MouseTargetSelectorComponent self)
        {
        }
    }

    [ObjectSystem]
    public class MouseTargetSelectorComponentDestroySystem : DestroySystem<MouseTargetSelectorComponent>
    {
        public override void Destroy(MouseTargetSelectorComponent self)
        {
        }
    }
    
    [FriendClass(typeof(MouseTargetSelectorComponent))]
    public static class MouseTargetSelectorComponentSystem
    {
        public static void TrySetCamera(this MouseTargetSelectorComponent self)
        {
            self.MainCamera = Camera.main;
        }
    }
}