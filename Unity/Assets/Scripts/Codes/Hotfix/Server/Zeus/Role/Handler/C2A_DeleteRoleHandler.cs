// using System;
//
// namespace ET
// {
//     [FriendClass(typeof(RoleInfo))]
//     public class C2A_DeleteRoleHandler : AMRpcHandler<C2A_DeleteRole, A2C_DeleteRole>
//     {
//         protected override async ETTask Run(Session session, C2A_DeleteRole request, A2C_DeleteRole response, Action reply)
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
//                     var roleInfos =  await DBComponent.Query<RoleInfo>(d =>
//                         d.Id == request.RoleInfoId &&
//                         d.ServerId == request.ServerId
//                     );
//                     
//                     if (!roleInfos.HaveResult())
//                     {
//                         response.Error = ErrorCode.ERR_RoleNotExit;
//                         reply();
//                         return;
//                     }
//
//                     var roleInfo = roleInfos[0];
//                     session.AddChild(roleInfo);
//                     //更改状态而不是直接删除
//                     roleInfo.State = (int)RoleState.Freeze;
//
//                     await DBComponent.Save(roleInfo);
//                     response.DeletedRoleInfoId = roleInfo.Id;
//                     roleInfo?.Dispose();
//                     
//                     reply();
//                 }
//             }
//         }
//     }
// }