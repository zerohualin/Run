// using System;
// using System.Threading.Tasks;
//
// namespace ET
// {
//     public class G2M_RequestExitGameHandler : AMActorLocationRpcHandler<Unit, G2M_RequestExitGame, M2G_RequestExitGame>
//     {
//         protected override async ETTask Run(Unit unit, G2M_RequestExitGame request, M2G_RequestExitGame response, Action reply)
//         {
//             //TODO 保存玩家数据岛数据库，执行相关下线操作
//             Log.Info("开始下线保存玩家的数据");
//             unit.GetComponent<UnitDBSaveComponent>()?.SaveChange();
//             reply();
//             
//             //正式释放 Unit
//             await unit.RemoveLocation();
//             UnitComponent unitComponent = unit.DomainScene().GetComponent<UnitComponent>();
//             unitComponent.Remove(unit.Id);
//             
//             await ETTask.CompletedTask;
//         }
//     }
// }