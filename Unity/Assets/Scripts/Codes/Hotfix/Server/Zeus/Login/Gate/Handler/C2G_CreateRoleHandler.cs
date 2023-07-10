using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof(ET.Server.AccountZoneDB))]
    [FriendOfAttribute(typeof(ET.Server.RoleInfoDB))]
    public class C2G_CreateRoleHandler : AMRpcHandler<C2G_CreateRole, G2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2G_CreateRole request, G2C_CreateRole response)
        {
            var (result, accountZoneDB) = session.CheckAccountZoneDB();
            if (result != ErrorCode.ERR_Success)
            {
                response.Error = result;
                return;
            }
            
            if (string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_Login_NoName;
                return;
            }

            long instanceId = accountZoneDB.InstanceId;
            using (await accountZoneDB.GetParent<GateUser>().GetGateUserLock())
            {
                if (instanceId != accountZoneDB.InstanceId)
                {
                    response.Error = ErrorCode.ERR_Login_NoneAccountZone;
                    return;
                }

                long UnitId = IdGenerater.Instance.GenerateUnitId(accountZoneDB.LoginZoneId);
                
                Name2G_CheckName name2GCheckName = (Name2G_CheckName) await MessageHelper.CallSceneActor(
                    accountZoneDB.LoginZoneId,
                    SceneType.Name,
                    new G2Name_CheckName() { Name = request.Name, UnitId = UnitId });

                if (name2GCheckName.Error != ErrorCode.ERR_Success)
                {
                    response.Error = name2GCheckName.Error;
                    return;
                }
                
                RoleInfoDB roleInfoDB = accountZoneDB.AddChildWithId<RoleInfoDB>(UnitId);
                roleInfoDB.Account = accountZoneDB.Account;
                roleInfoDB.AccountZoneId = accountZoneDB.Id;
                roleInfoDB.LogicZoneId = accountZoneDB.LoginZoneId;
                roleInfoDB.IsDeleted = false;
                roleInfoDB.Name = request.Name;
                roleInfoDB.Level = 1;

                await session.GetDirectDB().Save(roleInfoDB);

                response.Role = roleInfoDB.ToMessage();
            }
            
            await ETTask.CompletedTask;
        }
    }
}