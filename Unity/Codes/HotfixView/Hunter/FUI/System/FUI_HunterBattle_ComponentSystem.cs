/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
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
                self.DomainScene().GetComponent<RoomManagerComponent>().GetCardRoom().GetComponent<CardTurnComponent>().EndTurn();
            }
        }
    }

    public class FUI_HunterBattle_NewTrun: AEvent<EventType.NewTrun>
    {
        protected override void Run(EventType.NewTrun args)
        {
            var FUICom = args.ZoneScene.GetComponent<FGUIComponent>().GetFUICom<FUI_HunterBattle_Component>(FGUIType.HunterBattle);
            FUICom.Refresh();
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
    [FriendClass(typeof (Card))]
    [FriendClass(typeof (FUI_HunterBattle_Component))]
    [FriendClass(typeof (ProgressBar_Energy))]
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
            var trunNum = self.Domain.GetComponent<RoomManagerComponent>().GetCardRoom().GetComponent<CardTurnComponent>().Num;
            self.TurnTxt.text = $"当前回合数 {trunNum}";
        }

        public static void RefreshEnerge(this FUI_HunterBattle_Component self)
        {
            var EnergyComponent = self.DomainScene().GetMyPlayer().GetComponent<EnergyComponent>();
            self.ProgressBar_Energy.self.max = EnergyComponent.Max;
            self.ProgressBar_Energy.self.value = EnergyComponent.Current;
            self.ProgressBar_Energy.ProgressTxt.text = $"{EnergyComponent.Current} / {EnergyComponent.Max}";
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

        public static void RenderListItem(this FUI_HunterBattle_Component self, GObject obj, Card data)
        {
            GButton Cell = (GButton)obj;
            var group = Cell.GetChild("CardGroup");
            Cell.GetChild("CanUseFrame").visible = data.CanUse();
            Cell.GetChild("CanNotUseFrame").visible = !data.CanUse();
            Cell.GetChild("TitleTxt").text = data.Config.Name;
            Cell.GetChild("DescTxt").text = data.Config.Desc;
            Cell.GetChild("CostTxt").text = $"消耗能量 {data.Config.Cost}";
            ETCancellationToken cancerToken = null;

            Vector2 GetGroupV2()
            {
                var LogicPos = GRoot.inst.GlobalToLocal(Input.mousePosition);
                var v2 = Cell.GlobalToLocal(new Vector2(LogicPos.x, GRoot.inst.height - LogicPos.y));
                return new Vector2(v2.x - group.width * 0.5f, v2.y - group.height * 0.5f);
            }

            async void TouchBegin()
            {
                cancerToken = new ETCancellationToken();
                @group.TweenMove(GetGroupV2(), 0.15f);
                @group.TweenScale(Vector2.one * 1.1f, 0.15f);
                await Game.Scene.GetComponent<TimerComponent>().WaitAsync(150);
                while (!cancerToken.IsCancel())
                {
                    await Game.Scene.GetComponent<TimerComponent>().WaitAsync(10, cancerToken);
                    var v2 = GetGroupV2();
                    @group.SetXY(v2.x, v2.y);
                }
            }

            Cell.onTouchBegin.Add(TouchBegin);
            Cell.onTouchEnd.Add(() =>
            {
                cancerToken.Cancel();
                bool useSucess = true;

                useSucess = useSucess && -group.y > group.height * 0.66f;

                EnergyComponent energyComponent = self.DomainScene().GetMyPlayer().GetComponent<EnergyComponent>();
                useSucess = useSucess && energyComponent.CheckCast(data.Config.Cost);
                if (useSucess)
                {
                    energyComponent.Cast(data.Config.Cost);
                    self.HandComponent.RemoveCard(data);
                    self.RefreshCard();
                }
                else
                {
                    @group.TweenScale(Vector2.one, 0.15f);
                    @group.TweenMove(Vector2.zero, 0.15f);
                }
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
            component.Btn_EndTurn.self.AddListener(() =>
            {
                component.DomainScene().GetComponent<RoomManagerComponent>().GetCardRoom().GetComponent<CardTurnComponent>().EndTurn();
            });
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