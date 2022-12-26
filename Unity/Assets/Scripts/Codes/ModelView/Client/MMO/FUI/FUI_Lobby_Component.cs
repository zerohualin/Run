/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [FGUIComponent(Cfg.FGUIType.Lobby)]
    [FriendOf(typeof(IFGUIComponent))]
    public sealed partial class FUI_Lobby_Component : Entity, IAwake
    {
        public string UIPackageName => this.GetComponent<IFGUIComponent>().UIPackageName;
        public string UIResName => this.GetComponent<IFGUIComponent>().UIResName;
        public string URL => this.GetComponent<IFGUIComponent>().URL;

        [FGUISelfObjectAttribute]
        public GComponent self;

        [FGUICustomCom]
        public Btn_Setting Btn_Setting;
        [FGUIObject]
        public GTextField username;
        [FGUICustomCom]
        public Btn_Chat Btn_Chat;
        [FGUICustomCom]
        public Btn_Blanck ButtonChangeName;
        [FGUICustomCom]
        public Btn_InventoryBottom ButtonLobbyInventory;
        [FGUIObject]
        public GGroup ButtonInventory;
        [FGUICustomCom]
        public Btn_Battle Btn_Battle;
        [FGUICustomCom]
        public Btn_Map Btn_Map;
        [FGUICustomCom]
        public Btn_LobbyRight ButtonLobbyFriends;
        [FGUICustomCom]
        public Btn_Rank Btn_Rank;
    }
}