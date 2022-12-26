using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class RoleInfosComponent : Entity, IDestroy, IAwake
    {
        public List<RoleInfo> RoleInfos = new List<RoleInfo>();
        public long CurrentRoleId = 0;
    }
}