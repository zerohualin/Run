namespace ET
{
    [FriendClass(typeof(CardPlayer))]
    public static class CardPlayerComponentSystem
    {

    }
    
    [ObjectSystem]
    [FriendClass(typeof (LubanComponent))]
    public class CardPlayerAwakeSystem: AwakeSystem<CardPlayer, int>
    {
        public override void Awake(CardPlayer self, int configId)
        {
            self.AddComponent<HandComponent>();
            self.AddComponent<EnergyComponent>();
        }
    }
}