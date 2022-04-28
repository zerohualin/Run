using System.Linq;
using UnityEngine;

namespace ET
{
    public class Event_InitSlgUnitRoleComponent : AEvent<EventType.InitSlgUnit>
    {
        protected override async ETTask Run(EventType.InitSlgUnit args)
        {
            var view = args.SlgUnit.TryAddComponent<SlgUnitRoleView>();
            view.Refresh();
        }
    }
    
    public class Event_UpdateSlgUnitRoleComponent : AEvent<EventType.UpdateSlgUnit>
    {
        protected override async ETTask Run(EventType.UpdateSlgUnit args)
        {
            var view = args.SlgUnit.GetComponent<SlgUnitRoleView>();
            view.Refresh();
        }
    }

    public class Event_Move_SlgUnitRoleComponent : AEvent<EventType.Move_SlgUnitRoleComponent>
    {
        protected override async ETTask Run(EventType.Move_SlgUnitRoleComponent args)
        {
        }
    }
    
    public class Event_UpdateUnit_SlgNode : AEvent<EventTypeView.UpdateUnit_SlgNode>
    {
        protected override async ETTask Run(EventTypeView.UpdateUnit_SlgNode args)
        {
            var SlgComponent = args.FinalNode.DomainScene().GetComponent<SlgComponent>();
            var MovePaths = SlgComponent.MovePaths;
            var MovePath = MovePaths[args.FinalNode.X][args.FinalNode.Y];
            //因为实际上Unit已经移动完毕
            var unit = MovePath.SlgNodes.Last().GetComponent<SlgUnit>();
            var view = unit.GetComponent<SlgUnitRoleView>();
            for (int i = 0; i < MovePath.SlgNodes.Count - 1; i++)
            {
                var next = MovePath.SlgNodes[i + 1];
                view.UpdatePos(next);
                await Game.Scene.GetComponent<TimerComponent>().WaitAsync(100);
            }
        }
    }

    [ObjectSystem]
    public class SlgUnitRoleViewAwakeSystem : AwakeSystem<SlgUnitRoleView>
    {
        public override async void Awake(SlgUnitRoleView self)
        {
            var ResourcesComponent = Game.Scene.GetComponent<ResourcesComponentX>();
            GameObject bundleGameObject =
                ResourcesComponent.LoadAsset<GameObject>("Assets/Bundles/com_wavegamer_slg/Prefab/Unit.prefab");
            self.Obj = GameObject.Instantiate(bundleGameObject);
            self.Renderer = self.Obj.GetComponentInChildren<Renderer>();

            self.TeamRenderer = self.Obj.Get<GameObject>("Team").GetComponent<Renderer>();

            var rootNode = self.Parent.Parent as SlgNode;
            self.Obj.transform.position = new Vector3(rootNode.X, 0, rootNode.Y);
            
            self.ActionText = self.Obj.Get<GameObject>("ActionText").GetComponent<TextMesh>();
            self.ActText = self.Obj.Get<GameObject>("ActText").GetComponent<TextMesh>();
            self.HPText = self.Obj.Get<GameObject>("HPText").GetComponent<TextMesh>();
            
            var unit = rootNode.GetComponent<SlgUnit>();
            if (unit.Team == UnitTeam.A)
                self.TeamRenderer.material.color = Color.blue;
            if (unit.Team == UnitTeam.B)
                self.TeamRenderer.material.color = Color.red;
        }
    }
    
    [NumericWatcher(NumericType.Act)]
    public class NumericWatcher_SlgUnit_Act : INumericEntityWatcher
    {
        public void Run(Entity unit, long value)
        {
            unit.GetComponent<SlgUnitRoleView>().ActText.text = value.ToString();
        }
    }
    
    [ObjectSystem]
    public class SlgUnitRoleViewDestroySystem : DestroySystem<SlgUnitRoleView>
    {
        public override async void Destroy(SlgUnitRoleView self)
        {
            GameObject.Destroy(self.Obj);
        }
    }

    public static class SlgUnitRoleViewSystem
    {
        public static void Refresh(this SlgUnitRoleView self)
        {
            var root = self.Parent.Parent as SlgNode;
            self.Obj.transform.position = new Vector3(root.X, 0, root.Y);
            
            var unit = self.Parent as SlgUnit;
            self.ActionText.text = unit.ActionNum.ToString();
            self.ActText.text = "";
            self.HPText.text = $"HP:{unit.Data.Hp.ToString()}";
        }

        public static void UpdatePos(this SlgUnitRoleView self, SlgNode target)
        {
            self.Obj.transform.position = new Vector3(target.X, 0, target.Y);
        }

        public static void Select(this SlgUnitRoleView self)
        {
            self.Renderer.material.color = Color.yellow;
        }

        public static void UnSelect(this SlgUnitRoleView self)
        {
            self.Renderer.material.color = Color.white;
        }
    }
}