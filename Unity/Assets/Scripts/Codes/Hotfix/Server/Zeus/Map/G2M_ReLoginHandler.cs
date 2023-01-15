namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class G2M_ReLoginHandler : AMActorLocationHandler<Unit, G2M_ReLogin>
    {
        protected override async ETTask Run(Unit unit, G2M_ReLogin message)
        {
            await ETTask.CompletedTask;
        }
    }
}