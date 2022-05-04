﻿using Box2DSharp.Collision.Collider;
using Box2DSharp.Collision.Shapes;
using Box2DSharp.Dynamics;
using Box2DSharp.Dynamics.Contacts;

namespace ET
{
    [ObjectSystem]
    public class B2S_CollisionListenerComponentAwake: AwakeSystem<B2S_CollisionListenerComponent>
    {
        public override void Awake(B2S_CollisionListenerComponent self)
        {
            //绑定指定的物理世界，正常来说一个房间一个物理世界,这里是Demo，直接获取了
            self.Parent.GetComponent<B2S_WorldComponent>().GetWorld().SetContactListener(self);
            //self.TestCollision();
            self.B2SWorldColliderManagerComponent = self.Parent.GetComponent<B2S_WorldColliderManagerComponent>();
        }
    }

    [FriendClass(typeof (B2S_CollisionListenerComponent))]
    public static class B2S_CollisionListenerComponentSystem
    {
        public static void BeginContact(this B2S_CollisionListenerComponent self, Contact contact)
        {
            //这里获取的是碰撞实体，比如诺克Q技能的碰撞体Unit，这里获取的就是它
            Unit unitA = (Unit)contact.FixtureA.UserData;
            Unit unitB = (Unit)contact.FixtureB.UserData;

            if (unitA.IsDisposed || unitB.IsDisposed)
            {
                return;
            }

            self.m_CollisionRecorder.Add((unitA.Id, unitB.Id));

            B2S_CollisionDispatcherComponent.Instance.HandleCollisionStart(unitA, unitB);
            B2S_CollisionDispatcherComponent.Instance.HandleCollisionStart(unitB, unitA);
        }

        public static void EndContact(this B2S_CollisionListenerComponent self, Contact contact)
        {
            Unit unitA = (Unit)contact.FixtureA.UserData;
            Unit unitB = (Unit)contact.FixtureB.UserData;

            // Id不分顺序，防止移除失败
            self.m_ToBeRemovedCollisionData.Add((unitA.Id, unitB.Id));
            self.m_ToBeRemovedCollisionData.Add((unitB.Id, unitA.Id));

            if (unitA.IsDisposed || unitB.IsDisposed)
            {
                return;
            }

            B2S_CollisionDispatcherComponent.Instance.HandleCollsionEnd(unitA, unitB);
            B2S_CollisionDispatcherComponent.Instance.HandleCollsionEnd(unitB, unitA);
        }

        public static void PreSolve(this B2S_CollisionListenerComponent self, Contact contact, in Manifold oldManifold)
        {
        }

        public static void PostSolve(this B2S_CollisionListenerComponent self, Contact contact, in ContactImpulse impulse)
        {
        }

        public static void FixedUpdate(this B2S_CollisionListenerComponent self)
        {
            foreach (var tobeRemovedData in self.m_ToBeRemovedCollisionData)
            {
                self.m_CollisionRecorder.Remove(tobeRemovedData);
            }

            self.m_ToBeRemovedCollisionData.Clear();

            foreach (var cachedCollisionData in self.m_CollisionRecorder)
            {
                Unit unitA = self.GetParent<Room>().GetComponent<UnitComponent>().Get(cachedCollisionData.Item1);
                Unit unitB = self.GetParent<Room>().GetComponent<UnitComponent>().Get(cachedCollisionData.Item2);

                if (unitA == null || unitB == null || unitA.IsDisposed || unitB.IsDisposed)
                {
                    // Id不分顺序，防止移除失败
                    self.m_ToBeRemovedCollisionData.Add((cachedCollisionData.Item1, cachedCollisionData.Item2));
                    self.m_ToBeRemovedCollisionData.Add((cachedCollisionData.Item2, cachedCollisionData.Item1));
                    continue;
                }

                B2S_CollisionDispatcherComponent.Instance.HandleCollisionSustain(unitA, unitB);
                B2S_CollisionDispatcherComponent.Instance.HandleCollisionSustain(unitB, unitA);
            }
        }

        /// <summary>
        /// 测试碰撞
        /// </summary>
        public static void TestCollision(this B2S_CollisionListenerComponent self)
        {
            BodyDef bodyDef = new BodyDef { BodyType = BodyType.DynamicBody };
            Body m_Body = self.Parent.GetComponent<B2S_WorldComponent>().GetWorld().CreateBody(bodyDef);
            CircleShape m_CircleShape = new CircleShape();
            m_CircleShape.Radius = 5;
            m_Body.CreateFixture(m_CircleShape, 5);

            BodyDef bodyDef1 = new BodyDef { BodyType = BodyType.DynamicBody };
            Body m_Body1 = self.Parent.GetComponent<B2S_WorldComponent>().GetWorld().CreateBody(bodyDef1);
            CircleShape m_CircleShape1 = new CircleShape();
            m_CircleShape1.Radius = 5;
            m_Body1.CreateFixture(m_CircleShape1, 5);

            Log.Info("创建完成");
        }
    }
}