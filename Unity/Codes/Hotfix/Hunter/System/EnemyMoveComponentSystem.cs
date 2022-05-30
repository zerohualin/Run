using UnityEngine;

namespace ET
{
    public class EnemyMoveComponentAwakeSystem: AwakeSystem<EnemyMoveComponent>
    {
        public override void Awake(EnemyMoveComponent self)
        {
            self.Speed = 3;
        }
    }
    
    public class EnemyMoveComponentUpdateSystem: UpdateSystem<EnemyMoveComponent>
    {
        public override void Update(EnemyMoveComponent self)
        {
            if (self.Target.magnitude == 0)
            {
                
            }
            else
            {
                var Pos = self.GetParent<Enemy>().Pos;
                self.Dir = self.Target - Pos;
            }
            
            if (self.Dir.magnitude == 0)
                return;

            if (self.Dir.magnitude > 1)
            {
                self.Dir = self.Dir.normalized;
            }
            
            self.MoveVector = self.Dir * self.Speed;
            var enemy = self.GetParent<Enemy>();
            enemy.Pos += self.MoveVector * Time.deltaTime;
        }
    }
    
    public static class EnemyMoveComponentSystem
    {
        public static void MoveTo(this EnemyMoveComponent self, Vector3 target)
        {
            self.Target = target;
        }
    }

}