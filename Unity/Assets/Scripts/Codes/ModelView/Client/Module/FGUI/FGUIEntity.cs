using Cfg;
using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class FUIAwakeSystem: AwakeSystem<FGUIEntity, Type, FGUIType>
    {
        protected override void Awake(FGUIEntity self, Type type, FGUIType eType)
        {
            self.ComponentType = type;
            self.UIType = eType;
        }
    }
    
    [FriendOf(typeof(GObjectComponent))]
    public class FGUIEntity: Entity, IAwake<Type,FGUIType>
    {
        public Entity UIComponent => GetComponent(ComponentType);
        public GObject GObject => GetComponent<GObjectComponent>().GObject;
        public Type ComponentType;
        public FGUIType UIType;
    }
}