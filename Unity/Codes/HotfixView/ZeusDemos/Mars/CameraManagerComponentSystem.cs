using Cfg;
using FairyGUI;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ET
{
    [ObjectSystem]
    public class CameraManagerComponentAwakeSystem: AwakeSystem<CameraManagerComponent>
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
    public class CameraManagerComponentUpdateSystem: UpdateSystem<CameraManagerComponent>
    {
        public override void Update(CameraManagerComponent self)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FGUIComponent.Instance.OpenAysnc(FGUIType.BulePrintStore).Coroutine();
            }
            
            if (Stage.isTouchOnUI)
            {
                return;
            }

            var BuildingPreviewComponent = self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>();
            if (BuildingPreviewComponent.BuildingData != null)
                return;

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                self.FTra.transform.position += new Vector3(-Input.GetAxis("Mouse X"), 0, -Input.GetAxis("Mouse Y"));
            }

            var scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                self.PlayerCamera.orthographicSize -= scroll * 10;
            }
        }
    }

    [ObjectSystem]
    public class CameraManagerComponentDestroySystem: DestroySystem<CameraManagerComponent>
    {
        public override void Destroy(CameraManagerComponent self)
        {
            GameObject.Destroy(self.FTra.gameObject);
        }
    }

    [FriendClass(typeof (CameraManagerComponent))]
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

        public static void JumpTo(this CameraManagerComponent self, float posX, float posY)
        {
            self.FTra.transform.position = new Vector3(posX, 0, posY);
        }
    }
}