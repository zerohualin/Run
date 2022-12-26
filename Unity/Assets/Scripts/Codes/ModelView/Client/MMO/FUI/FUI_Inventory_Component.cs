/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.Inventory)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_Inventory_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUIObject]
        public GList list;
        [FGUICustomCom]
        public Btn_Back ButtonBack;
        [FGUIObject]
        public GImage quality;
        [FGUIObject]
        public GTextField itemNameText;
        [FGUIObject]
        public GTextField itemInfoText;
        [FGUIObject]
        public GImage icon;
        [FGUIObject]
        public GLoader itemView;
        [FGUICustomCom]
        public Btn_Middle ButtonUse;
        [FGUICustomCom]
        public Btn_Middle ButtonSell;
        [FGUIObject]
        public GGroup ItemInfo;
        [FGUIObject]
        public GImage focus;
        [FGUIObject]
        public GImage moneyIcon;
        [FGUIObject]
        public GTextField moneyText;
        [FGUIObject]
        public GGroup Top;
    }
}