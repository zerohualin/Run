using FairyGUI;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FGUIComponent(Cfg.FGUIType.Lobby)]
    public class UILobbyComponent : Entity
    {
        [FGUIObject]
        public GButton Btn_EnterMap;
        [FGUIObject]
        public GTextField Txt_Title;
    }
}