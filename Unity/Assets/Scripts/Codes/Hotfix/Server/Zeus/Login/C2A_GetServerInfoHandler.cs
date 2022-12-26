using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Realm)]
    [FriendOf(typeof (ET.ServerInfosComponent))]
    public class C2A_GetServerInfoHandler: AMRpcHandler<C2R_GetServerList, R2C_GetServerList>
    {
        protected override async ETTask Run(Session session, C2R_GetServerList request, R2C_GetServerList response, Action reply)
        {
            RealmAccountComponent realmAccountComponent = session.GetComponent<RealmAccountComponent>();
            if (realmAccountComponent == null)
            {
                response.Error = ErrorCode.ERR_Login_NotLogin;
                reply();
                return;
            }

            ServerInfosComponent ServerInfosComponent = session.DomainScene().GetComponent<ServerInfosComponent>();

            foreach (StartZoneConfig zoneConfig in StartZoneConfigCategory.Instance.GetAll().Values)
            {
                if (zoneConfig.ZoneType == (int)ZoneType.Game)
                {
                    ServerInfosComponent.Add(new ServerInfoProto()
                    {
                        Name = zoneConfig.Name, Zone = zoneConfig.Id, Status = RandomGenerator.RandomNumber(0, 1)
                    });
                }
            }

            response.ServerInfos = new List<ServerInfoProto>();
            foreach (var ServerInfo in ServerInfosComponent.ServerInfos)
            {
                response.ServerInfos.Add(ServerInfo.ToMessage());
            }

            reply();

            await ETTask.CompletedTask;
        }
    }
}