using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    public class C2G_GetRolesHandler: AMRpcHandler<C2G_GetRoles, G2C_GetRoles>
    {
        protected override async ETTask Run(Session session, C2G_GetRoles request, G2C_GetRoles response)
        {
            var (result, accountZoneDB) = session.CheckAccountZoneDB();
            if (result != ErrorCode.ERR_Success)
            {
                response.Error = result;
                return;
            }
            
            if (accountZoneDB.Children.Count > 0)
            {
                response.Roles = new List<RoleInfoProto>();
                foreach (Entity entity in accountZoneDB.Children.Values)
                {
                    if (entity is RoleInfoDB roleInfoDB)
                    {
                        response.Roles.Add(roleInfoDB.ToMessage());
                    }
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}