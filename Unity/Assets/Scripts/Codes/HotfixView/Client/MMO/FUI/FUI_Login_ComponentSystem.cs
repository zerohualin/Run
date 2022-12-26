/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
namespace ET.Client
{
    [FriendOf(typeof(FUI_Login_Component))]
    public static class FUI_Login_ComponentSystem
    {
        public static void Init(this FUI_Login_Component self)
        {
        }
        public static void OnClickLogin(this FUI_Login_Component self)
        {
            string outerIp = "127.0.0.1";
            int port = 7009;
            // LoginHelper.LoginAsync(self.DomainScene(), $"{outerIp}:{port}", self.Input_Account.text, "123456").Coroutine();
            LoginHelper.LoginAsync(self.DomainScene(), "15168392381", "123456").Coroutine();
        }
    }

    [FGUIEvent(FGUIType.Login)]
    [FriendOf(typeof(FUI_Login_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    [FriendOf(typeof(TopHint))]
    [FriendOf(typeof(Btn_Login))]
    public class FUI_Login_ComponentEvent : FGUIEvent<FUI_Login_Component>
    {
        public override void OnCreate(FUI_Login_Component component)
        {
            component.Input_Account.text = "15168392381";
            component.Btn_Login.self.AddListener(() =>
            {
                component.OnClickLogin();
            });
        }
        public override void OnShow(FUI_Login_Component component) { }
        public override void OnRefresh(FUI_Login_Component component) { }
        public override void OnHide(FUI_Login_Component component) { }
        public override void OnDestroy(FUI_Login_Component component) { }
    }
}