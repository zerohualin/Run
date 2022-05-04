//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年7月20日 20:09:20
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using Box2DSharp.Collision.Collider;
using Box2DSharp.Collision.Shapes;
using Box2DSharp.Dynamics;
using Box2DSharp.Dynamics.Contacts;

namespace ET
{
    
    /// <summary>
    /// 某一物理世界所有碰撞的监听者，负责碰撞事件的分发
    /// </summary>
    public class B2S_CollisionListenerComponent : Entity, IContactListener, IAwake
    {
        public B2S_WorldColliderManagerComponent B2SWorldColliderManagerComponent;

        public List<(long, long)> m_CollisionRecorder = new List<(long, long)>();

        public List<(long, long)> m_ToBeRemovedCollisionData = new List<(long, long)>();
        
        
        public override void Dispose()
        {
            base.Dispose();
            if (this.IsDisposed)
                return;
            m_ToBeRemovedCollisionData.Clear();
            this.m_CollisionRecorder.Clear();
        }

        public void BeginContact(Contact contact)
        {
        }

        public void EndContact(Contact contact)
        {
        }

        public void PreSolve(Contact contact, in Manifold oldManifold)
        {
        }

        public void PostSolve(Contact contact, in ContactImpulse impulse)
        {
        }
    }
}