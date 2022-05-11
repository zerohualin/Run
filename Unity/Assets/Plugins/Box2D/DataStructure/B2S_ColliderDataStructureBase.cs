//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年7月13日 21:34:42
//------------------------------------------------------------

using System.Numerics;
using Sirenix.OdinInspector;

namespace ET
{
    public enum B2S_ColliderType
    {
        [LabelText("矩形碰撞体")]
        BoxColllider,

        [LabelText("圆形碰撞体")]
        CircleCollider,

        [LabelText("多边形碰撞体")]
        PolygonCollider,
    }
    
    [BsonDeserializerRegister]
    public class B2S_ColliderDataStructureBase
    {
        [LabelText("碰撞体ID")]
        public long id;

        [LabelText("是否为触发器")]
        public bool isSensor;

        [LabelText("Box2D碰撞体类型")]
        public B2S_ColliderType b2SColliderType;

        [LabelText("碰撞体偏移信息")]
        public System.Numerics.Vector2 finalOffset = new System.Numerics.Vector2(0, 0);
    }
}