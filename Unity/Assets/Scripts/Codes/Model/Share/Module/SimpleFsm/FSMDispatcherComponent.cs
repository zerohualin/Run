using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class FSMDispatcherComponent : Entity, IAwake, IDestroy, ILoad
    {
        [StaticField]
        public static FSMDispatcherComponent Instance;
        
        public Dictionary<string, AFSMHandler> FSMHandlers = new Dictionary<string, AFSMHandler>();
    }
}