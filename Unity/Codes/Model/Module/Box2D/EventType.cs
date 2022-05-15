using Box2DSharp.Collision.Collider;
using Box2DSharp.Dynamics.Contacts;

namespace ET
{
    namespace EventType
    {
        public struct DebugVisualBox2D
        {
            public Unit Unit;
        }

        public struct B2D_BeginContact
        {
            public B2S_CollisionListenerComponent Listener;
            public Contact Contact;
        }

        public struct B2D_EndContact
        {
            public B2S_CollisionListenerComponent Listener;
            public Contact Contact;
        }
        
        public struct B2D_PreSolve
        {
            public Contact Contact;
            public Manifold OldManifold;
        }
        
        public struct B2D_PostSolve
        {
            public Contact Contact;
            public ContactImpulse Impulse;
        }
    }
}