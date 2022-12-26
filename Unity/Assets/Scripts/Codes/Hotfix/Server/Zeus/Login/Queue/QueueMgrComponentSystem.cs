namespace ET.Server
{
    public class QueueMgrComponentAwakeSystem: AwakeSystem<QueueMgrComponent>
    {
        protected override void Awake(QueueMgrComponent self)
        {
            self.Timer_Trick = TimerComponent.Instance.NewRepeatedTimer(ConstValue.Queue_TickTime, TimerType.QueueTickTime, self);
            self.Timer_ClearProtect = TimerComponent.Instance.NewRepeatedTimer(ConstValue.Queue_ProtectTime, TimerType.QueueClearProtect, self);
            self.Timer_Update = TimerComponent.Instance.NewRepeatedTimer(ConstValue.Queue_TickUpdate, TimerType.QueueUpdateTime, self);
        }
    }

    public class QueueMgrComponentDestroySystem: DestroySystem<QueueMgrComponent>
    {
        protected override void Destroy(QueueMgrComponent self)
        {
            TimerComponent.Instance.Remove(ref self.Timer_Trick);
            TimerComponent.Instance.Remove(ref self.Timer_ClearProtect);
            TimerComponent.Instance.Remove(ref self.Timer_Update);

            self.Online.Clear();
            self.Protects.Clear();
            self.Queue.Clear();
        }
    }

    [Invoke(TimerType.QueueTickTime)]
    public class QueueTickTime_TimerHander: ATimer<QueueMgrComponent>
    {
        protected override void Run(QueueMgrComponent t)
        {
            t.Tick();
        }
    }

    [Invoke(TimerType.QueueClearProtect)]
    public class QueueClearProtect_TimerHander: ATimer<QueueMgrComponent>
    {
        protected override void Run(QueueMgrComponent t)
        {
            t.ClearProtect();
        }
    }

    [Invoke(TimerType.QueueUpdateTime)]
    public class QueueUpdateTime_TimerHander: ATimer<QueueMgrComponent>
    {
        protected override void Run(QueueMgrComponent t)
        {
            t.UpdateQueue();
        }
    }

    [FriendOfAttribute(typeof (ET.Server.QueueMgrComponent))]
    [FriendOfAttribute(typeof (ET.Server.QueueInfo))]
    public static class QueueMgrComponentSystem
    {
        //尝试进队，返回true 代表需要排队，false可以直接进游戏
        public static bool TryEnqueue(this QueueMgrComponent self, string account, long unitId, long gateActorId)
        {
            if (self.Protects.ContainsKey(unitId))
            {
                self.Protects.Remove(unitId);
                if (self.Queue.ContainsKey(unitId))
                {
                    //排一半掉线，继续排队
                    return true;
                }

                //原本就在游戏中
                return false;
            }

            if (self.Online.Contains(unitId))
                return false;

            if (self.Queue.ContainsKey(unitId))
                return true;

            self.Enqueue(account, unitId, gateActorId);
            return true;
        }

        public static void Enqueue(this QueueMgrComponent self, string account, long unitId, long gateActorId)
        {
            if (self.Queue.ContainsKey(unitId))
                return;

            QueueInfo queueInfo = self.AddChild<QueueInfo>();
            queueInfo.Account = account;
            queueInfo.UnitId = unitId;
            queueInfo.GateActorId = gateActorId;
            queueInfo.Index = self.Queue.Count + 1;
            self.Queue.AddLast(unitId, queueInfo);
        }

        public static void Disconnect(this QueueMgrComponent self, long unitId, bool isProtect)
        {
            if (isProtect)
            {
                if (self.Protects.ContainsKey(unitId) || self.Queue.ContainsKey(unitId))
                {
                    //进入掉线保护
                    self.Protects.AddLast(unitId, new ProtectInfo() { UnitId = unitId, Time = TimeHelper.ServerNow() });
                }
                else
                {
                    self.Online.Remove(unitId);
                    self.Queue.Remove(unitId);
                    self.Protects.Remove(unitId);
                }
            }
        }

        public static void ClearProtect(this QueueMgrComponent self)
        {
            long targetTime = TimeHelper.ServerNow() - ConstValue.Queue_ProtectTime;
            while (self.Protects.Count > 0)
            {
                ProtectInfo protectInfo = self.Protects.First;
                if (self.Protects.First.Time > targetTime)
                {
                    break;
                }

                self.Disconnect(protectInfo.UnitId, false);
            }
        }

        public static int GetIndex(this QueueMgrComponent self, long unitId)
        {
            return self.Queue[unitId]?.Index ?? 1;
        }

        public static void Tick(this QueueMgrComponent self)
        {
            if (self.Online.Count >= ConstValue.Queue_MaxOnline)
            {
                //满人啦
                return;
            }

            for (int i = 0; i < ConstValue.Queue_TickCount; i++)
            {
                if (self.Queue.Count <= 0)
                    return;

                QueueInfo queueInfo = self.Queue.First;
                self.EnterMap(queueInfo.UnitId).Coroutine();
            }
        }

        public static async ETTask EnterMap(this QueueMgrComponent self, long unitId)
        {
            if (!self.Online.Add(unitId))
            {
                return;
            }

            QueueInfo queueInfo = self.Queue.Remove(unitId);
            if (queueInfo != null)
            {
                G2Queue_EnterMap g2Queue_EnterMap = (G2Queue_EnterMap)await MessageHelper.CallActor(queueInfo.GateActorId,
                    new Queue2G_EnterMap() { Account = queueInfo.Account, UnitId = queueInfo.UnitId });
                if (g2Queue_EnterMap.NeedRemove)
                {
                    self.Online.Remove(unitId);
                }

                queueInfo.Dispose();
            }

            await ETTask.CompletedTask;
        }

        public static void UpdateQueue(this QueueMgrComponent self)
        {
            using (DictionaryPoolComponent<long, Queue2G_UpdateInfo> dict = DictionaryPoolComponent<long, Queue2G_UpdateInfo>.Create())
            {
                using (var enumertor = self.Queue.GetEnumerator())
                {
                    int i = 1;
                    while (enumertor.MoveNext())
                    {
                        QueueInfo queueInfo = enumertor.Current;
                        queueInfo.Index = i;
                        ++i;
                        Queue2G_UpdateInfo queue2GUpdateInfo;
                        if (!dict.TryGetValue(queueInfo.GateActorId, out queue2GUpdateInfo))
                        {
                            queue2GUpdateInfo = new Queue2G_UpdateInfo() { Count = self.Queue.Count };
                            dict.Add(queueInfo.GateActorId, queue2GUpdateInfo);
                        }

                        queue2GUpdateInfo.Account.Add(queueInfo.Account);
                        queue2GUpdateInfo.Index.Add(queueInfo.Index);
                    }
                }

                foreach (var info in dict)
                {
                    MessageHelper.SendActor(info.Key, info.Value);
                }
            }
        }
    }
}