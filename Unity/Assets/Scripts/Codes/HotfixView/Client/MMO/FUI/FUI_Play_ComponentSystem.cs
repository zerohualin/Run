/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;

namespace ET.Client
{
    public static class FUI_Play_ComponentSystem
    {
        public static void Init(this FUI_Play_Component self)
        {
        }
    }

    [FGUIEvent(FGUIType.Play)]
    [FriendOf(typeof(FUI_Play_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    [FriendOfAttribute(typeof(ET.Client.MoveJoystick))]
    [FriendOfAttribute(typeof(ET.Client.Btn_Chat))]
    [FriendOfAttribute(typeof(ET.Client.Btn_Setting))]
    [FriendOfAttribute(typeof(ET.Client.Btn_PlayB))]
    [FriendOfAttribute(typeof(ET.Client.Btn_PlayA))]
    [FriendOfAttribute(typeof(ET.Client.Btn_PlayerInfo))]
    public class FUI_Play_ComponentEvent : FGUIEvent<FUI_Play_Component>
    {
        public override void OnCreate(FUI_Play_Component component)
        {
            component.MoveJoystick.self.visible = true;
            component.ButtonChat.self.AddListener(() =>
            {
                component.ClientScene().GetComponent<FGUIComponent>().OpenAysnc(FGUIType.Chat).Coroutine();
            });
            component.ButtonSetting.self.AddListener(() =>
            {
                component.ClientScene().GetComponent<FGUIComponent>().OpenAysnc(FGUIType.Setting).Coroutine();
            });
            component.MoveJoystick.self.visible = false;
            component.ButtonPlayA.self.visible = false;
            component.ButtonPlayB.self.visible = false;
            component.ButtonPlayerInfo.self.visible = false;
        }

        public override void OnShow(FUI_Play_Component component)
        {
        }

        public override void OnRefresh(FUI_Play_Component component)
        {
        }

        public override void OnHide(FUI_Play_Component component)
        {
        }

        public override void OnDestroy(FUI_Play_Component component)
        {
        }
    }
}