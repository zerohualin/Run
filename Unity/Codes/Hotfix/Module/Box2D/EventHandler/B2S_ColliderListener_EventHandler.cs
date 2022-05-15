namespace ET
{
    [FriendClass(typeof(B2S_CollisionListenerComponent))]
    public class B2D_BeginContactHandler : AEvent<EventType.B2D_BeginContact>
    {
        protected override void Run(EventType.B2D_BeginContact args)
        {
            Unit unitA = (Unit)args.Contact.FixtureA.UserData;
            Unit unitB = (Unit)args.Contact.FixtureB.UserData;
            if (unitA == null || unitB == null || unitA.IsDisposed || unitB.IsDisposed)
            {
                return;
            }
            args.Listener.m_CollisionRecorder.Add((unitA.Id, unitB.Id));
            B2S_CollisionDispatcherComponent.Instance.HandleCollisionStart(unitA, unitB);
            B2S_CollisionDispatcherComponent.Instance.HandleCollisionStart(unitB, unitA);
        }
    }
    
    [FriendClass(typeof(B2S_CollisionListenerComponent))]
    public class B2D_EndContactHandler : AEvent<EventType.B2D_EndContact>
    {
        protected override void Run(EventType.B2D_EndContact args)
        {
            Unit unitA = (Unit)args.Contact.FixtureA.UserData;
            Unit unitB = (Unit)args.Contact.FixtureB.UserData;

            // Id不分顺序，防止移除失败
            args.Listener.m_ToBeRemovedCollisionData.Add((unitA.Id, unitB.Id));
            args.Listener.m_ToBeRemovedCollisionData.Add((unitB.Id, unitA.Id));

            if (unitA.IsDisposed || unitB.IsDisposed)
            {
                return;
            }

            B2S_CollisionDispatcherComponent.Instance.HandleCollsionEnd(unitA, unitB);
            B2S_CollisionDispatcherComponent.Instance.HandleCollsionEnd(unitB, unitA);
        }
    }
    
    [FriendClass(typeof(B2S_CollisionListenerComponent))]
    public class B2D_PreSolveHandler : AEvent<EventType.B2D_PreSolve>
    {
        protected override void Run(EventType.B2D_PreSolve args)
        {
        }
    }
    
    [FriendClass(typeof(B2S_CollisionListenerComponent))]
    public class B2D_PostSolveHandler : AEvent<EventType.B2D_PostSolve>
    {
        protected override void Run(EventType.B2D_PostSolve args)
        {
        }
    }
}