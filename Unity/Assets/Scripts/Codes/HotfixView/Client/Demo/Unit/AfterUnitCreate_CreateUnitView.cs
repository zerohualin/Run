using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView: AEvent<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterUnitCreate args)
        {
            Unit unit = args.Unit;
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            // GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            // GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");
            
            GameObject go = new GameObject($"Unit{unit.ConfigId}");
            go.transform.position = unit.Position;
            GameObjectComponent gameObjectComponent = unit.AddComponent<GameObjectComponent>();
            gameObjectComponent.SetObj(go);
            AvatarComponent AvatarComponent = unit.AddComponent<AvatarComponent>();
            await AvatarComponent.Init();
            
            if (unit.Type == UnitType.Player)
            {
                unit.AddComponent<PlayerCameraComponent>();
            }

            await ETTask.CompletedTask;
        }
    }
}