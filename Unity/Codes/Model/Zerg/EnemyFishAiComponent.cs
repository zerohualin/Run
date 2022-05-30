using System.Collections.Generic;

namespace ET
{
    public class EnemyFishAiComponent : Entity, IAwake, IUpdate
    {
        public List<Enemy> NearFishList = new List<Enemy>();
        public Enemy NearFish = null;
        public float Visuanl = 3;
    }
}