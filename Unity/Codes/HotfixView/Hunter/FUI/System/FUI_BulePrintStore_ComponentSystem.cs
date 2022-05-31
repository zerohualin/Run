/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using Cfg;
using Cfg.zerg;
using FairyGUI;

namespace ET
{
    public static class FUI_BulePrintStore_ComponentSystem
    {
        public static void Awake(this FUI_BulePrintStore_Component self)
        {
        }

        public static void RefreshBluePrints(this FUI_BulePrintStore_Component self)
        {
            var list = self.BluePrintList.asList;
            var cards = list.GetChildren();
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Dispose();
            }

            list.RemoveChildren();

            var allBluePrints = Game.Scene.GetComponent<LubanComponent>().Tables.TbBluePrint.DataList;

            for (int i = 0; i < allBluePrints.Count; i++)
            {
                var cardCell = list.AddItemFromPool();
                self.RenderListItem(cardCell, allBluePrints[i]);
            }
        }

        public static void RenderListItem(this FUI_BulePrintStore_Component self, GObject obj, BluePrintConfig data)
        {
            var component = self.AddChild<FUI_BulePrint>();
            FGUIHelper.BindRoot(typeof (FUI_BulePrint), component, obj.asCom.GetChild("BluePrint").asCom);

            component.TitleTxt.text = data.Name;
            component.CostTxt.text = $"Price {data.Cost.ToString()}";
            component.LvTxt.text = $"Lv {data.Level.ToString()}";
        }
    }

    [FGUIEvent(FGUIType.BulePrintStore)]
    [FriendClass(typeof (FUI_BulePrintStore_Component))]
    [FriendClass(typeof (Btn_LeaveStore))]
    public class FUI_BulePrintStore_ComponentEvent: FGUIEvent<FUI_BulePrintStore_Component>
    {
        public override void OnCreate(FUI_BulePrintStore_Component component)
        {
            // component.BluePrintList
            component.Btn_LevelStore.self.AddListener(() => { FGUIComponent.Instance.Close(FGUIType.BulePrintStore); });
            component.RefreshBluePrints();
        }

        public override void OnShow(FUI_BulePrintStore_Component component)
        {
        }

        public override void OnRefresh(FUI_BulePrintStore_Component component)
        {
        }

        public override void OnHide(FUI_BulePrintStore_Component component)
        {
        }

        public override void OnDestroy(FUI_BulePrintStore_Component component)
        {
        }
    }
}