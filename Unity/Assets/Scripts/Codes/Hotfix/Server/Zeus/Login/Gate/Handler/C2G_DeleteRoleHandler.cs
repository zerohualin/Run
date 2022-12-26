using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof (ET.Server.RoleInfoDB))]
    public class C2G_DeleteRoleHandler: AMRpcHandler<C2G_DeleteRole, G2C_DeleteRole>
    {
        protected override async ETTask Run(Session session, C2G_DeleteRole request, G2C_DeleteRole response, Action reply)
        {
            var (result, accountZoneDB) = session.CheckAccountZoneDB();
            if (result != ErrorCode.ERR_Success)
            {
                response.Error = result;
                reply();
                return;
            }

            if (!accountZoneDB.Children.ContainsKey(request.UnitId))
            {
                response.Error = ErrorCode.ERR_Login_NoRole;
                reply();
                return;
            }

            long instanceId = accountZoneDB.InstanceId;
            using (await accountZoneDB.GetParent<GateUser>().GetGateUserLock())
            {
                if (instanceId != accountZoneDB.InstanceId)
                {
                    response.Error = ErrorCode.ERR_Login_NoneAccountZone;
                    reply();
                    return;
                }

                RoleInfoDB roleInfoDB = accountZoneDB.Children[request.UnitId] as RoleInfoDB;
                if (roleInfoDB == null)
                {
                    response.Error = ErrorCode.ERR_Login_NoRoleDB;
                    reply();
                    return;
                }

                roleInfoDB.IsDeleted = true;
                DBComponent db = session.GetDirectDB();
                await db.Save(roleInfoDB);
                roleInfoDB.Dispose();
            }

            reply();

            await ETTask.CompletedTask;
        }
    }
}