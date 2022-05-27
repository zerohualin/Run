using UnityEngine;

namespace ET
{
    public class CameraManagerComponent : Entity, IAwake<string>, IDestroy, IAwake, IUpdate
    {
        public Transform FTra;
        public Camera StageCamera;
        public Camera PlayerCamera;
    }
}