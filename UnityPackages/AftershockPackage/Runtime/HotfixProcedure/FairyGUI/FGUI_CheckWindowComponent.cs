//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2021年8月26日 22:26:49
//------------------------------------------------------------

using System;

namespace ET
{
    public class FGUI_CheckWindowComponent
    {
        private static FGUI_CheckWindow fguiCheckWindow;

        public static void Init(Action cancelAct, Action confirmAct, string content, string cancelBtnName = "取消",
            string confirmBtnName = "确认", string title = "")
        {
            fguiCheckWindow = FGUI_CheckWindow.CreateInstance();
            fguiCheckWindow.MakeFullScreen();
            FUIManager_MonoOnly.AddUI(nameof(FGUI_CheckWindow), fguiCheckWindow);

            fguiCheckWindow.Text_Title.text = title;
            fguiCheckWindow.Text_Content.text = content;
            fguiCheckWindow.ButtonList.numItems = 0;

            var Btn_Cancel = fguiCheckWindow.ButtonList.AddItemFromPool() as FGUI_CheckButton;
            Btn_Cancel.Text_Name.text = cancelBtnName;
            Btn_Cancel.onClick.Set(() =>
            {
                if (cancelAct != null)
                    cancelAct();
                Release();
            });

            var Btn_Confirm = fguiCheckWindow.ButtonList.AddItemFromPool() as FGUI_CheckButton;
            Btn_Confirm.Text_Name.text = confirmBtnName;
            Btn_Confirm.onClick.Set(() =>
            {
                if (confirmAct != null)
                    confirmAct();
                Release();
            });
        }

        public static void Release()
        {
            FUIManager_MonoOnly.RemoveUI(nameof(FGUI_CheckWindow));
        }
    }
}