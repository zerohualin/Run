/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
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
    [FriendClass(typeof (FUI_HunterBattle_Component))]
    public static class FUI_HunterBattle_ComponentSystem
    {
        public static void Refresh(this FUI_HunterBattle_Component self)
        {
            self.DomainScene().GetComponent<CardPlayerComponent>();
            self.RefreshTurn();
        }

        public static void RefreshTurn(this FUI_HunterBattle_Component self)
        {
            var trunNum = self.Domain.GetComponent<RoomManagerComponent>().GetCardRoom().GetComponent<CardTurnComponent>().Num;
            self.TurnTxt.text = $"当前回合数 {trunNum}";
        }
    }

    [FGUIEvent(FGUIType.HunterBattle)]
    [FriendClass(typeof (FUI_HunterBattle_Component))]
    public class FUI_HunterBattle_ComponentEvent: FGUIEvent<FUI_HunterBattle_Component>
    {
        public override void OnCreate(FUI_HunterBattle_Component component)
        {
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