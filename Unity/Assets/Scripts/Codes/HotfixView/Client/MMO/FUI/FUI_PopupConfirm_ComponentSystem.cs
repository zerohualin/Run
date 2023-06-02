/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using System;
using Cfg;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.Btn_Close))]
    [FriendOfAttribute(typeof(ET.Client.FUI_PopupConfirm_Component))]
    [FriendOfAttribute(typeof(ET.Client.Btn_Middle))]
    public static class FUI_PopupConfirm_ComponentSystem
    {
        public static void Init(this FUI_PopupConfirm_Component self)
        {
        }

        public static void SetData(this FUI_PopupConfirm_Component self, string title, string content, Action action)
        {
            self.Text_Title.text = title;
            self.Text_Context.text = content;
            self.Btn_Confirm.self.AddListener(() =>
            {
                if (action != null)
                    action();
            });
        }
    }

    [FGUIEvent(FGUIType.PopupConfirm)]
    [FriendOf(typeof (FUI_PopupConfirm_Component))]
    [ComponentOf(typeof (FGUIEntity))]
    [FriendOf(typeof (Btn_Middle))]
    public class FUI_PopupConfirm_ComponentEvent: FGUIEvent<FUI_PopupConfirm_Component>
    {
        public override void OnCreate(FUI_PopupConfirm_Component component)
        {
        }

        public override void OnShow(FUI_PopupConfirm_Component component)
        {
        }

        public override void OnRefresh(FUI_PopupConfirm_Component component)
        {
        }

        public override void OnHide(FUI_PopupConfirm_Component component)
        {
        }

        public override void OnDestroy(FUI_PopupConfirm_Component component)
        {
        }
    }
}