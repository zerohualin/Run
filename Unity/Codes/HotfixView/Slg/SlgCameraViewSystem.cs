using UnityEngine;

namespace ET
{
    public class Event__FocusUnit : AEvent<EventTypeView.Focus_SlgUnit>
    {
        protected override async ETTask Run(EventTypeView.Focus_SlgUnit args)
        {
            var SlgCameraView = args.SlgUnit.DomainScene().GetComponent<SlgComponent>().GetComponent<SlgCameraView>();
            SlgCameraView.FocusUnit(args.SlgUnit.Parent as SlgNode);
        }
    }

    public class Event__FocusUnitTeam : AEvent<EventTypeView.Focus_Team>
    {
        protected override async ETTask Run(EventTypeView.Focus_Team args)
        {
            var SlgComponent = args.ZoneScene.GetComponent<SlgComponent>();
            var SlgCameraView = SlgComponent.GetComponent<SlgCameraView>();
            if (SlgCameraView == null)
                return;
            var unitComponent = SlgComponent.GetComponent<SlgUnitComponent>();
            SlgUnit unit = unitComponent.RandomSelectUnit(SlgComponent.MoveTeam);
            SlgCameraView.FocusUnit(unit.Parent as SlgNode);
        }
    }

    [ObjectSystem]
    public class SlgCameraViewAwakeSystem : AwakeSystem<SlgCameraView>
    {
        public override async void Awake(SlgCameraView self)
        {
            // var ResourcesComponent = Game.Scene.GetComponent<ResourcesComponentX>();
            // GameObject bundleGameObject = ResourcesComponent.LoadAsset<GameObject>("Assets/Bundles/com_wavegamer_slg/Prefab/SlgMainCamera.prefab");
            self.Obj = GameObject.Find("SlgMainCamera(Clone)");
            self.MainCamera = self.Obj.GetComponentInChildren<Camera>();
            self.MainCamera.transform.localPosition = new Vector3(3, 0, 3);
        }
    }

    [ObjectSystem]
    public class SlgCameraViewUpdateSystem : UpdateSystem<SlgCameraView>
    {
        public override async void Update(SlgCameraView self)
        {
            var deltaposition = Vector3.zero;
#if UNITY_EDITOR
            if(Input.GetMouseButton(0))
                deltaposition = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
#else
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Debug.Log("单点触摸， 水平上下移动");
                var deltaPos = Input.GetTouch(0).deltaPosition;
                deltaposition = new Vector3(deltaPos.x * 0.01f, 0, deltaPos.y * 0.01f);
            }
#endif
            self.Obj.transform.Translate(-deltaposition, Space.World);
        }
    }

    public static class SlgCameraViewSystem
    {
        public static void FocusUnit(this SlgCameraView self, SlgNode node)
        {
            var nodeView = node.GetComponent<SlgNodeGroundView>();
            if (nodeView == null)
                return;
            var nodePos = nodeView.Obj.transform.position;
            self.MainCamera.transform.position = new Vector3(nodePos.x, 10, nodePos.z);
        }
    }
}