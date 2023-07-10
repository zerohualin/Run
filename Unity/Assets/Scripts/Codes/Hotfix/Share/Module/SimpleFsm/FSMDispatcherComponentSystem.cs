using System;

namespace ET
{
    [FriendOf(typeof(AIDispatcherComponent))]
    public static class FSMDispatcherComponentSystem
    {
        [ObjectSystem]
        public class FSMDispatcherComponentAwakeSystem: AwakeSystem<FSMDispatcherComponent>
        {
            protected override void Awake(FSMDispatcherComponent self)
            {
                FSMDispatcherComponent.Instance = self;
                
                self.FSMHandlers.Clear();
            
                var types = EventSystem.Instance.GetTypes(typeof (FSMHandlerAttribute));
                foreach (Type type in types)
                {
                    AFSMHandler aaiHandler = Activator.CreateInstance(type) as AFSMHandler;
                    if (aaiHandler == null)
                    {
                        Log.Error($"No AFSMHandler: {type.Name}");
                        continue;
                    }
                    self.FSMHandlers.Add(type.Name, aaiHandler);
                }
            }
        }
        
        [ObjectSystem]
        public class FSMDispatcherComponentDestroySystem: DestroySystem<FSMDispatcherComponent>
        {
            protected override void Destroy(FSMDispatcherComponent self)
            {
                self.FSMHandlers.Clear();
                FSMDispatcherComponent.Instance = null;
            }
        }
    }
}