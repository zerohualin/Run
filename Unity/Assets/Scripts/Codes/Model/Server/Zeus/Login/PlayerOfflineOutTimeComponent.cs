namespace ET.Server
{
    [ComponentOf(typeof(Player))]
    public class PlayerOfflineOutTimeComponent : Entity, IAwake, IDestroy, IAwake<long>
    {
        public long Timer;
    }
}