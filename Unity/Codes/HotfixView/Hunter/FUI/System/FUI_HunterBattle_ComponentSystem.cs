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

    public class FUI_HunterBattle_ChangeTrun: AEvent<EventType.ChangeTrun>
    {
        protected override void Run(EventType.ChangeTrun args)
        {
            var FUICom = args.ZoneScene.GetComponent<FGUIComponent>().GetFUICom<FUI_HunterBattle_Component>(FGUIType.HunterBattle);
            FUICom.RefreshTurn();
        }
    }

    [FriendClass(typeof (CardTurnComponent))]
    [FriendClass(typeof (HandComponent))]
    [FriendClass(typeof (Card))]
    [FriendClass(typeof (FUI_HunterBattle_Component))]
    public static class FUI_HunterBattle_ComponentSystem
    {
        public static void Refresh(this FUI_HunterBattle_Component self)
        {
            self.RefreshTurn();
        }

        public static void RefreshTurn(this FUI_HunterBattle_Component self)
        {
            var trunNum = self.Domain.GetComponent<RoomManagerComponent>().GetCardRoom().GetComponent<CardTurnComponent>().Num;
            self.TurnTxt.text = $"当前回合数 {trunNum}";
        }

        public static void RenderListItem(this FUI_HunterBattle_Component self, int index, GObject obj)
        {
            GButton card = (GButton)obj;
            var data = self.HandComponent.Cards[index];
            card.GetChild("CanUseFrame").visible = data.CanUse;
            card.GetChild("TitleTxt").text = data.Config.Name;
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
            component.HandComponent = component.DomainScene().GetCardRoom().GetComponent<HandComponent>();

            var list = component.CardList.asList;
            list.SetVirtual();
            list.itemRenderer = component.RenderListItem;
            list.itemProvider = (int index) => { return "ui://Hunter/FUI_Card"; };
            list.numItems = component.HandComponent.Cards.Count;

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