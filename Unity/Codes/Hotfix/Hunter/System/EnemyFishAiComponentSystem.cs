using UnityEngine;

namespace ET
{
    public static class EnemyFishAiComponentSystem
    {
        public static void GetNearFinishs(this EnemyFishAiComponent self)
        {
            self.NearFishList.Clear();
            Vector3 myPos = self.GetParent<Enemy>().Pos;
            var Enemys = self.DomainScene().GetComponent<EnemyComponent>().Children;
            float minDis = 10000000000;
            foreach (var VARIABLE in Enemys)
            {
                var enemy = VARIABLE.Value as Enemy;
                if(enemy.Id == self.Id)
                    continue;
                
                float dis = Vector3.Distance(enemy.Pos, myPos);
                if (dis < self.Visuanl)
                {
                    self.NearFishList.Add(enemy);
                }

                if (dis < minDis)
                {
                    self.NearFish = enemy;
                    minDis = dis;
                }
            }
        }
    }

    public class EnemyFinishAiComponentUpdateSystem: UpdateSystem<EnemyFishAiComponent>
    {
        public override void Update(EnemyFishAiComponent self)
        {
            self.GetNearFinishs();
            // var averageDir = Vector3.zero;
            // foreach (var Fish in self.NearFishList)
            // {
            //     averageDir += Fish.GetComponent<EnemyMoveComponent>().Dir;
            // }

            var averageDir = self.NearFish.GetComponent<EnemyMoveComponent>().Dir;

            if (averageDir.magnitude == 0)
            {
                averageDir = new Vector3(Random.Range(-1.0f, 1), 0, Random.Range(-1.0f, 1));
            }
            else
            {
                // averageDir = averageDir / self.NearFishList.Count;
            }

            self.GetParent<Enemy>().GetComponent<EnemyMoveComponent>().Dir = averageDir;
        }
    }
}