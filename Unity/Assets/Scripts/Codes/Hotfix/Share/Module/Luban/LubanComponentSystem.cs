using Bright.Serialization;
using System;

namespace ET
{
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