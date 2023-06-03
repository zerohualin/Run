using System.Collections.Generic;

namespace ET
{
    [ComponentOf()]
    public class FSMComponent : Entity, IAwake, IUpdate
    {
        public Dictionary<string, AFSMHandler> States = new Dictionary<string, AFSMHandler>();

        public AFSMHandler curFSMHandler;
    }
}