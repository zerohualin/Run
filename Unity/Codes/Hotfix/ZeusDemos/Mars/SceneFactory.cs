using Box2DSharp.Collision.Shapes;
using Box2DSharp.Dynamics;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(Unit))]
    public static partial class SceneFactory
    {
        public static async ETTask<Scene> CreateMarsZoneSceneAsync(int zone, string name, Entity parent)
        {
            Scene zoneScene = EntitySceneFactory.CreateScene(Game.IdGenerater.GenerateInstanceId(), zone, SceneType.Zone, name, parent);
            zoneScene.AddComponent<CurrentScenesComponent>();
            zoneScene.GetComponent<CurrentScenesComponent>().Scene = zoneScene;
            
            zoneScene.AddComponent<ZoneSceneFlagComponent>();
            zoneScene.AddComponent<ObjectWait>();
            zoneScene.AddComponent<PlayerComponent>();
            zoneScene.AddComponent<B2S_ColliderDataRepositoryComponent>();
            zoneScene.AddComponent<RoomManagerComponent>();
            
            var room = zoneScene.GetComponent<RoomManagerComponent>().GetOrCreateBattleRoom();
            
            await Game.EventSystem.PublishAsync(new EventType.AfterCreateZoneScene() { ZoneScene = zoneScene });

            Game.Scene.AddComponent<BenchmarkComponent>();
            
            Game.Scene.GetComponent<BenchmarkComponent>().Profile("测试创建1000个碰撞体", () =>
            {
                BodyDef bodyDef = new BodyDef { BodyType = BodyType.DynamicBody };
                Body m_Body = room.GetComponent<B2S_WorldComponent>().GetWorld().CreateBody(bodyDef);
                CircleShape m_CircleShape = new CircleShape();
                m_CircleShape.Radius = 5;
                m_Body.CreateFixture(m_CircleShape, 5);
            }, 999);
            
            var unit = MarsUnitFactory.CreateUnit(room, IdGenerater.Instance.GenerateUnitId(zoneScene.Zone), 1001);
            MarsUnitFactory.CreateSpecialColliderUnit(unit.BelongToRoom, unit.Id, 100101, 10001, 1, true, true, new Vector3(0, 0, 0), new Vector3(0, 0, 0), 0);
            
            return zoneScene;
        }
        
        public static void UnitTest_CreateCollision()
        {

        }
    }
}