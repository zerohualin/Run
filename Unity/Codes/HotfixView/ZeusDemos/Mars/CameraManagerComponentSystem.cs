using UnityEngine;
using UnityEngine.Rendering.Universal;

// using UnityEngine.Rendering.Universal;

namespace ET
{
    [ObjectSystem]
    public class CameraManagerComponentAwakeSystem : AwakeSystem<CameraManagerComponent>
    {
        public override void Awake(CameraManagerComponent self)
        {
            self.FTra = new GameObject("CameraManager").transform;
            self.FTra.gameObject.AddComponent<DontDestroyOnLoadMono>();
            self.SetStageCamera();
            self.CreatePlayerCamera();
        }
    }

    [ObjectSystem]
    public class CameraManagerComponentDestroySystem : DestroySystem<CameraManagerComponent>
    {
        public override void Destroy(CameraManagerComponent self)
        {
            GameObject.Destroy(self.FTra.gameObject);
        }
    }

    [FriendClass(typeof(CameraManagerComponent))]
    public static class CameraManagerComponentSystem
    {
        public static void SetStageCamera(this CameraManagerComponent self)
        {
            GameObject stageCameraObj = GameObject.Find("Stage Camera");
            self.StageCamera = stageCameraObj.GetComponent<Camera>();
            var cameraData = self.StageCamera.GetUniversalAdditionalCameraData();
            cameraData.renderType = CameraRenderType.Overlay;
        }

        public static void CreatePlayerCamera(this CameraManagerComponent self)
        {
            string cameraPrefabPath = "Assets/Bundles/ZeusDemos/Prefabs/PlayerCamera.prefab";
            GameObject bundleGameObject = Game.Scene.GetComponent<AddressableComponent>().LoadAssetByPath<GameObject>(cameraPrefabPath);
            self.PlayerCamera = GameObject.Instantiate(bundleGameObject).GetComponentInChildren<Camera>();
            self.PlayerCamera.transform.parent.SetParent(self.FTra);
            self.SetOverlayUI(self.PlayerCamera);
        }

        public static Camera GetPlayerCamera(this CameraManagerComponent self)
        {
            return self.PlayerCamera;
        }

        public static Camera GetStageCamera(this CameraManagerComponent self)
        {
            return self.StageCamera;
        }

        public static void RevivePlayerCamera(this CameraManagerComponent self)
        {
            self.PlayerCamera.transform.parent.SetParent(self.FTra);
        }

        public static void SetOverlayUI(this CameraManagerComponent self, Camera camera)
        {
            var cameraData = camera.GetUniversalAdditionalCameraData();
            cameraData.cameraStack.Add(self.StageCamera);
        }
    }
}