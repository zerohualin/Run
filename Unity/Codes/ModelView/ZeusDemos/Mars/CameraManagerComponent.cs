using UnityEngine;

namespace ET
{
    public class CameraManagerComponent : Entity, IAwake<string>, IDestroy, IAwake
    {
        public Transform FTra;
        public Camera StageCamera;
        public Camera PlayerCamera;
    }
}