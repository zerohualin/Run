using System;
using System.Diagnostics;

namespace ET.Server
{
    [MessageHandler(SceneType.Realm)]
    [FriendOfAttribute(typeof(ET.Server.AccountDB))]
    [FriendOfAttribute(typeof(ET.Server.RealmAccountComponent))]
    public class C2A_LoginAccountHandler : AMRpcHandler<C2R_LoginAccount, R2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2R_LoginAccount request, R2C_LoginAccount response,
        Action reply)
        {
            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (!session.CheckSceneType(SceneType.Realm))
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            int modCount = request.Account.Mode(StartSceneConfigCategory.Instance.Realms.Count);
            if (session.DomainScene().InstanceId != StartSceneConfigCategory.Instance.Realms[modCount].InstanceId)
            {
                response.Error = ErrorCode.ERR_Login_RealmAdressError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_Repeatedly;
                reply();
                return;
            }

            if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))
            {
                response.Error = ErrorCode.ERR_Login_AccountOrPasswordWrongFormat;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // if (!Regex.IsMatch(request.Account.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=[a-z].*).{6,15}$"))
            // {
            //     response.Error = ErrorCode.ERR_AccountFormatError;
            //     reply();
            //     session.Disconnect().Coroutine();
            //     return;
            // }

            // if (!Regex.IsMatch(request.Password.Trim(), @"^[A-Za-z0-9]+$"))
            // {
            //     response.Error = ErrorCode.ERR_AccountFormatError;
            //     reply();
            //     session.Disconnect().Coroutine();
            //     return;
            // }

            RealmAccountComponent realmAccountComponent = session.GetComponent<RealmAccountComponent>();
            if (realmAccountComponent != null)
            {
                response.Error = ErrorCode.ERR_Login_RepeatLogin;
                reply();
                return;
            }

            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.Account.Trim().GetLongHashCode()))
            {
                var dbProxy = session.GetDirectDB();
                var accountInfos = await dbProxy.Query<AccountDB>(d => d.Account == request.Account);
                
                AccountDB accountDB = null;
                if (accountInfos != null && accountInfos.Count > 0)
                {
                    accountDB = accountInfos[0];
                }

                if (Options.Instance.Develop == 0)
                {
                    if (accountDB == null)
                    {
                        response.Error = ErrorCode.ERR_Login_AccountNotExits;
                        reply();
                        return;
                    }
                    
                    if (accountDB.AccountType == (int)AccountType.BlackList)
                    {
                        response.Error = ErrorCode.ERR_AccountInBlackListError;
                        reply();
                        session.Disconnect().Coroutine();
                        accountDB?.Dispose();
                        return;
                    }

                    if (!accountDB.Password.Equals(request.Password))
                    {
                        response.Error = ErrorCode.ERR_Login_PasswordWrong;
                        reply();
                        session.Disconnect().Coroutine();
                        accountDB?.Dispose();
                        return;
                    }
                }
                else
                {
                    if (accountDB == null)
                    {
                        accountDB = session.AddChildWithId<AccountDB>(IdGenerater.Instance.GenerateUnitId(session.DomainZone()));
                        accountDB.Account = request.Account.Trim();
                        accountDB.Password = request.Password;
                        accountDB.CreateTime = TimeHelper.ServerNow();
                        accountDB.AccountType = (int)AccountType.General;
                        await dbProxy.Save(accountDB);
                    }
                }

                // //登录中心服
                // StartSceneConfig sceneConfig =
                //     StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "LoginCenter");
                // long loginCenterInstanceId = sceneConfig.InstanceId;
                // var loginAccountResponse =
                //     (L2A_LoginAccountResponse)await ActorMessageSenderComponent.Instance.Call(loginCenterInstanceId,
                //         new A2L_LoginAccountRequest() { AccountId = account.Id });
                // if (loginAccountResponse.Error != ErrorCode.ERR_Success)
                // {
                //     response.Error = loginAccountResponse.Error;
                //     reply();
                //     session.Disconnect().Coroutine();
                //     account?.Dispose();
                //     return;
                // }
                //
                // //是否有已经登录的玩家，有的话通知它，并把它踢掉
                // long otherSeesionInstanceId =
                //     session.DomainScene().GetComponent<AccountSessionsComponent>().Get(account.Id);
                // Session otherSession = Game.EventSystem.Get(otherSeesionInstanceId) as Session;
                // otherSession?.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_Success });
                // otherSession?.Disconnect().Coroutine();
                //
                // session.DomainScene().GetComponent<AccountSessionsComponent>().Add(account.Id, session.InstanceId);
                // //增加session十分钟自动断线（有些情况下，玩家断开了但是服务器不知道，所以服务器需要主动去断开）
                // session.AddComponent<AccountCheckoutTimeComponent, long>(account.Id);
                //
                // string Token = TimeHelper.ServerNow().ToString() +
                //                RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                //
                // session.DomainScene().GetComponent<TokenComponent>().Remove(account.Id);
                // session.DomainScene().GetComponent<TokenComponent>().Add(account.Id, Token);
                //
                // response.AccountId = account.Id;
                // response.Token = Token;

                realmAccountComponent = session.AddComponent<RealmAccountComponent>();
                realmAccountComponent.AccountDB = accountDB;
                realmAccountComponent.AddChild(accountDB);
            }

            response.Error = ErrorCode.ERR_Success;
            reply();

            await ETTask.CompletedTask;
        }
    }
}