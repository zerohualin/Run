using System.Collections.Generic;
using Cfg;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class InitFUICommonSelectList: AEvent<Scene, EventType.CommonSelectListEvent>
    {
        protected override async ETTask Run(Scene scene, EventType.CommonSelectListEvent args)
        {
            OpenSelectList(args.CellDataList).Coroutine();
        }

        private async ETTask OpenSelectList(List<CommonSelectCellData> CellDataList)
        {
            await FGUIComponent.Instance.OpenAysnc(FGUIType.CommonSelectList);
            var FUI_CommonSelectList_Component = FGUIComponent.Instance.Get<FUI_CommonSelectList_Component>(FGUIType.CommonSelectList);
            FUI_CommonSelectList_Component.Init(CellDataList);
        }
    }
}