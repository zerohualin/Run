namespace ET
{
    public class EnemyComponentAwakeSystem : AwakeSystem<EnemyComponent>
    {
        public override void Awake(EnemyComponent self)
        {
            for (int i = 0; i < 200; i++)
            {
                self.AddChild<Enemy>();
            }
        }
    }
}