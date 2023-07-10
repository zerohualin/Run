using Cfg;
using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class NetDisconnect_EventHandler: AEvent<Scene, NetDisconnect>
    {
        protected override async ETTask Run(Scene scene, NetDisconnect info)
        {
            await FGUIComponent.Instance.OpenAysnc(FGUIType.PopupConfirm);
            var FUI_PopupConfirm_Component = FGUIComponent.Instance.Get<FUI_PopupConfirm_Component>(FGUIType.PopupConfirm);
            FUI_PopupConfirm_Component.SetData("提示", "有人顶你下线了哦", () =>
            {
                scene.GetComponent<ProcedureComponent>().GetComponent<FSMComponent>().Post(FSMAct.ToLogin);
                SceneChangeHelper.DisposeCurrentScene(scene);
            });
        }
    }
}