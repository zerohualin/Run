/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
using UnityEngine;

namespace ET.Client
{
    public static class FUI_Setting_ComponentSystem
    {
        public static void Init(this FUI_Setting_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.Setting)]
    [FriendOf(typeof(FUI_Setting_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    [FriendOf(typeof(Btn_Quit))]
    [FriendOf(typeof(Btn_Setting))]
    [FriendOfAttribute(typeof(ET.Client.Btn_Close))]
    [FriendOfAttribute(typeof(ET.Client.Toggle_Setting))]
    public class FUI_Setting_ComponentEvent : FGUIEvent<FUI_Setting_Component>
    {
        public override void OnCreate(FUI_Setting_Component component)
        {
            component.Btn_Close.self.AddListener(() => { FGUIComponent.Instance.Close(FGUIType.Setting); });
            component.Btn_QuitGame.self.AddListener(() =>
            {
                Application.Quit();
            });

            component.Toggle_PushAlarm.self.onClick.Set(() =>
            {
                if (component.Toggle_PushAlarm.toggle.selectedIndex == 0)
                {
                    component.Toggle_PushAlarm.toggle.SetSelectedIndex(1);
                }
                else
                {
                    component.Toggle_PushAlarm.toggle.SetSelectedIndex(0);
                }
            });
        }
        public override void OnShow(FUI_Setting_Component component) { }
        public override void OnRefresh(FUI_Setting_Component component) { }
        public override void OnHide(FUI_Setting_Component component) { }
        public override void OnDestroy(FUI_Setting_Component component) { }
    }
}