using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 类似AIDispatcher，是全局的，整个进程只有一个，因为其本身就是一个无状态函数封装
    /// </summary>
    public class B2S_CollisionDispatcherComponent : Entity
    {
        public static B2S_CollisionDispatcherComponent Instance;

        public Dictionary<string, AB2S_CollisionHandler> B2SCollisionHandlers = new Dictionary<string, AB2S_CollisionHandler>();
    }
}