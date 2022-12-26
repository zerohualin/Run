// using System;
// using System.Collections.Generic;
//
// namespace ET
// {
//     [FriendClass(typeof(RoleInfo))]
//     public class C2A_GetRolesHandler : AMRpcHandler<C2A_GetRoles, A2C_GetRoles>
//     {
//         protected override async ETTask Run(Session session, C2A_GetRoles request, A2C_GetRoles response, Action reply)
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
//             if (session.GetComponent<SessionLockingComponent>() != null)
//             {
//                 response.Error = ErrorCode.ERR_RequestRepeatedly;
//                 reply();
//                 session?.Disconnect().Coroutine();
//                 return;
//             }
//
//             var DBComponent = session.DomainScene().GetComponent<DBComponent>();
//             //这个锁需要与创建角色一致，这样能保证刚刚创建的也会被拿到
//             using (session.AddComponent<SessionLockingComponent>())
//             {
//                 using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole, request.AccountId))
//                 {
//                     var roleInfos = await DBComponent.Query<RoleInfo>(d =>
//                         d.AccountId == request.AccountId &&
//                         d.ServerId == request.ServerId &&
//                         d.State == (int)RoleState.Normal);
//
//                     for (int i = 0; i < roleInfos.Count; i++)
//                     {
//                         response.RoleInfos.Add(roleInfos[i].ToMessage());
//                     }
//
//                     roleInfos.Clear();
//                     reply();
//                 }
//             }
//         }
//     }
// }