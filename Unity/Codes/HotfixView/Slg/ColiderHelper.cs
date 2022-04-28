using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ET
{
    public static class ColiderHelper
    {
        public static void OnPointerClick(GameObject TargetObj, Vector3 center, Vector3 size,
            UnityAction<BaseEventData> OnPointerClick)
        {
            BoxCollider boxCollider = TargetObj.AddComponent<BoxCollider>();
            boxCollider.center = center;
            boxCollider.size = size;
            boxCollider.isTrigger = true;

            EventTrigger eventTrigger = TargetObj.AddComponent<EventTrigger>();
            EventTrigger.Entry entryPD = new EventTrigger.Entry();
            entryPD.eventID = EventTriggerType.PointerClick;
            entryPD.callback.AddListener(OnPointerClick);
            eventTrigger.triggers.Add(entryPD);
        }
    }
}