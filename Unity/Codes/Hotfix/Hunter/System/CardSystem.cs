namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof (LubanComponent))]
    public class CardAwakeSystem: AwakeSystem<Card, int>
    {
        public override void Awake(Card self, int configId)
        {
            self.Config = Game.Scene.GetComponent<LubanComponent>().Tables.TbCardConfig.Get(configId);
        }
    }
}