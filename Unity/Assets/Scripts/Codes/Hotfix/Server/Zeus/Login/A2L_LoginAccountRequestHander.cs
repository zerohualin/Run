// using System;
//
// namespace ET.Server
// {
//     public class A2L_LoginAccountRequestHander : AMActorRpcHandler<Scene, A2L_LoginAccountRequest, L2A_LoginAccountResponse>
//     {
//         protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request,
//             L2A_LoginAccountResponse response, Action reply)
//         {
//             long accountId = request.AccountId;
//             using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock,
//                        accountId.GetHashCode()))
//             {
//                 if (!scene.GetComponent<LoginInfoRecordComponent>().IsExit(accountId))
//                 {
//                     reply();
//                     return;
//                 }
//
//                 int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);
//                 StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone);
//
//                 var g2L_DisconnectGateUnit = (G2L_DisconnectGateUnit)await MessageHelper.CallActor(
//                     gateConfig.InstanceId,
//                     new L2G_DisconnectGateUnit() { AccountId = accountId });
//
//                 response.Error = g2L_DisconnectGateUnit.Error;
//                 reply();
//             }
//         }
//     }
// }