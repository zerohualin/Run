using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.Client.AvatarComponent))]
    public class PlayerCameraComponentAwakeSystem : AwakeSystem<PlayerCameraComponent>
    {
        protected override void Awake(PlayerCameraComponent self)
        {
            self.CameraFObj = self.DomainScene().GetComponent<CameraManagerComponent>().GetPlayerCamera().transform.parent.gameObject;
            Unit unit = self.GetParent<Unit>();

            // self.CameraFObj.transform.SetParent();
            // Target = this.Parent.GetComponent<UnitNavMoveComponent>().obj.transform;
            self.Target = unit.GetComponent<AvatarComponent>().RoleObj.transform;

            self.Camera = self.CameraFObj.GetComponentInChildren<Camera>();
            self.TopdownPos = self.Camera.transform.localPosition;
            self.TopdownQuaternion = self.Camera.transform.localRotation;
        }
    }
    
    [ObjectSystem]
    public class PlayerCameraComponentDestorySystem : DestroySystem<PlayerCameraComponent>
    {
        protected override void Destroy(PlayerCameraComponent self)
        {
            var CurrentScene = self.DomainScene()?.CurrentScene();
            CurrentScene?.GetComponent<CameraManagerComponent>().RevivePlayerCamera();
        }
    }
    
    [ObjectSystem]
    public class PlayerCameraComponentLateUpdateSystem : LateUpdateSystem<PlayerCameraComponent>
    {
        protected override void LateUpdate(PlayerCameraComponent self)
        {
            self.CameraFObj.transform.position = self.Target.transform.position;
        }
    }

    public static class PlayerCameraComponentSystem 
    {
    }
}
