using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class GateUserMgrComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<string, GateUser> Users = new Dictionary<string, GateUser>();
    }
}