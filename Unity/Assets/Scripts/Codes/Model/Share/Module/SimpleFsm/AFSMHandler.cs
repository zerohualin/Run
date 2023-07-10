using System;
using System.Collections.Generic;

namespace ET
{
    public class FSMHandlerAttribute: BaseAttribute
    {
    }
    
    [FSMHandler]
    public class AFSMHandler
    {
        public Dictionary<FSMAct, string> TransitionMap;
        public Dictionary<FSMAct, Action> ActMap;
        public virtual void OnInit(FSMComponent fsmComponent)
        {
            this.TransitionMap = new Dictionary<FSMAct, string>();
            this.ActMap = new Dictionary<FSMAct, Action>();
        }
        public async virtual ETTask OnEnter(FSMComponent fsmComponent)
        {
            await ETTask.CompletedTask;
        }
        public async virtual ETTask OnExit(FSMComponent fsmComponent)
        {
            await ETTask.CompletedTask;
        }

        public virtual void OnUpdate(FSMComponent fsmComponent) { }

        public void AddAction<T>(FSMAct act) where T : AFSMHandler
        {
            string targetName = typeof (T).Name;
            bool t = this.TransitionMap.TryGetValue(act, out string target);
            if(t)
                Log.Error($"这 FSMAct{act.ToString()} 已经有了！");
            TransitionMap[act] = targetName;
        }
        public void AddAction<T>(FSMAct act, Action action) where T : AFSMHandler
        {
            string targetName = typeof (T).Name;
            bool t = this.TransitionMap.TryGetValue(act, out string target);
            if(t)
                Log.Error($"这 FSMAct{act.ToString()} 已经有了！");
            ActMap[act] = action;
        }
        public string Post(FSMAct act)
        {
            TransitionMap.TryGetValue(act, out string stateName);
            return stateName;
        }
    }
}