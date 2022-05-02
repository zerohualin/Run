using Cfg;
using UnityEngine;

namespace ET
{
    public static partial class FUI_ZesuDemoSelect_ComponentSystem
    {
        public static void SelectDemo(this FUI_ZesuDemoSelect_Component self)
        {
            Log.Error("I Select SelectDemo !!!");
            FGUIComponent.Instance.Close(FGUIType.ZesuDemoSelect);
            FGUIComponent.Instance.OpenAysnc(FGUIType.AnimatorDemo).Coroutine();
        }
    }

    [FGUIEvent(FGUIType.ZesuDemoSelect)]
    [FriendClass(typeof (FUI_ZesuDemoSelect_Component))]
    [FriendClass(typeof (Btn_SelectDemo))]
    public class FUI_ZesuDemoSelect_ComponentEvent: FGUIEvent<FUI_ZesuDemoSelect_Component>
    {
        public override void OnCreate(FUI_ZesuDemoSelect_Component self)
        {
            FGUIHelper.AddButtonListener(self.Btn_SelectDemo.self, self.SelectDemo);
            self.Txt_TestTitle.text = "这个是测试用的";
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