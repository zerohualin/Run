using UnityEngine;
using UnityEngine.Rendering.Universal;
using YooAsset;

namespace ET.Client
{
    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.Client.GlobalComponent))]
    public class CameraManagerComponentAwakeSystem : AwakeSystem<CameraManagerComponent>
    {
        protected override void Awake(CameraManagerComponent self)
        {
            self.FTra = new GameObject().transform;
            self.FTra.name = "CameraManager";
            self.FTra.gameObject.AddComponent<DontDestroyOnLoadMono>();

            self.GlobalCamera = GameObject.Find("Global/MainCamera").GetComponent<Camera>();

            self.SetStageCamera();
            self.CreatePlayerCamera();
        }
    }

    [ObjectSystem]
    public class CameraManagerComponentDestroySystem : DestroySystem<CameraManagerComponent>
    {
        protected override void Destroy(CameraManagerComponent self)
        {
            GameObject.Destroy(self.FTra.gameObject);
        }
    }
    [FriendOfAttribute(typeof(ET.Client.CameraManagerComponent))]
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
            string cameraPrefabPath = "Assets/BundleYoo/Zeus/Common/PlayerCamera.prefab";
            var handle = YooAssets.LoadAssetSync<GameObject>(cameraPrefabPath);
            GameObject bundleGameObject = handle.GetAssetObject<GameObject>();
            self.PlayerCamera = GameObject.Instantiate(bundleGameObject).GetComponentInChildren<Camera>();
            self.PlayerCamera.transform.parent.SetParent(self.FTra);

            self.SetOverlayUI(self.PlayerCamera);

            self.GlobalCamera.enabled = false;
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