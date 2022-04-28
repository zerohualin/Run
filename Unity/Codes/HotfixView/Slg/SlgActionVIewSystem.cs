using ET.EventType;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET
{
    [ObjectSystem]
    public class SlgActionViewAwakeSystem : AwakeSystem<SlgActionView>
    {
        public override async void Awake(SlgActionView self)
        {
            var ResourcesComponent = Game.Scene.GetComponent<ResourcesComponentX>();
            GameObject bundleGameObject =
                ResourcesComponent.LoadAsset<GameObject>("Assets/Bundles/com_wavegamer_slg/Prefab/ActionView.prefab");
            self.Obj = GameObject.Instantiate(bundleGameObject);
            self.TextMesh = self.Obj.Get<GameObject>("ActionName").GetComponent<TextMesh>();
            self.TextMesh.text = "";

            self.Renderer = self.Obj.Get<GameObject>("GroundQuad").GetComponent<Renderer>();

            var root = self.Parent as SlgNode;
            self.Obj.transform.position = new Vector3(root.X, 0, root.Y);
        }
    }
    
    [ObjectSystem]
    public class SlgActionViewDestroySystem : DestroySystem<SlgActionView>
    {
        public override async void Destroy(SlgActionView self)
        {
            GameObject.Destroy(self.Obj);
        }
    }

    public class Event_Select_SlgNode : AEvent<EventTypeView.Select_SlgNode>
    {
        protected override async ETTask Run(EventTypeView.Select_SlgNode args)
        {
            var unit = args.SlgNode.GetComponent<SlgUnit>();
            if (unit != null)
            {
                unit.GetComponent<SlgUnitRoleView>().Select();
                Game.EventSystem.Publish(new EventTypeView.Select_SlgUnit() { SlgUnit = unit});
            }
        }
    }

    public class Event_UnSelect_SlgNode : AEvent<EventTypeView.UnSelect_SlgNode>
    {
        protected override async ETTask Run(EventTypeView.UnSelect_SlgNode args)
        {
            var view = Game.Scene.GetComponent<SlgView>();
            var unit = view.SelectedNode.GetComponent<SlgUnit>();
            view.SelectedNode = null;
            if (unit != null)
            {
                Game.EventSystem.Publish(new EventTypeView.UnSelect_SlgUnit() { SlgUnit = unit});
                unit.GetComponent<SlgUnitRoleView>().UnSelect();
            }
            Game.EventSystem.Publish(new EventTypeView.Update_SlgActions() { ZoneScene = args.SlgNode.DomainScene()});
        }
    }

    public static class SlgActionViewSystem
    {
        public static void Refresh(this SlgActionView self, SlgActionType slgActionType)
        {
            switch (slgActionType)
            {
                case SlgActionType.Empty:
                case SlgActionType.CannotMove:
                    self.TextMesh.text = "";
                    self.Renderer.material.color = new Color(1, 1, 1, 0);
                    break;
                case SlgActionType.Self:
                    self.TextMesh.text = "";
                    self.Renderer.material.color = Color.yellow;
                    break;
                case SlgActionType.Move:
                    self.TextMesh.text = "移动";
                    self.Renderer.material.color = new Color(0, 1, 0, 0.3f);
                    break;
                case SlgActionType.Attack:
                    self.TextMesh.text = "攻击";
                    self.Renderer.material.color = new Color(1, 0, 0, 0.3f);
                    break;
            }
        }
    }
}