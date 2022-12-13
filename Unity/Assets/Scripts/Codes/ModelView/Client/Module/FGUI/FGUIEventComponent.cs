using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(FGUIComponent))]
    public class FGUIEventComponent: Entity, IAwake
    {
        public Dictionary<Cfg.FGUIType, IFGUIEvent> UIEvents = new Dictionary<Cfg.FGUIType, IFGUIEvent>();
    }
}