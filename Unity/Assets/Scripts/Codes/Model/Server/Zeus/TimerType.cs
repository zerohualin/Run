namespace ET.Server
{
    public partial class TimerType
    {
        public const int MultiLogin = 3005; //顶号时上个角色保留时间
        public const int GateUserDisconnect = 3006; //顶号保留时间

        public const int QueueTickTime = 3007; //排队检测放人
        public const int QueueUpdateTime = 3008; //排队更新排名
        public const int QueueClearProtect = 3009; //排队定时清楚掉线保护信息
    }
}