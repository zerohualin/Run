using System;

namespace ET
{
    [ObjectSystem]
    public class FsmComponentAwakeSystem : AwakeSystem<FSMComponent>
    {
        protected override void Awake(FSMComponent self)
        {
            self.States.Clear();
        }
    }
    
    [ObjectSystem]
    public class FsmComponentUpdateSystem: UpdateSystem<FSMComponent>
    {
        protected override void Update(FSMComponent self)
        {
            if(self.curFSMHandler == null)
                return;
            self.curFSMHandler.OnUpdate(self);
        }
    }

    [FriendOfAttribute(typeof(ET.FSMComponent))]
    [FriendOfAttribute(typeof(ET.FSMDispatcherComponent))]
    public static class FSMComponentSystem
    {
        public static void AddState<T>(this FSMComponent self) where T : AFSMHandler
        {
            string stateName = typeof(T).Name;
            FSMDispatcherComponent.Instance.FSMHandlers.TryGetValue(stateName, out AFSMHandler aFSMHandler);
            if(aFSMHandler == null)
                Log.Error("这个状态不存在啊？");
            self.States.Add(stateName, aFSMHandler);
            aFSMHandler.OnInit(self);
        }

        public static void Init<T>(this FSMComponent self) where T : AFSMHandler
        {
            self.Change<T>();
        }

        public static void Change<T>(this FSMComponent self) where T : AFSMHandler
        {
            string stateName = typeof(T).Name;
            self.Change(stateName);
        }
        
        public static void Change(this FSMComponent self, string targetState)
        {
            if (self.curFSMHandler != null)
                self.curFSMHandler.OnExit(self).Coroutine();
            self.States.TryGetValue(targetState, out AFSMHandler aFSMHandler);
            if(aFSMHandler == null)
                Log.Error("我没这个状态啊？");
            self.curFSMHandler = aFSMHandler;
            self.curFSMHandler.OnEnter(self).Coroutine();
        }
        
        public static void Post(this FSMComponent self, FSMAct act)
        {
            if (self.curFSMHandler == null)
                Log.Error("额 出问题了，怎么没状态了");

            if (self.curFSMHandler.TransitionMap.ContainsKey(act))
            {
                string target = self.curFSMHandler.Post(act);
                self.Change(target);
            }
            
            if (self.curFSMHandler.ActMap.ContainsKey(act))
            {
                self.curFSMHandler.ActMap.TryGetValue(act, out Action action);
                if (action != null)
                    action();
            }
        }
    }
}