using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class PlayerCameraComponent : Entity, IAwake, ILateUpdate, IDestroy
    {
        public Transform Target;
        public GameObject CameraFObj;
        public Camera Camera;

        public Vector3 TopdownPos;
        public Quaternion TopdownQuaternion;
    }
}
