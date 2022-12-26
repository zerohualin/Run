// using System;
//
// namespace ET
// {
//     [FriendClass(typeof(RoleInfo))]
//     public class C2A_CreateRoleHandler : AMRpcHandler<C2A_CreateRole, A2C_CreateRole>
//     {
//         protected override async ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response,
//             Action reply)
//         {
//             if (!session.CheckSceneType(SceneType.Account))
//             {
//                 return;
//             }
//
//             if (!session.CheckToken(request.AccountId, request.Token))
//             {
//                 response.Error = ErrorCode.ERR_TokenError;
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             if (string.IsNullOrEmpty(request.Name))
//             {
//                 response.Error = ErrorCode.ERR_RoleNameIsNum;
//                 reply();
//                 return;
//             }
//
//             if(session.GetComponent<SessionLockingComponent>() != null)
//             {
//                 response.Error = ErrorCode.ERR_RequestRepeatedly;
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             using (session.AddComponent<SessionLockingComponent>())
//             {
//                 using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole, request.AccountId))
//                 {
//                     var DBComponent = session.DomainScene().GetComponent<DBComponent>();
//                     var roleInfos =
//                         await DBComponent.Query<RoleInfo>(d => d.Name == request.Name && d.ServerId == request.ServerId);
//
//                     if (roleInfos.HaveResult())
//                     {
//                         response.Error = ErrorCode.ERR_RoleNameUsed;
//                         reply();
//                         return;
//                     }
//
//                     RoleInfo newRoleInfo =
//                         session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
//                     newRoleInfo.Name = request.Name;
//                     newRoleInfo.State = (int)RoleState.Normal;
//                     newRoleInfo.ServerId = request.ServerId;
//                     newRoleInfo.AccountId = request.AccountId;
//                     newRoleInfo.CreateTime = TimeHelper.ServerNow();
//                     newRoleInfo.LastLoginTime = 0;
//                     await DBComponent.Save(newRoleInfo);
//
//                     response.RoleInfo = newRoleInfo.ToMessage();
//                     reply();
//                     newRoleInfo?.Dispose();
//                 }
//             }
//         }
//     }
// }