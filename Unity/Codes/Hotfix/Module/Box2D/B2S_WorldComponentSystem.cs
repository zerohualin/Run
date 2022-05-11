using System.Numerics;
using Box2DSharp.Dynamics;

namespace ET
{
    [FriendClass(typeof (B2S_WorldComponent))]
    [ObjectSystem]
    public class B2S_WorldComponentAwakeSystem: AwakeSystem<B2S_WorldComponent>
    {
        public override void Awake(B2S_WorldComponent self)
        {
            self.m_World = B2S_WorldUtility.CreateWorld(new Vector2(0, 0));
        }
    }

    [FriendClass(typeof (B2S_WorldComponent))]
    [ObjectSystem]
    public static class B2S_WorldComponentSystem
    {
        public static void AddBodyTobeDestroyed(this B2S_WorldComponent self, Body body)
        {
            self.BodyToDestroy.Add(body);
        }

        public static void FixedUpdate(this B2S_WorldComponent self)
        {
            foreach (var body in self.BodyToDestroy)
            {
                self.m_World.DestroyBody(body);
            }

            self.BodyToDestroy.Clear();
            self.m_World.Step(GlobalDefine.FixedUpdateTargetDTTime_Float, B2S_WorldComponent.VelocityIteration, B2S_WorldComponent.PositionIteration);
        }

        public static World GetWorld(this B2S_WorldComponent self)
        {
            return self.m_World;
        }
    }
}