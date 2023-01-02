using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class UnitHeadBarComponent: Entity, IAwake, IDestroy, IUpdate
    {
        public Unit Unit;
        public Transform Target;
        public HeadBar fui;
        public Vector3 Unit2ScreenPos;
        public Vector3 HearBarScreenPos;
        public Camera fuiCamera;
        private GTweener gmojiFadeEmojiTweener = null;
    }
}