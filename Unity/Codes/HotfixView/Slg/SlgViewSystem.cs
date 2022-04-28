namespace ET
{
    public class Event_InitSlgComponent : AEvent<EventType.InitSlgComponent>
    {
        protected override async ETTask Run(EventType.InitSlgComponent args)
        {
            Game.Scene.TryAddComponent<SlgView, SlgComponent>(args.SlgComponent);
            Game.Scene.TryAddComponent<CameraManagerComponent, string>("Assets/Bundles/com_wavegamer_slg/Prefab/SlgMainCamera.prefab");

            args.SlgComponent.AddComponent<SlgCameraView>();
            args.SlgComponent.AddComponent<SlgBakcGroundView>();
        }
    }

    public class Event_DestorySlgComponent : AEvent<EventType.DestorySlgComponent>
    {
        protected override async ETTask Run(EventType.DestorySlgComponent args)
        {
            var slgView = Game.Scene.GetComponent<SlgView>();
            slgView.Dispose();
        }
    }

    public class Event_InitSlgNode : AEvent<EventType.InitSlgNode>
    {
        protected override async ETTask Run(EventType.InitSlgNode args)
        {
            args.SlgNode.AddComponent<SlgNodeGroundView>();
            args.SlgNode.AddComponent<SlgActionView>();
        }
    }

    public class Event_Update_SlgActions : AEvent<EventTypeView.Update_SlgActions>
    {
        protected override async ETTask Run(EventTypeView.Update_SlgActions args)
        {
            var SlgComponent = args.ZoneScene.GetComponent<SlgComponent>();
            for (int x = 0; x < SlgComponent.MapWidth; x++)
            {
                for (int y = 0; y < SlgComponent.MapHeight; y++)
                {
                    var node = SlgComponent.GetNode(x, y);
                    var view = node.GetComponent<SlgActionView>();
                    if (args.AllActions != null && args.AllActions[x] != null && args.AllActions[x][y] != null)
                    {
                        view.Refresh(args.AllActions[x][y]);
                    }
                    else
                    {
                        view.Refresh(SlgActionType.Empty);
                    }
                }
            }
        }
    }

    [ObjectSystem]
    public class SlgViewAwakeSystem : AwakeSystem<SlgView, SlgComponent>
    {
        public override async void Awake(SlgView self, SlgComponent slgComponent)
        {
            self.SlgComponent = slgComponent;
            Game.Scene.TryAddComponent<FUIPackageComponent>();
            self.DomainScene().TryAddComponent<FUIComponent>();
            await Game.Scene.GetComponent<FUIPackageComponent>().DoAddPackages();
            Game.EventSystem.Publish(new EventTypeFUI.InitFUISlgPlay(){ZoneScene = self.DomainScene()});
            Game.EventSystem.Publish(new EventType.UpdateSlgRound(){SlgComponent = slgComponent});
        }
    }

    [ObjectSystem]
    public class SlgViewDestroySystem : DestroySystem<SlgView>
    {
        public override async void Destroy(SlgView self)
        {
            self.Dispose();
        }
    }

    public static class SlgViewSystem
    {
        public static async void TrySelectNode(this SlgView self, SlgNode slgNode)
        {
            var SlgComponent = slgNode.DomainScene().GetComponent<SlgComponent>();

            if (self.SelectedNode != null && self.SelectedNode.Id == slgNode.Id)
                return;

            var targetUnit = slgNode.GetUnit();

            if (self.SelectedNode != null)
            {
                var selectUnit = self.SelectedNode.GetUnit();
                var action = SlgActionType.Empty;

                if (selectUnit != null)
                {
                    if (selectUnit.Team != SlgComponent.MoveTeam)
                        return;

                    if (targetUnit != null && selectUnit.Team == targetUnit.Team)
                    {
                        self.SelectNode(slgNode);
                        return;
                    }

                    action = self.SelectedNode.TryMoveUnit(slgNode);

                    if (action == SlgActionType.Empty)
                    {
                        return;
                    }
                }

                Game.EventSystem.Publish(new EventTypeView.Focus_SlgUnit(){SlgUnit = selectUnit});
                Game.EventSystem.Publish(new EventTypeView.UnSelect_SlgNode(){SlgNode = self.SelectedNode});

                await Game.EventSystem.PublishAsync(new EventTypeView.UpdateUnit_SlgNode(){FinalNode = slgNode});

                if (action == SlgActionType.Attack)
                {
                    selectUnit.Attack(targetUnit);
                    await Game.EventSystem.PublishAsync(new EventTypeView.Update_Unit_AttackResult()
                        {ZoneScene = slgNode.DomainScene()});
                }
            }

            if (targetUnit == null)
            {
                return;
            }

            if (targetUnit.Team != SlgComponent.MoveTeam)
                return;

            self.SelectNode(slgNode);
        }

        public static async void SelectNode(this SlgView self, SlgNode slgNode)
        {
            self.UnSelect();
            var SlgComponent = slgNode.DomainScene().GetComponent<SlgComponent>();
            self.SelectedNode = slgNode;
            var actions = SlgComponent.CheckAction(self.SelectedNode);
            Game.EventSystem.Publish(new EventTypeView.Select_SlgNode(){SlgNode = slgNode});
            Game.EventSystem.Publish(new EventTypeView.Update_SlgActions()
                {ZoneScene = slgNode.DomainScene(), AllActions = actions});
        }

        public static void UnSelect(this SlgView self)
        {
            if (self.SelectedNode != null)
            {
                Game.EventSystem.Publish(new EventTypeView.UnSelect_SlgNode(){SlgNode = self.SelectedNode});
                self.SelectedNode = null;
            }
        }
    }
}
