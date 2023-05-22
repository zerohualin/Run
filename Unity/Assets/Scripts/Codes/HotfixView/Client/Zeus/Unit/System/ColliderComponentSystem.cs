using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [ObjectSystem]
    public class ColliderComponentAwakeSystem: AwakeSystem<UnitColliderComponent>
    {
        protected override void Awake(UnitColliderComponent self)
        {
            var UnitObj = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;

            GameObject obj = new GameObject();
            obj.transform.SetParent(UnitObj.transform);
            obj.transform.localPosition = new Vector3(0, 1f, 0);
            obj.transform.localScale = new Vector3(1, 2, 1);
            obj.name = "Collider";

            obj.AddComponent<CapsuleCollider>();
            obj.AddComponent<EventTrigger>();
            EventTrigger eventTrigger = obj.GetComponent<EventTrigger>();

            EventTrigger.Entry entryPD = new EventTrigger.Entry();
            entryPD.eventID = EventTriggerType.PointerDown;
            entryPD.callback.AddListener(self.OnPointDown);
            eventTrigger.triggers.Add(entryPD);

            EventTrigger.Entry entryPU = new EventTrigger.Entry();
            entryPU.eventID = EventTriggerType.PointerUp;
            entryPU.callback.AddListener(self.OnPointUp);
            eventTrigger.triggers.Add(entryPU);
        }
    }

    public static class ColliderComponentSystem
    {
        public static void OnPointDown(this UnitColliderComponent self, BaseEventData baseEventData)
        {
            Unit unit = self.GetUnit();
            // unit.SayHi(unit.Id, "HIHIHIHI!").Coroutine();
        }

        public static void OnPointUp(this UnitColliderComponent self, BaseEventData baseEventData)
        {
        }
    }
}