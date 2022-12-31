using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class CameraManagerComponent: Entity, IAwake, IDestroy
    {
        public Transform FTra;
        public Camera GlobalCamera;
        public Camera StageCamera;
        public Camera PlayerCamera;
    }
}