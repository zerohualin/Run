using System;
using System.Net;
using System.Net.Sockets;
using ET.EventType;
using MongoDB.Bson;

namespace ET.Client
{
    [FriendOf(typeof (AccountInfoComponent))]
    [FriendOf(typeof (SessionComponent))]
    [FriendOf(typeof (RoleInfosComponent))]
    public static partial class LoginHelper
    {
        // //账号服务器 返回token的模式
        public static async ETTask<int> LoginAsync(Scene zoneScene, string account, string password)
        {
            try
            {
                IPEndPoint realmAddress = await GetRealmAddress(zoneScene, account);

                int accountLoginResult = await LoginAccount(zoneScene, realmAddress, account, password);
                if (accountLoginResult != ErrorCode.ERR_Success)
                    return accountLoginResult;

                // R2C_Login r2CLogin;
                // using (Session session = await RouterHelper.CreateRouterSession(clientScene, realmAddress))
                // {
                //     r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = account, Password = password });
                // }
                //
                // // 创建一个gate Session,并且保存到SessionComponent中
                // Session gateSession = await RouterHelper.CreateRouterSession(clientScene, NetworkHelper.ToIPEndPoint(r2CLogin.Address));
                // clientScene.AddComponent<SessionComponent>().Session = gateSession;
                //
                // G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
                //     new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});
                //
                // Log.Debug("登陆gate成功!");

                // await EventSystem.Instance.PublishAsync(clientScene, new EventType.LoginFinish());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            // A2C_LoginAccount a2CLoginAccount = null;
            // Session accountSession = null;
            // try
            // {
            //
            // }
            // catch (Exception e)
            // {
            //     accountSession?.Dispose();
            //     Log.Error(e.ToString());
            //     return ErrorCode.ERR_NetworkError;
            // }
            //
            // if (a2CLoginAccount.Error != ErrorCode.ERR_Success)
            // {
            //     accountSession?.Dispose();
            //     return a2CLoginAccount.Error;
            // }
            //
            // //登录成功后 账号seesion与客户端保持连接
            // var sessionComponent = zoneScene.AddComponent<SessionComponent>().Session = accountSession;
            // sessionComponent.AddComponent<PingComponent>();
            //
            // var accountInfoComponent = zoneScene.GetComponent<AccountInfoComponent>();
            // accountInfoComponent.Token = a2CLoginAccount.Token;
            // accountInfoComponent.AccountId = a2CLoginAccount.AccountId;

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<IPEndPoint> GetRealmAddress(Scene zoneScene, string account)
        {
            // 创建一个ETModel层的Session
            zoneScene.RemoveComponent<RouterAddressComponent>();
            // 获取路由跟realmDispatcher地址
            RouterAddressComponent routerAddressComponent = zoneScene.GetComponent<RouterAddressComponent>();
            if (routerAddressComponent == null)
            {
                routerAddressComponent =
                        zoneScene.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                await routerAddressComponent.Init();

                zoneScene.AddComponent<NetClientComponent, AddressFamily>(routerAddressComponent.RouterManagerIPAddress.AddressFamily);
            }

            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);
            return realmAddress;
        }

        public static async ETTask<int> LoginAccount(Scene zoneScene, IPEndPoint accountAddress, string account, string password)
        {
            R2C_LoginAccount r2CLoginAccount = null;
            Session realmSession = null;
            try
            {
                realmSession = await RouterHelper.CreateRouterSession(zoneScene, accountAddress);
                //加密
                password = MD5Helper.StringMd5(password);

                r2CLoginAccount =
                        (R2C_LoginAccount)await realmSession.Call(new C2R_LoginAccount()
                        {
                            Account = account, Password = password, LoginWay = (int)LoginWayType.Normal
                        });
            }
            catch (Exception e)
            {
                realmSession?.Dispose();
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetworkError;
            }

            if (r2CLoginAccount.Error != ErrorCode.ERR_Success)
            {
                realmSession.Dispose();
                return r2CLoginAccount.Error;
            }

            zoneScene.AddComponent<SessionComponent>().Session = realmSession;
            zoneScene.GetComponent<AccountInfoComponent>().Token = r2CLoginAccount.Token;
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = r2CLoginAccount.AccountId;

            return ErrorCode.ERR_Success;
        }

        //也就是Zone
        public static async ETTask<int> GetServerInfos(Scene zoneScene)
        {
            R2C_GetServerList r2CGetServerList = null;

            r2CGetServerList = (R2C_GetServerList)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2R_GetServerList() { });

            if (r2CGetServerList.Error != ErrorCode.ERR_Success)
            {
                return r2CGetServerList.Error;
            }

            zoneScene.GetComponent<ServerInfosComponent>().Clear();
            foreach (var serverInfoProto in r2CGetServerList.ServerInfos)
            {
                zoneScene.GetComponent<ServerInfosComponent>().Add(serverInfoProto);
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> LoginZone(Scene zoneScene, int zoneId)
        {
            R2C_LoginZone r2CLoginZone = null;

            r2CLoginZone = (R2C_LoginZone)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2R_LoginZone() { ZoneId = zoneId });

            if (r2CLoginZone.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"登录区服 Error {r2CLoginZone.Error}");
            }

            Log.Info($"登录 zone 1 拿到 GateAddress : {r2CLoginZone.GateAddress}");
            Log.Info($"登录 zone 2 拿到 GateKey : {r2CLoginZone.GateKey}");
            zoneScene.GetComponent<AccountInfoComponent>().GateAddress = r2CLoginZone.GateAddress;
            zoneScene.GetComponent<AccountInfoComponent>().GateKey = r2CLoginZone.GateKey;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> LoginGate(Scene zoneScene)
        {
            string gateUrl = zoneScene.GetComponent<AccountInfoComponent>().GateAddress;
            long gateKey = zoneScene.GetComponent<AccountInfoComponent>().GateKey;

            G2C_Login2Gate g2CLogin2Gate = null;
            Session gateSession = await RouterHelper.CreateRouterSession(zoneScene, NetworkHelper.ToIPEndPoint(gateUrl));

            PingComponent pingComponent = gateSession.GetComponent<PingComponent>();
            if (pingComponent == null)
                gateSession.AddComponent<PingComponent>();

            zoneScene.GetComponent<SessionComponent>().Session = gateSession;
            g2CLogin2Gate = (G2C_Login2Gate)await gateSession.Call(new C2G_Login2Gate() { GateKey = gateKey });

            if (g2CLogin2Gate.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"登录Gate Error {g2CLogin2Gate.Error}");
                return g2CLogin2Gate.Error;
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRoleInfos(Scene zoneScene)
        {
            G2C_GetRoles g2CGetRoles = (G2C_GetRoles)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2G_GetRoles());
            if (g2CGetRoles.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"登录测试 G2C_GetRoles Error {g2CGetRoles.Error}");
                return g2CGetRoles.Error;
            }

            zoneScene.GetComponent<RoleInfosComponent>().Clear();

            if (g2CGetRoles?.Roles?.Count > 0)
            {
                foreach (var roleInfoProto in g2CGetRoles?.Roles)
                {
                    zoneScene.GetComponent<RoleInfosComponent>().Add(roleInfoProto);
                }
            }
            else
            {
                await CreateRole(zoneScene);
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> CreateRole(Scene zoneScene)
        {
            G2C_CreateRole g2C_CreateRole = (G2C_CreateRole)await zoneScene.GetComponent<SessionComponent>().Session
                    .Call(new C2G_CreateRole() { Name = $"华林自动({RandomGenerator.RandInt32()})" });

            if (g2C_CreateRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"登录测试 G2C_CreateRole Error {g2C_CreateRole.Error}");
                return g2C_CreateRole.Error;
            }

            zoneScene.GetComponent<RoleInfosComponent>().Add(g2C_CreateRole.Role);
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> DeleteRoleById(Scene zoneScene, long unitId)
        {
            G2C_DeleteRole g2CDeleteRole = (G2C_DeleteRole)await zoneScene.GetComponent<SessionComponent>().Session
                    .Call(new C2G_DeleteRole() { UnitId = unitId });

            if (g2CDeleteRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"登录测试 DeleteRole {g2CDeleteRole.Error}");
                return g2CDeleteRole.Error;
            }

            zoneScene.GetComponent<RoleInfosComponent>().RemoveById(unitId);

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> EnterMap(Scene zoneScene)
        {
            if (!zoneScene.GetComponent<RoleInfosComponent>().IsCurrentRoleExist())
            {
                return ErrorCode.ERR_Login_RoleNotExits;
            }

            long RoleId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId;

            var g2C_Enter2Map = (G2C_Enter2Map)await zoneScene.GetComponent<SessionComponent>().Session
                    .Call(new C2G_Enter2Map() { UnitId = RoleId });

            if (g2C_Enter2Map.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"登录测试 EnterMap {g2C_Enter2Map.Error}");
                return g2C_Enter2Map.Error;
            }

            zoneScene.GetComponent<PlayerComponent>().MyId = RoleId;

            if (g2C_Enter2Map.InQueue)
            {
                EventSystem.Instance.Publish(zoneScene, new UpdateQueueInfo() { Count = g2C_Enter2Map.Count, Index = g2C_Enter2Map.Index });
                return ErrorCode.ERR_Success;
            }
            else
            {
            }

            //等待场景切换完成
            await zoneScene.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();

            EventSystem.Instance.Publish(zoneScene, new EnterMapFinish());

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> CancelQueue(Scene zoneScene)
        {
            long CurrentRoleId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId;
            G2C_CancelQueue g2c_CancelQueue = (G2C_CancelQueue)await zoneScene.GetComponent<SessionComponent>().Session
                    .Call(new C2G_CancelQueue() { UnitId = CurrentRoleId });
            if (g2c_CancelQueue.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"取消排队 G2C_CancelQueue Error {g2c_CancelQueue.Error}");
                return g2c_CancelQueue.Error;
            }

            return ErrorCode.ERR_Success;
        }
    }
}