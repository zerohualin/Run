using Bright.Serialization;
using System;

namespace ET
{
    [ObjectSystem]
    public class LubanAwakeSystem: AwakeSystem<LubanComponent>
    {
        protected override void Awake(LubanComponent self)
        {
            LubanComponent.Instance = self;
        }
    }

    [ObjectSystem]
    public class LubanDestroySystem: DestroySystem<LubanComponent>
    {
        protected override void Destroy(LubanComponent self)
        {
            LubanComponent.Instance = null;
        }
    }

    [FriendOf(typeof(LubanComponent))]
    public static class LubanComponentSystem
    {
        public static void LoadOneConfig(this LubanComponent self, Type configType)
        {
        }

        public static async ETTask LoadAsync(this LubanComponent self, Func<string, ByteBuf> loadFunc)
        {
            self.Tables = new Cfg.Tables(loadFunc);
            await ETTask.CompletedTask;
        }
    }
}