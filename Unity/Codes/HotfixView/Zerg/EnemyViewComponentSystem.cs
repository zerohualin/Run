using UnityEngine;

namespace ET
{
    public class EnemyViewComponentAwakeSystem: AwakeSystem<EnemyViewComponent>
    {
        public override void Awake(EnemyViewComponent self)
        {
            string path = "Assets/Bundles/Zerg/Prefabs/fly_02.prefab";
            var obj = AddressableComponent.Instance.LoadAssetByPath<GameObject>(path);
            self.Obj = GameObject.Instantiate(obj);
            self.Obj.transform.position = self.GetParent<Enemy>().Pos;
        }
    }

    public class EnemyViewComponentUpdateSystem: UpdateSystem<EnemyViewComponent>
    {
        public override void Update(EnemyViewComponent self)
        {
            self.Obj.transform.position = self.GetParent<Enemy>().Pos;
            var dir = self.GetParent<Enemy>().GetComponent<EnemyMoveComponent>().Dir;
            float angle = Vector3.Angle(Vector3.forward, dir);
            Vector3 cross = Vector3.Cross(Vector3.forward, dir);
            if (cross.y < 0)
                angle = -angle;
            self.Obj.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
    }
}