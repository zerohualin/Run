using Bright.Serialization;
using System;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class LubanAwakeSystem: AwakeSystem<LubanComponent>
    {
        public override void Awake(LubanComponent self)
        {
            LubanComponent.Instance = self;
        }
    }

    [ObjectSystem]
    public class LubanDestroySystem: DestroySystem<LubanComponent>
    {
        public override void Destroy(LubanComponent self)
        {
            LubanComponent.Instance = null;
        }
    }

    [FriendClass(typeof(LubanComponent))]
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