using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class C2M_SayHiHandler: AMActorLocationRpcHandler<Unit, C2M_SayHi, M2C_SayHi>
    {
        protected override async ETTask Run(Unit unit, C2M_SayHi request, M2C_SayHi response, Action reply)
        {
            UnitComponent unitComponent = unit.GetParent<UnitComponent>();
            long TargetId = request.TargetId;
            Unit target = unitComponent.Get(TargetId);
            response.Msg = $"{target.Config.Name} Do you say : {request.Msg} ? ";
            reply();
            await ETTask.CompletedTask;
        }
    }
}