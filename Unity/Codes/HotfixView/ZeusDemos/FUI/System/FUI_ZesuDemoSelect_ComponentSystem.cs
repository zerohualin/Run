using Cfg;
using UnityEngine;

namespace ET
{
    public static class FUI_ZesuDemoSelect_ComponentSystem
    {
        public static void SelectDemo(this FUI_ZesuDemoSelect_Component self)
        {
            // Log.Error("I Select SelectDemo !!!");
            // FGUIComponent.Instance.Close(FGUIType.ZesuDemoSelect);
            // FGUIComponent.Instance.OpenAysnc(FGUIType.BattleDemo).Coroutine();
        }
    }

    [FGUIEvent(FGUIType.ZesuDemoSelect)]
    [FriendClass(typeof (FUI_ZesuDemoSelect_Component))]
    [FriendClass(typeof (Btn_SelectDemo))]
    public class FUI_ZesuDemoSelect_ComponentEvent: FGUIEvent<FUI_ZesuDemoSelect_Component>
    {
        public override void OnCreate(FUI_ZesuDemoSelect_Component component)
        {
            component.Btn_SelectDemo.self.AddListener(component.SelectDemo);
        }

        public override void OnShow(FUI_ZesuDemoSelect_Component self)
        {
            self.self.visible = true;
        }

        public override void OnRefresh(FUI_ZesuDemoSelect_Component self)
        {
        }

        public override void OnHide(FUI_ZesuDemoSelect_Component self)
        {
            self.self.visible = false;
        }

        public override void OnDestroy(FUI_ZesuDemoSelect_Component self)
        {
        }
    }
}