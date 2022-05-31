/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
using Cfg.zerg;
using FairyGUI;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof (CardTurnComponent))]
    public class FUI_HunterBattle_ComponentAwakeSystem: AwakeSystem<FUI_HunterBattle_Component>
    {
        public override void Awake(FUI_HunterBattle_Component self)
        {
        }
    }

    [ObjectSystem]
    [FriendClass(typeof (CardTurnComponent))]
    public class FUI_HunterBattle_ComponentUpdateSystem: UpdateSystem<FUI_HunterBattle_Component>
    {
        public override void Update(FUI_HunterBattle_Component self)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                self.DomainScene().GetMyPlayer().TryEndMyTurn();
            }
        }
    }

    public class FUI_HunterBattle_ChangeCard: AEvent<EventType.ChangeCard>
    {
        protected override void Run(EventType.ChangeCard args)
        {
            var FUICom = args.ZoneScene.GetComponent<FGUIComponent>()?.GetFUICom<FUI_HunterBattle_Component>(FGUIType.HunterBattle);
            FUICom?.Refresh();
        }
    }

    public class FUI_HunterBattle_NewTrun: AEvent<EventType.NewTrun>
    {
        protected override void Run(EventType.NewTrun args)
        {
            var FUICom = args.ZoneScene.GetComponent<FGUIComponent>()?.GetFUICom<FUI_HunterBattle_Component>(FGUIType.HunterBattle);
            FUICom?.Refresh();
        }
    }

    public class FUI_HunterBattle_ChangeTrun: AEvent<EventType.ChangeTrun>
    {
        protected override void Run(EventType.ChangeTrun args)
        {
            var FUICom = args.ZoneScene.GetComponent<FGUIComponent>().GetFUICom<FUI_HunterBattle_Component>(FGUIType.HunterBattle);
            FUICom.RefreshTurn();
            FUICom.RefreshEnerge();
        }
    }

    public class FUI_HunterBattle_ChangeEnergy: AEvent<EventType.ChangeEnergy>
    {
        protected override void Run(EventType.ChangeEnergy args)
        {
            var FUICom = args.ZoneScene.GetComponent<FGUIComponent>().GetFUICom<FUI_HunterBattle_Component>(FGUIType.HunterBattle);
            FUICom.RefreshEnerge();
        }
    }

    [FriendClass(typeof (CardTurnComponent))]
    [FriendClass(typeof (HandComponent))]
    [FriendClass(typeof (Building))]
    [FriendClass(typeof (FUI_HunterBattle_Component))]
    [FriendClass(typeof (ProgressBar_Resource))]
    [FriendClass(typeof (EnergyComponent))]
    public static class FUI_HunterBattle_ComponentSystem
    {
        public static void Refresh(this FUI_HunterBattle_Component self)
        {
            self.RefreshTurn();
            self.RefreshCard();
            self.RefreshEnerge();
        }

        public static void RefreshTurn(this FUI_HunterBattle_Component self)
        {
        }

        public static void RefreshEnerge(this FUI_HunterBattle_Component self)
        {
            var EnergyComponent = self.DomainScene().GetMyPlayer().GetComponent<EnergyComponent>();
            self.ProgressBar_Mineral.self.max = EnergyComponent.Max;
            self.ProgressBar_Mineral.self.value = EnergyComponent.Current;
            self.ProgressBar_Mineral.ProgressTxt.text = $"{EnergyComponent.Current} / {EnergyComponent.Max}";
        }

        public static void RefreshCard(this FUI_HunterBattle_Component self)
        {
            var list = self.CardList.asList;
            var cards = list.GetChildren();
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Dispose();
            }

            list.RemoveChildren();
            for (int i = 0; i < self.HandComponent.Cards.Count; i++)
            {
                var cardCell = list.AddItemFromPool();
                self.RenderListItem(cardCell, self.HandComponent.Cards[i]);
            }
        }

        public static void RenderListItem(this FUI_HunterBattle_Component self, GObject obj, BuildingData data)
        {
            var Cell = self.AddChild<FUI_BuildingCell>();
            FGUIHelper.BindRoot(typeof (FUI_BuildingCell), Cell, obj.asButton);

            ETCancellationToken cancerToken = null;

            switch (data.Config.Type)
            {
                case BuildingType.Building:
                    Cell.Bg.color = Color.cyan * 0.6f;
                    break;
                // case CardType.Skill:
                //     Cell.Bg.color = Color.yellow * 0.6f;
                //     break;
                // case CardType.Module:
                //     Cell.Bg.color = Color.gray * 0.6f;
                //     break;
            }

            Cell.TitleTxt.text = data.Config.Name;

            Cell.self.AddListener(() =>
            {
                self.DomainScene().GetComponent<GridGroundComponent>().GetComponent<AreaPreviewComponent>().CreatePreviewBuilding(data);
            });
        }
    }

    [FGUIEvent(FGUIType.HunterBattle)]
    [FriendClass(typeof (FUI_HunterBattle_Component))]
    [FriendClass(typeof (HandComponent))]
    [FriendClass(typeof (Btn_EndTurn))]
    public class FUI_HunterBattle_ComponentEvent: FGUIEvent<FUI_HunterBattle_Component>
    {
        public override void OnCreate(FUI_HunterBattle_Component component)
        {
            component.HandComponent = component.DomainScene().GetMyPlayer().GetComponent<HandComponent>();
            component.Refresh();
            component.Btn_EndTurn.self.AddListener(() => { component.HandComponent.TryAddRandomCard(); });
        }

        public override void OnShow(FUI_HunterBattle_Component component)
        {
            component.Refresh();
        }

        public override void OnRefresh(FUI_HunterBattle_Component component)
        {
            component.Refresh();
        }

        public override void OnHide(FUI_HunterBattle_Component component)
        {
        }

        public override void OnDestroy(FUI_HunterBattle_Component component)
        {
        }
    }
}