using UnityEngine;

namespace ET
{
    public class EnemyAwakeSystem: AwakeSystem<Enemy>
    {
        public override void Awake(Enemy self)
        {
            self.AddComponent<EnemyFishAiComponent>();
            self.AddComponent<EnemyMoveComponent>();
            
            self.Pos = new Vector3(Random.Range(40.0f, 50.0f), 0, Random.Range(40.0f, 50.0f));

            self.GetComponent<EnemyMoveComponent>();

            Game.EventSystem.Publish(new EventType.InitEnemy() { Enemy = self });
        }
    }
}