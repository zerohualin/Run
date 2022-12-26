namespace ET.Server
{
    // 顶号和多次登录标识（GateUser）
    [ComponentOf(typeof(GateUser))]
    public class MultiLoginComponent: Entity, IAwake, IDestroy
    {
        public long Timer_Over;
    }
}