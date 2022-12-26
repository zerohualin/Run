/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using System.Collections.Generic;
using Cfg;
using FairyGUI;

namespace ET.Client
{
    [FriendOf(typeof(FUI_CommonSelectList_Component))]
    [FriendOfAttribute(typeof(ET.Client.CommonSelectList))]
    public static class FUI_CommonSelectList_ComponentSystem
    {
        public static void Init(this FUI_CommonSelectList_Component self, List<CommonSelectCellData> CellDataList)
        {
            self._cellDataList = CellDataList;

            var list = self.CommonSelectList.list.asList;
            list.itemRenderer = self.RenderListItem;
            list.itemProvider = self.GetListItemResource;
            list.numItems = CellDataList.Count;
        }

        static string GetListItemResource(this FUI_CommonSelectList_Component self, int index)
        {
            return "ui://MMO/CommonListCell";
        }

        static void RenderListItem(this FUI_CommonSelectList_Component self, int index, GObject obj)
        {
            GButton item = (GButton)obj;
            item.GetChild("btnName").asTextField.text = self._cellDataList[index].Name;
            item.onClick.Add(() =>
            {
                self._cellDataList[index].Action();
                FGUIComponent.Instance.Close(FGUIType.CommonSelectList);
            });
        }
    }

    [FGUIEvent(FGUIType.CommonSelectList)]
    [FriendOf(typeof(FUI_CommonSelectList_Component))]
    [ComponentOf(typeof(FGUIEntity))]
    public class FUI_CommonSelectList_ComponentEvent: FGUIEvent<FUI_CommonSelectList_Component>
    {
        public override void OnCreate(FUI_CommonSelectList_Component component){}
        public override void OnShow(FUI_CommonSelectList_Component component){}
        public override void OnRefresh(FUI_CommonSelectList_Component component){}
        public override void OnHide(FUI_CommonSelectList_Component component){}
        public override void OnDestroy(FUI_CommonSelectList_Component component){}
    }
}