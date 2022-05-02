using Cfg;
using UnityEngine;

namespace ET
{
    public static partial class FUI_AnimatorDemo_ComponentSystem
    {
        public static void SelectDemo(this FUI_AnimatorDemo_Component self)
        {
            Log.Error("I Select SelectDemo !!!");
            FGUIComponent.Instance.OpenAysnc(FGUIType.AnimatorDemo).Coroutine();
        }
    }

    [FGUIEvent(FGUIType.AnimatorDemo)]
    [FriendClass(typeof (FUI_AnimatorDemo_Component))]
    [FriendClass(typeof (Btn_SelectDemo))]
    public class FUI_AnimatorDemo_ComponentEvent: FGUIEvent<FUI_AnimatorDemo_Component>
    {
        public override void OnCreate(FUI_AnimatorDemo_Component component)
        {
            FGUIHelper.AddButtonListener(component.Btn_ChangeAnima1.self, component.SelectDemo);
        }

        public override void OnShow(FUI_AnimatorDemo_Component self)
        {
        }

        public override void OnRefresh(FUI_AnimatorDemo_Component self)
        {
        }

        public override void OnHide(FUI_AnimatorDemo_Component self)
        {
        }

        public override void OnDestroy(FUI_AnimatorDemo_Component self)
        {
        }
    }
}