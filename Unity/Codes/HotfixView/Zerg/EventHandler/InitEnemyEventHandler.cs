namespace ET
{
    public class InitEnemyEventHandler: AEvent<EventType.InitEnemy>
    {
        protected override void Run(EventType.InitEnemy args)
        {
            args.Enemy.AddComponent<EnemyViewComponent>();
        }
    }
}