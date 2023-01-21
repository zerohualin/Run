using System;

namespace ET.Server
{
    [FriendOfAttribute(typeof (ET.Server.AccountZoneDB))]
    [FriendOfAttribute(typeof (ET.Server.GateUser))]
    public static class GateUserSystem
    {
        public static async ETTask<CoroutineLock> GetGateUserLock(string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new Exception("GetGateUserLock but account is Null !");
            }

            return await CoroutineLockComponent.Instance.Wait(CoroutineLockType.GateUserLock, account.GetLongHashCode());
        }

        public static ETTask<CoroutineLock> GetGateUserLock(this GateUser gateUser)
        {
            AccountZoneDB accountZoneDB = gateUser.GetComponent<AccountZoneDB>();
            return GetGateUserLock(accountZoneDB.Account);
        }

        public static async ETTask OfflineWithLock(this GateUser self, bool dispose = true)
        {
            if (self == null || self.IsDisposed)
                return;
            long instanceId = self.InstanceId;
            using (await self.GetGateUserLock())
            {
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                await self.Offline(dispose);
            }
        }

        public static async ETTask Offline(this GateUser self, bool dispose = true)
        {
            if (self == null || self.IsDisposed)
            {
                return;
            }

            AccountZoneDB accountZoneDB = self.GetComponent<AccountZoneDB>();
            if (accountZoneDB != null)
            {
                //通知排队服务器下线
                MessageHelper.SendActor(self.DomainZone(), SceneType.Queue,
                    new G2Queue_Disconnect() { UnitId = accountZoneDB.LastRoleId, IsProtect = false });
                //TODO 通知地图服务器进行角色下线
            }

            if (dispose)
            {
                self.DomainScene().GetComponent<GateUserMgrComponent>()?.Remove(accountZoneDB?.Account);
            }
            else
            {
                self.State = GateUserState.InGate;
                self.RemoveComponent<GateQueueComponent>();
            }

            await ETTask.CompletedTask;
        }

        public static void OfflineSession(this GateUser self)
        {
            Log.Console($"-> 账号{self.GetComponent<AccountZoneDB>()?.Account} 被顶号 {self.SessionInstanceId} 对外下线");
            Session session = self.Session;
            if (session != null)
            {
                //发送给原先连接的客户端一条顶号下线的消息，您的账号被顶下线了。"
                session.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_Login_MultiLogin });

                session.RemoveComponent<SessionUserComponent>();
                session.Disconnect().Coroutine();
            }

            self.SessionInstanceId = 0;

            //为了方式后续玩家一直不登陆，这里就家一个计时器，到时间了顶号的还不上来就对内下线了
            self.RemoveComponent<GateUserDisconnectComponent>();
            self.AddComponent<GateUserDisconnectComponent, long>(ConstValue.Login_GateUserDisconnectTime);
        }

        public static async ETTask EnterMap(this GateUser self)
        {
            AccountZoneDB accountZoneDB = self.GetComponent<AccountZoneDB>();
            Log.Console($"-> 账号 {accountZoneDB.Account} 进入");

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(self.DomainZone(), "Map1");
            self.RemoveComponent<GateQueueComponent>();

            if (self.State == GateUserState.InMap)
            {
                //顶号登录
                M2C_StartSceneChange sceneChange = new M2C_StartSceneChange()
                {
                    SceneInstanceId = startSceneConfig.InstanceId, SceneName = startSceneConfig.Name
                };
                self.Session.Send(sceneChange);
                self.Session.AddComponent<SessionPlayerComponent>().PlayerId = accountZoneDB.LastRoleId;
                MessageHelper.SendToLocationActor(accountZoneDB.LastRoleId, new G2M_ReLogin(){});
                return;
            }

            self.State = GateUserState.InMap;

            GateMapComponent gateMapComponent = self.AddComponent<GateMapComponent>();
            gateMapComponent.Scene = await SceneFactory.CreateServerScene(gateMapComponent, IdGenerater.Instance.GenerateId(),
                IdGenerater.Instance.GenerateInstanceId(),
                self.DomainZone(), "GateMap", SceneType.Map, startSceneConfig);

            Unit unit = UnitFactory.Create(gateMapComponent.Scene, accountZoneDB.LastRoleId, UnitType.Player, self.InstanceId);
            
            self.Session.AddComponent<SessionPlayerComponent>().PlayerId = accountZoneDB.LastRoleId;

            await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name);

            await self.EnterWorldChat();

            await ETTask.CompletedTask;
        }
        
        public static async ETTask EnterWorldChat(this GateUser self)
        {
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(self.DomainZone(), "ChatInfo");
            Chat2G_EnterChat chat2GEnterChat = (Chat2G_EnterChat)await MessageHelper.CallActor(startSceneConfig.InstanceId,
                new G2Chat_EnterChat()
                {
                    UnitId = self.Id,
                    GateSessionActorId = self.InstanceId
                });
            self.ChatInfoUnitInstanceId = chat2GEnterChat.ChatInfoUnitInstanceId;
        }
    }
}