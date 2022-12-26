using ET.Server;

namespace ET
{
    [ObjectSystem]
    public class RealmAccountComponentAwakeSystem : AwakeSystem<RealmAccountComponent>
    {
        protected override void Awake(RealmAccountComponent self)
        {
            
        }
    }
    
    [ObjectSystem]
    public class RealmAccountComponentDestroySystem : DestroySystem<RealmAccountComponent>
    {
        protected override void Destroy(RealmAccountComponent self)
        {
            self.AccountDB = null;
        }
    }

    public static class RealmAccountComponentSystem 
    {

    }
}
