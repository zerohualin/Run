namespace ET.Server
{
    public class SessionUserComponentAwakeSystem : AwakeSystem<SessionUserComponent,long>
    {
        protected override void Awake(SessionUserComponent self, long instanceId)
        {
            self.GateUserInstanceId = instanceId;
        }
    }
    
    public class SessionUserComponentDestroySystem : DestroySystem<SessionUserComponent>
    {
        protected override void Destroy(SessionUserComponent self)
        {
            GateUser gateUser = self.User;
            if (gateUser != null && !self.GetParent<Session>().IsDisposed)
            {
                //如果是主动断开，应该先移除SessionUserComponent 再销毁Session，否则就是突然断开了
                //Session突然断开，一段时间后没重连就下线
                gateUser.AddComponent<GateUserDisconnectComponent, long>(ConstValue.Login_SessionDisconnectTime);
            }

            self.GateUserInstanceId = 0;
        }
    }

    public static class SessionUserComponentSystem
    {
        
    }
}